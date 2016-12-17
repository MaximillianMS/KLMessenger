using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Messenger_KasperskyLab.messenger
{
    using UserId = String;
    using MessageId = String;

    class IMessagesObserver
{

    ~IMessagesObserver() {}

        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OnMessageStatusChanged(ref MessageId msgId, message_status.Type status);
        [DllImport(DLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void OnMessageReceived(ref UserId senderId, ref Message msg);
        private const string DLL = @"C:\Documents\Visual Studio 2010\Projects\Messenger_KasperskyLab\Messenger_KasperskyLab\Messenger_DLL.dll";

    };

}
