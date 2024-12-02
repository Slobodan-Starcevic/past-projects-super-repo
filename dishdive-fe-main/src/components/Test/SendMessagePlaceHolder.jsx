import { useEffect, useState, useRef } from "react";
import Input from '../Elements/Input'
import Button from '../Elements/Button'

const SendMessagePlaceholder = ({username, recipientName, onMessageSend, messagesReceived}) => {
  const [message, setMessage] = useState('');
  const [destinationUsername, setDestinationUsername] = useState('');
  const messagesContainerRef = useRef();

  useEffect(() => {
    console.log(username, recipientName)
    setDestinationUsername(recipientName);
  }, [])

  useEffect(() => {
    messagesContainerRef.current.scrollTop = messagesContainerRef.current.scrollHeight;
  }, [messagesReceived]);

  const handleMessageSend = () => {
    if (!message) {
      alert('Please type a message!');
    }else{
      onMessageSend({ 'text': message, 'to': destinationUsername });
      setMessage('');
    }
  }

  return (
    <>
      <section className="flex justify-center p-5 min-h-[600px] bg-gradient-to-b from-[#1b1b1b] to-black">
        <div className="flex-col p-6 w-[1000px] bg-black overflow-hidden rounded-[1rem] space-y-3">
          <div className="flex justify-between">
          <p className="font-bold text-2xl pl-3">Chatting with <span className="text-ddGreen">{recipientName}</span></p>
          </div>
          <div className=" bg-ddInputBg w-full h-[500px] overflow-y-auto overflow-x-hidden rounded-md" ref={messagesContainerRef}>
          {messagesReceived.map((message) => (
            <div key={message.id} className={`w-full flex-col ml-3 mt-3 border-b border-ddGrey2`}>
              <p className="max-w-full font-bold flex">{message.from}</p>
              <p>{message.text}</p>
            </div>
          ))}
            </div>
          <div className="flex flex-auto h-[3rem] space-x-2">
            <Input placeholder={"Write a message"} className={"flex-1"} value={message} onChange={(event) => setMessage(event.target.value)}/>
            <Button text={"Send"} className={"rounded-md w-[150px]"} onClick={handleMessageSend}/>
          </div>
        </div>
      </section>
    </>
  );
}

export default SendMessagePlaceholder;