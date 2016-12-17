using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Messenger_KasperskyLab.messenger
{

    [StructLayout(LayoutKind.Sequential)]
    class IAsyncOperationCallback
{
   ~IAsyncOperationCallback() {}
};
    [StructLayout(LayoutKind.Sequential)]
    class ILoginCallback :  IAsyncOperationCallback
{
        public IntPtr OnOperationResult;
};
    [StructLayout(LayoutKind.Sequential)]
    class IRequestUsersCallback : IAsyncOperationCallback
{
        public IntPtr OnOperationResult;
};

}
