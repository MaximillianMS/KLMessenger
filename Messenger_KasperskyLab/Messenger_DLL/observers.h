#ifndef MESSENGER_OBSERVERS_H
#define MESSENGER_OBSERVERS_H

#include "types.h"
#include <iostream>
namespace messenger
{

class IMessagesObserver
{
public:
    virtual ~IMessagesObserver() {}
    
    virtual void OnMessageStatusChanged(const MessageId& msgId, message_status::Type status) { std::cout << "Allax hates you!" << std::endl; };
	virtual void OnMessageReceived(const UserId& senderId, const Message& msg) { std::cout << "Allax loves you!" << std::endl; };
};

}

#endif /* MESSENGER_OBSERVERS_H */
