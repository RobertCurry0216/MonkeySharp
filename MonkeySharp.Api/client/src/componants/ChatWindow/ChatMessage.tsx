export type MessageProps = {
    user: string,
    message: string
}

export const Message = ({user, message}: MessageProps) => {
    return <div style={{ background: "#eee", borderRadius: '5px', padding: '0 10px' }}>
        <p><strong>{user}: </strong></p>
        <p>{message}</p>
    </div>
}

