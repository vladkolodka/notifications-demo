import React, {useState, useCallback} from 'react';

export default function NotificationsContainer() {
    const [username, setUsername] = useState('');

    const onOk = useCallback(() => {
        // TODO
    }, [username]);

    return <>
        <h1>Enter your username</h1>
        <input type="text" value={username} onChange={(e) => setUsername(e.target.value)}/>

        <button onClick={onOk}>Ok</button>
    </>

}