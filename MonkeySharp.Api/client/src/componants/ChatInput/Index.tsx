import React, {useState} from 'react'

type ChatInputProps = {
    sendMessage: (user: string, message: string) => Promise<void>
}

export const ChatInput = ({sendMessage}: ChatInputProps) => {
    const [user, setUser] = useState("");
    const [message, setMessage] = useState("");

    const onSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        const isUserProvided = user && user !== "";
        const isMessageProvided = message && message !== "";

        if (isUserProvided && isMessageProvided) {
            sendMessage(user, message)
        } else {
            alert("please provide user and message");
        }
    }

    const onUserChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUser(e.target.value)
    }

    const onMessageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setMessage(e.target.value)
    }


    return <form onSubmit={onSubmit}>
        <label htmlFor="user">user: </label>
        <input type="text" name="user" id="user" onChange={onUserChange} value={user}/>
        <br/>
        <label htmlFor="message">message:</label>
        <input type="text" name="message" id="message" onChange={onMessageChange} value={message}/>
        <input type="submit" value="submit" style={{display: "none"}}/>
    </form>
}
