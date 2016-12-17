using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Messenger_KasperskyLab.messenger.message_status;

namespace Messenger_KasperskyLab
{
    public static class DateTimeConversion
    {
        public static DateTime UnixTimeToDateTime(long unixTime)
        {
            return UnixStartTime.AddSeconds(Convert.ToDouble(unixTime));
        }
        public static long DateTimeToUnixTime(DateTime date)
        {
            var timeSpan = date - UnixStartTime;
            return Convert.ToInt64(timeSpan.TotalSeconds);
        }
        private static readonly DateTime UnixStartTime = new DateTime(
        1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnOperationResult_L(messenger.operation_result.Type result);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnOperationResult_U(messenger.operation_result.Type result,[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), In] messenger.User[] users, uint count);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MessageCallback([MarshalAs(UnmanagedType.LPStr)]string senderId,[MarshalAs(UnmanagedType.Struct), In] messenger.Message msg);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void StatusCallback([MarshalAs(UnmanagedType.LPStr)]string msgId, messenger.message_status.Type status);

    public delegate void RefreshUserListEventHandler(List<string> Users);
    public delegate void UpdateOutputTextBoxEventHandler(string userId, string msgId, string msg, DateTime time, string senderId, messenger.message_status.Type status);
    public delegate void ReconnectHandler();
    public delegate void SendMessageSeenEventHandler(string UsedId, string msgId);
    class Model: IDisposable
    {
        public event ReconnectHandler Reconnect;
        public event RefreshUserListEventHandler RefreshUserList;
        public  event UpdateOutputTextBoxEventHandler UpdateOutputTextBox;
        public delegate void RequestUserListEventHandler();
        public event RequestUserListEventHandler RequestUsers;
        public delegate void RegisterObserverEventHandler();
        public event RegisterObserverEventHandler RegisterObs;
        public event SendTextMessageHandler SendTextMessageEvent;
        public delegate void SendTextMessageHandler(string UserId, string msg);
        public event SendMessageSeenEventHandler SendMessageSeen;
        public bool isConnected;
        IntPtr PubKey;
        string userId;
        List<messenger.User> Users= new List<messenger.User>();
        static Dictionary<string, List<string>> MGS = new Dictionary<string, List<string>>();
        public Model()
        {
            PubKey = IntPtr.Zero;
            isConnected = false;
            messageCallback = MessageCallback;
            statusCallback = StatusCallback;
            RequestUsers += RequestUserList;
            RegisterObs += RegisterObserver;
            SendTextMessageEvent += PrepareTextDataToSend;
            SendMessageSeen += SendMessageSeenHandler;
        }
        public void SendMsgSeen(string UserId, string msgId)
        {
            SendMessageSeen.BeginInvoke(UserId, msgId, null, null);
        }
        private void SendMessageSeenHandler(string UsedId, string msgId)
        {
            messenger.Wrap.SendMessageSeen(UsedId, msgId);
        }

        public void Init(string url, ushort port, string userId, string password, bool encryption, byte[] pubKey)
        {
            this.userId = userId;
            if(isConnected)
            {
                messenger.Wrap.Disconnect();
            }
            messenger.Wrap.Init(url, port);
            messenger.SecurityPolicy Policy = new messenger.SecurityPolicy();
            if(encryption)
            {
                if (PubKey != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(PubKey);
                    PubKey = IntPtr.Zero;
                }
                Policy.encryptionAlgo = messenger.encryption_algorithm.Type.RSA_1024;
                PubKey = Marshal.AllocHGlobal(pubKey.Length);
                Marshal.Copy(pubKey, 0, PubKey, pubKey.Length);
                Policy.encryptionPubKey = PubKey;
            }
            else
            {
                if (PubKey != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(PubKey);
                    PubKey = IntPtr.Zero;
                }
                Policy.encryptionAlgo = messenger.encryption_algorithm.Type.None;
            }
            messenger.Wrap.Login(userId,
        password, Policy, Marshal.GetFunctionPointerForDelegate(new OnOperationResult_L(LoginCallBack)));
        }
        public void SendMessage(string UserId, string msg)
        {
            //SendTextMessageEvent.BeginInvoke(UserId, msg,null,null);
            PrepareTextDataToSend(UserId, msg);
        }
        private void PrepareTextDataToSend(string UserId, string msg)
        {
            messenger.MessageContent content = new messenger.MessageContent();
            content.type = messenger.message_content_type.Type.Text;
            content.encrypted = false;
            content.data = IntPtr.Zero;
            try
            {
                content.length = Marshal.SizeOf(Encoding.UTF8.GetBytes(msg + '\0')[0]) * Encoding.UTF8.GetBytes(msg + '\0').Length;
                content.data = Marshal.AllocHGlobal(content.length);
                Marshal.Copy(Encoding.UTF8.GetBytes(msg + '\0'), 0, content.data, Encoding.UTF8.GetBytes(msg + '\0').Length);
                IntPtr ptr= IntPtr.Zero;
                long time=0;
                string identifier = messenger.Wrap.SendMessage(UserId, ref content, ref time);
                UpdateOutputTextBox.BeginInvoke(UserId, identifier, msg, DateTimeConversion.UnixTimeToDateTime(time), this.userId, messenger.message_status.Type.Sent,null,null);
            }
            finally
            {
                if (content.data != IntPtr.Zero) Marshal.FreeHGlobal(content.data);
            }

        }
        public StatusCallback statusCallback;
        public MessageCallback messageCallback;
        public void InvokeRequestUsers()
        {
            RequestUsers.BeginInvoke(null, null);
        }
        private void RegisterObserver()
        {
            messenger.Wrap.RegisterObserver(Marshal.GetFunctionPointerForDelegate(statusCallback), Marshal.GetFunctionPointerForDelegate(messageCallback));
            RequestUsers.BeginInvoke(null, null);
        }
        private void RequestUserList()
        {
            messenger.Wrap.RequestActiveUsers(Marshal.GetFunctionPointerForDelegate(new OnOperationResult_U(UsersCallback)));
        }
        public void MessageCallback(string senderId, messenger.Message msg)
        {
            if(msg.content.type==messenger.message_content_type.Type.Text&&!msg.content.encrypted)
            {
                if(!MGS.ContainsKey(senderId))
                {
                    MGS.Add(senderId, new List<string>());
                }
                var data = new byte[msg.content.length-1];
                Marshal.Copy(msg.content.data, data, 0, msg.content.length-1);
                MGS[senderId].Add(Encoding.UTF8.GetString(data));
                string identifier = Marshal.PtrToStringAnsi(msg.identifier);
                UpdateOutputTextBox.BeginInvoke(senderId, identifier, MGS[senderId].Last(), DateTimeConversion.UnixTimeToDateTime(msg.time),senderId,messenger.message_status.Type.Delivered, null, null);
            }
        }
        public void StatusCallback(string msgId, messenger.message_status.Type status)
        {
            UpdateOutputTextBox.BeginInvoke(null, msgId, null, DateTime.Now, null, status, null, null);

        }
        public void Disconnect()
        {
            messenger.Wrap.UnregisterObserver();
            messenger.Wrap.Disconnect();
        }
        private void LoginCallBack(messenger.operation_result.Type result)
        {
            if(result==messenger.operation_result.Type.Ok)
            {
                isConnected = true;
                RegisterObs.BeginInvoke(null, null);
            }
            else
            {
                Reconnect.BeginInvoke(null, null);
            }
        }
        private void UsersCallback(messenger.operation_result.Type result, messenger.User[] users, uint count)
        {
            List<string> UserList=new List<string>();
            foreach(messenger.User user in users)
            {
                Users.Add(user);
                UserList.Add(Marshal.PtrToStringAnsi(user.identifier));
            }
            RefreshUserList.BeginInvoke(UserList,null,null);   
        }
        public void Dispose()
        {
            if(isConnected)
            {
                Disconnect();
            }
            if(PubKey!=IntPtr.Zero)
            {
                Marshal.FreeHGlobal(PubKey);
                PubKey = IntPtr.Zero;
            }
        }
    }
}
