#include "messenger_dll.h"
void MyLoginCallback::OnOperationResult(messenger::operation_result::Type result) {
	if (loginCallback != NULL) loginCallback(result);
	loginCallback = NULL;
}
void Init(char* url, unsigned short port) {
	messenger::MessengerSettings settings;
	settings.serverPort = port; //port;
	settings.serverUrl = url;//url;
	g_messenger = messenger::GetMessengerInstance(settings);
}
void Login(char* loginStr, char* passStr, MyPolicy policy, LoginCallback loginCallback) {
	std::string login = loginStr;
	std::string pass = passStr;
	g_callbackLogin.loginCallback = loginCallback;
	messenger::SecurityPolicy Policy;
	Policy.encryptionAlgo = policy.encryptionAlgo;
	std::vector<unsigned char> PubKey;
	int length;
	switch (policy.encryptionAlgo)
	{
	case messenger::encryption_algorithm::RSA_1024:
	{
		length = 128;
			break;
	}
	default:
	{
		length = 0;
		break;
	}
	}
	if (policy.encryptionAlgo != messenger::encryption_algorithm::None)
	{
		try
		{
			if (length == 0)
			{
				throw;
			}
			else
			{
				for (int i = 0; i < length; i++)
				{
					PubKey.push_back(policy.PublicKey[i]);
				}
			}
		}
		catch (...)
		{
			length = 0;
			PubKey.clear();
			Policy.encryptionAlgo = messenger::encryption_algorithm::None;
			g_callbackLogin.OnOperationResult(messenger::operation_result::InternalError);
			return;
		}
	}
	else
	{
		PubKey.clear();
		Policy.encryptionAlgo = messenger::encryption_algorithm::None;
	}
	g_messenger->Login(login, pass, Policy, &g_callbackLogin);
} 
void Disconnect()
{
	g_messenger->Disconnect();
}
void RegisterObserver(StatusCallback statusCallback, MessageCallback messageCallback)
{
	std::cout << "Registering observer...\n";
	g_observer.messageCallback = messageCallback;
	g_observer.statusCallback = statusCallback;
	g_messenger->RegisterObserver(&g_observer);
}

void UnregisterObserver()
{
	std::cout << "UnRegistering observer...\n";
	g_messenger->UnregisterObserver(&g_observer);
	g_observer.messageCallback = NULL;
	g_observer.statusCallback = NULL;
}

void RequestActiveUsers(UsersCallback usersCallback)
{
	g_callbackUsers.usersCallback = usersCallback;
	g_messenger->RequestActiveUsers(&g_callbackUsers);
}

void SendMessageSeen(char * userId, char * msgId)
{
	std::string _userId = userId;
	std::string _msgId = msgId;
	g_messenger->SendMessageSeen(_userId, _msgId);
}

char* SendMessage(char * userId, MyMessageContent* content, time_t* time)
{
	std::string _userId = userId;
	messenger::MessageContent _content;
	_content.encrypted = (*content).encrypted;
	_content.type = (*content).type;
	std::vector<unsigned char>_data;
	for (int i = 0; i < (*content).length; i++)
	{
		_data.push_back((unsigned char)(*content).Data[i]);
	}
	_content.data = _data;
std::cout << std::string((char*)content->Data) << std::endl;
	messenger::Message msg=g_messenger->SendMessage(userId, _content);
	char* str = new char[msg.identifier.length() + 1];
	strcpy(str, msg.identifier.c_str());
	*time = msg.time;
	return str;
}


void MyObserver::OnMessageStatusChanged(const messenger::MessageId & msgId, messenger::message_status::Type status)
{
	statusCallback(msgId.c_str(), status);
}

void MyObserver::OnMessageReceived(const messenger::UserId & senderId, const messenger::Message & msg)
{
	std::cout << "received it\n";
	messageCallback(senderId.c_str(), MyMessage(msg));
}

void MyUsersCallback::OnOperationResult(messenger::operation_result::Type result, const messenger::UserList& users)
{
	if (usersCallback != NULL)
	{
		std::vector<MyUser> myUsers;
		MyUser* Ptr=NULL;
		if (users.size() == 0)
		{
			Ptr = NULL;
		}
		else
		{
			for (messenger::UserList::const_iterator it=users.begin();it!=users.end();++it)
			{
				myUsers.push_back(&*it);
			}
			Ptr = &myUsers[0];
		}
		usersCallback(result, Ptr, users.size());
		myUsers.clear();
	}
	usersCallback = NULL;
}
