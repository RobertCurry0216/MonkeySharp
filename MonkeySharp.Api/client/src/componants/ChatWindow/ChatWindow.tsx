import {Message, MessageProps} from './ChatMessage'

type ChatWindowProps = {
    messages: MessageProps[]
}

export const ChatWindow = ({messages}: ChatWindowProps) => {
    return <div>
        {messages.map((m, i) => 
            <Message key={i} user={m.user} message={m.message} />
        )}
    </div>
}