using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Messenger_KasperskyLab
{
    public class ViewModel: IDisposable
    {
        static Model M;

        public ViewModel()
        {
            M = new Model();
        }
        public void Dispose()
        {
            ;
        }
        public void ExecCommand(Command C, object[] MW)
        {
            switch(C)
            {
                case Command.Init:
                    {
                            M.Init(((Connect)MW[0]).textBoxURL.GetLineText(0), (ushort)Int16.Parse(((Connect)MW[0]).textBoxPort.GetLineText(0)), ((Connect)MW[0]).textBoxLogin.GetLineText(0), ((Connect)MW[0]).passwordBox.Password, (bool)((Connect)MW[0]).checkBoxSecConnect.IsChecked, null);
                        break;
                    }
                case Command.RefreshUsers:
                    {
                        M.InvokeRequestUsers();
                        break;
                    }
                case Command.Disconnect:
                    {
                        M.Disconnect();
                        break;
                    }
                case Command.Send:
                    {
                        string msg="";
                        if(((MainWindow)MW[0]).textBoxInput.LineCount!=0)
                        {
                            for (int i = 0; i < ((MainWindow)MW[0]).textBoxInput.LineCount; i++)
                            {
                                msg += "\n" + (string)((MainWindow)MW[0]).textBoxInput.GetLineText(i);
                            }
                            msg = msg.Trim();
                            if(msg.Length>0)
                            {
                                M.SendMessage((string)((MainWindow)MW[0]).comboBoxUsers.SelectionBoxItem, msg);
                            }
                        }
                        break;
                    }
                case Command.SendSeen:
                    {
                        M.SendMsgSeen((string)MW[0], (string)MW[1]);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public void AddReconnectHandler(ReconnectHandler func)
        {
            M.Reconnect+=func;
        }
        public void AddRefreshUserListHandler(RefreshUserListEventHandler func)
        {
            M.RefreshUserList += func;
        }
        public void AddUpdateOutputTextBox(UpdateOutputTextBoxEventHandler func)
        {
            M.UpdateOutputTextBox += func;
        }
    }
    public enum Command: int
    {
        Init,
        RefreshUsers,
        Send,
        SendSeen,
        Disconnect
    }
    public struct CommandArg
    {

    }
}
