using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Messenger_KasperskyLab.messenger
{
[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Ansi)] 
struct MessengerSettings
{
        [MarshalAs(UnmanagedType.LPStr)]
        public  string    serverUrl;
        public ushort serverPort;
};
    
}
