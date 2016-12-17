using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace Messenger_KasperskyLab.messenger
{
using Data = IntPtr;//vector<char>
using SecPublicKey=IntPtr;//vector<char>
using UserId=String;
using MessageId = String;
    namespace operation_result
{
        public enum Type :int
    {
        Ok,
        AuthError,
        NetworkError,
        InternalError
    };
}
   
namespace message_status
{
        public enum Type: int
    {
        Sending,
        Sent,
        FailedToSend,
        Delivered,
        Seen
    };
}
    
namespace message_content_type
{
        public enum Type: int
    {
        Text,
        Image,
        Video
    };
}
    
namespace encryption_algorithm
{
        public enum Type: int
    {
        None,
        RSA_1024
    };
}
[StructLayout(LayoutKind.Sequential)]
public struct MessageContent
{
        public message_content_type.Type type;
        public bool                       encrypted;
        public Data                       data;
        public int length;
};
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public    struct Message
{
        public IntPtr      identifier;
        public long    time;
        public MessageContent content;
};
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct SecurityPolicy
{
    public encryption_algorithm.Type encryptionAlgo;
    public SecPublicKey               encryptionPubKey;
};
[StructLayout(LayoutKind.Sequential)]
public    struct User
{
        public IntPtr       identifier;
    public SecurityPolicy securityPolicy;
};


    
}


