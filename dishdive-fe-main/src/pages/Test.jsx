import React, { useEffect, useState } from 'react';
import { Client } from '@stomp/stompjs';
import { v4 as uuidv4 } from 'uuid';
import SendMessagePlaceholder from '../components/Test/SendMessagePlaceholder';
import useAuthStore from '../utility/auth/authStore'
import { useNavigate, useParams } from 'react-router-dom';
import {createPopup} from '../utility/popupHandler'

function Test() {
  const [stompClient, setStompClient] = useState();
  const [username, setUsername] = useState();
  const [messagesReceived, setMessagesReceived] = useState([]);
  const { user } = useAuthStore();
  const navigate = useNavigate();
  const { name } = useParams();

  useEffect(() => {
    if(user == name){
      navigate('/')
      createPopup('error', "Can't chat with yourself")
    } else if(user){
      setUsername(user.username);
      setupStompClient(user.username);
    } else{
      navigate('/login', {replace: true})
      createPopup("error", "Login required for chatting")
    }
  }, [])

  const setupStompClient = (username) => {
    const stompClient = new Client({
      brokerURL: 'ws://localhost:8080/ws',
      reconnectDelay: 5000,
      heartbeatIncoming: 4000,
      heartbeatOutgoing: 4000
    });

    stompClient.onConnect = () => {
      stompClient.subscribe(`/user/${username}/queue/inboxmessages`, (data) => {
        onMessageReceived(data);
      });

      stompClient.subscribe(`/user/${name}/queue/inboxmessages`, (data) => {
        onMessageReceived(data);
      });
    };

    stompClient.activate();

    setStompClient(stompClient);
  };

  const sendMessage = (newMessage) => {
    const payload = { 'id': uuidv4(), 'from': username, 'to': newMessage.to, 'text': newMessage.text };
    stompClient.publish({ 'destination': `/user/${payload.to}/queue/inboxmessages`, body: JSON.stringify(payload) });
  };

  const onMessageReceived = (data) => {
    const message = JSON.parse(data.body);
    setMessagesReceived(messagesReceived => [...messagesReceived, message]);
  };

  return (
    <>
      <div >
        <SendMessagePlaceholder username={username} onMessageSend={sendMessage} recipientName={name} messagesReceived={messagesReceived}/>
      </div>
    </>
  );

}

export default Test