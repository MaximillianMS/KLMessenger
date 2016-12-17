#pragma once
#include "Messenger.h"
static std::shared_ptr<messenger::IMessenger> g_messenger;
typedef void(*LoginCallback)(messenger::operation_result::Type);
typedef void(*StatusCallback)(const char* msgId, messenger::message_status::Type status);
struct MyMessage;
struct MyUser;
typedef void(*MessageCallback)(const char* senderId, MyMessage msg);
typedef void(*UsersCallback)(messenger::operation_result::Type, MyUser* Users, int Count);
class MyLoginCallback : public messenger::ILoginCallback
{
public:
	LoginCallback loginCallback = NULL;
	void OnOperationResult(messenger::operation_result::Type result) override;
};
class MyUsersCallback : public messenger::IRequestUsersCallback
{
public:
	UsersCallback usersCallback=NULL;
	void OnOperationResult(messenger::operation_result::Type result, const messenger::UserList& users) override;
};
struct MyMessageContent
{
	messenger::message_content_type::Type type;
	int encrypted=0;
	unsigned char* Data=NULL;
	int length=0;
	MyMessageContent(const messenger::MessageContent &content)
	{
		type = content.type;
		if (content.encrypted)
			encrypted = 1;
		if (content.data.size() > 0)
		{
			Data = (unsigned char*)&content.data[0];
			length = content.data.size();
		}
		else
		{
			Data = NULL;
		}
	}
	MyMessageContent()
	{
		Data = NULL;
		length = 0;
		encrypted = 0;
		type = messenger::message_content_type::Text;
	}
};
struct MyMessage
{
	const char* identifier;
	std::time_t time;
	MyMessageContent content;
	MyMessage(const messenger::Message &msg)
	{
		identifier = msg.identifier.c_str();
		content = MyMessageContent(msg.content);
		time = msg.time;
	}
	MyMessage()
	{
		identifier = NULL;
		time = 0;
	}
};
class MyObserver : public messenger::IMessagesObserver
{
public:
	StatusCallback statusCallback;
	MessageCallback messageCallback;
	void OnMessageStatusChanged(const messenger::MessageId& msgId, messenger::message_status::Type status) override;
	void OnMessageReceived(const messenger::UserId& senderId, const messenger::Message& msg) override;
};
struct MyPolicy
{
	messenger::encryption_algorithm::Type encryptionAlgo=messenger::encryption_algorithm::None;
	int* PublicKey=NULL;
	MyPolicy(messenger::SecurityPolicy policy)
	{
		encryptionAlgo = policy.encryptionAlgo;
		if(policy.encryptionPubKey.size()>0)
		PublicKey = (int*)&policy.encryptionPubKey[0];
	}
	MyPolicy() : encryptionAlgo(messenger::encryption_algorithm::None), PublicKey(NULL)
	{

	}
};
struct MyUser
{
	const char* identifier=NULL;
	MyPolicy securityPolicy;
	MyUser(const messenger::User* user)
	{
		MyUser::identifier = user->identifier.c_str();
		securityPolicy = MyPolicy(user->securityPolicy);
	}
	MyUser() : identifier(NULL)
	{

	}
};
static MyLoginCallback g_callbackLogin;
static MyUsersCallback g_callbackUsers;
static MyObserver g_observer;
extern "C"
{
	void __declspec(dllexport) Init(char* url, unsigned short port);
	void __declspec(dllexport) Login(char* loginStr, char* passStr,MyPolicy AlgoType, LoginCallback loginCallback);
	void __declspec(dllexport) Disconnect();
	void __declspec(dllexport) RegisterObserver(StatusCallback statusCallback, MessageCallback messageCallback);
	void __declspec(dllexport) UnregisterObserver();
	void __declspec(dllexport) RequestActiveUsers(UsersCallback usersCallback);
	void __declspec(dllexport) SendMessageSeen(char* userId, char* msgId);
	char __declspec(dllexport) * SendMessage(char* userId, MyMessageContent* content, time_t * time);
}