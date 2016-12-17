using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger_KasperskyLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class MessageView
        {
            DateTime time = DateTime.Today;
            public messenger.message_status.Type status = messenger.message_status.Type.FailedToSend;
            public string senderId = "";
            string message = "";
            public string messageId = "";
            public MessageView(string msgId, string msg, DateTime time, string senderId, messenger.message_status.Type status)
            {
                this.message = msg;
                this.messageId = msgId;
                this.time = time;
                this.senderId = senderId;
                this.status = status;
            }
            override public string ToString()
            {
                return (messageId == "") ? "" : String.Format("{0} ({1}-{2})\n{3}\n", senderId, time.ToString("HH:mm dd.MM.yyyy"), status.ToString("g"), message);
            }
        }
        static public ViewModel VM = new ViewModel();
        static List<string> UserList = new List<string>();
        static Dictionary<string, List<MessageView>> MSG = new Dictionary<string, List<MessageView>>();
        static Dictionary<string, string> MsgIds = new Dictionary<string, string>();
        /// <summary>
        /// Перемещение формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Close(object sender, CancelEventArgs e)
        {
            VM.ExecCommand(Command.Disconnect, null);
        }
        private void Window_Drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void UpdateOutputTextbox(string userId, string msgId, string msg, DateTime time, string senderId, messenger.message_status.Type status)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new UpdateOutputTextBoxEventHandler(UpdateOutputTextbox), userId, msgId, msg, time, senderId, status);
                return;
            }
            int index = -1;
            MessageView msgV = new MessageView(msgId, msg, time, senderId, status); ;
            if (userId != null)
            {
                if (!MSG.ContainsKey(userId))
                {
                    MSG.Add(userId, new List<MessageView>());
                }
                MSG[userId].Add(msgV);
                MsgIds.Add(msgId, userId);
            }
            else
            {
                if (MsgIds.ContainsKey(msgId))
                {
                    userId = MsgIds[msgId];
                    index = MSG[userId].FindIndex(x => x.messageId == msgId);
                    if (index >= 0)
                    {
                        MSG[userId][index].status = status;
                    }
                }
            }
            if (userId != null)
                if (comboBoxUsers.SelectedIndex == UserList.FindIndex(x => x == userId))
                {
                    if (index >= 0)
                    {
                        GetUserSession();
                    }
                    else
                    {
                        textBoxOutput.AppendText(msgV.ToString());
                        if (msgV.senderId == userId)
                        {
                            MSG[userId].Find(x => x.messageId == msgV.messageId).status = messenger.message_status.Type.Seen;
                            GetUserSession();
                            VM.ExecCommand(Command.SendSeen, new object[] { msgV.senderId, msgV.messageId });
                        }
                    }
                }
                else
                {
                    if (senderId != null)
                    {
                        textBoxInfo.Text = "Received From " + userId;
                    }
                }
        }
        private void GetUserSession()
        {
            textBoxOutput.Clear();
            string UserId = UserList[comboBoxUsers.SelectedIndex];
            if (MSG.ContainsKey(UserId))
                foreach (MessageView msg in MSG[UserId])
                {
                    if (msg.senderId == UserId && msg.status == messenger.message_status.Type.Delivered)
                    {
                        msg.status = messenger.message_status.Type.Seen;
                        textBoxOutput.AppendText(msg.ToString());
                        VM.ExecCommand(Command.SendSeen, new object[] { UserId, msg.messageId });
                    }
                    else
                    {

                        textBoxOutput.AppendText(msg.ToString());
                    }
                }
        }
        public MainWindow()
        {
            Closing += Window_Close;
            VM.AddRefreshUserListHandler(RefreshUserList);
            VM.AddUpdateOutputTextBox(UpdateOutputTextbox);
            VM.AddReconnectHandler(Reconnect);
            Reconnect();
            InitializeComponent();
        }
        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            VM.ExecCommand(Command.Send, new object[] { this });
            textBoxInput.Clear();
        }
        private void Reconnect()
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new ReconnectHandler(Reconnect));
                return;
            }
            Connect C = new Connect();
            C.ShowDialog();
            if (C.DialogResult == true)
            {
                VM.ExecCommand(Command.Init, new object[] { C });
            }
            else
            {
                Close();
            }

        }
        private void comboBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetUserSession();
        }
        public void RefreshUserList(List<string> userList)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new RefreshUserListEventHandler(RefreshUserList), userList);
                return;
            }
            UserList = userList;
            comboBoxUsers.ItemsSource = UserList;
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            VM.ExecCommand(Command.RefreshUsers, null);
        }
    }
}
