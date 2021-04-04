import {useState, useEffect, useRef} from 'react'
import {HubConnection, HubConnectionBuilder, HubConnectionState} from '@microsoft/signalr'

import {ChatWindow, MessageProps} from '../ChatWindow'
import {ChatInput} from '../ChatInput/Index';

const Chat = () => {
    const [connection, setConnection] = useState<HubConnection | null>(null);
    const [messages, setMessages] = useState([] as MessageProps[]);
    const latestChat = useRef([] as MessageProps[]);
    latestChat.current = messages;

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/hubs/chat')
        .withAutomaticReconnect()
        .build();
        setConnection(newConnection);
    },[])

    useEffect( () => {
        if (connection){
            connection.start()
            .then(result => {
                console.log('connected!');
                connection.on('ReceiveMessage', message => {
                    setMessages(m => [...m, message]);
                })
            })
            .catch(err => {
                console.log('connection failed: ', err)
            })
        }
    },[connection])

    const sendMessage = async (user: string, message: string) => {
        const chatMessage = {
            user: user,
            message: message
        } as MessageProps;

        console.log(message);

        if (connection?.state === HubConnectionState.Connected){
            try{
                await connection.send('SendMessage', chatMessage);
            } catch (e) {
                console.log(e);
            }
        } else {
            alert('No connection to server');
        }
    }

    return <div>
        <ChatInput sendMessage={sendMessage} />
        <hr/>
        <ChatWindow messages={messages} />
    </div>
}

export default Chat