using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Messenger_KasperskyLab.messenger
{
    using Data = IntPtr;//vector<char>
    using SecPublicKey = IntPtr;//vector<char>
    using UserId = String;
    using MessageId = String;
    class Wrap
    {
        private const string DLL = @"Messenger_DLL.dll";
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Init([MarshalAs(UnmanagedType.LPStr)] string url, ushort Port);
        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Login(
        [MarshalAs(UnmanagedType.LPStr)] UserId userId,
        [MarshalAs(UnmanagedType.LPStr)] string password,
                       SecurityPolicy securityPolicy,
                       IntPtr callback);
        [DllImport(DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Disconnect();
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RequestActiveUsers(IntPtr callback);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RegisterObserver(IntPtr StatusCallback, IntPtr MessageCallback);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void UnregisterObserver();
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string SendMessage([MarshalAs(UnmanagedType.LPStr)] UserId recepientId,ref MessageContent msgData, ref long time);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SendMessageSeen([MarshalAs(UnmanagedType.LPStr)] UserId userId, [MarshalAs(UnmanagedType.LPStr)] MessageId msgId);
    };
}

