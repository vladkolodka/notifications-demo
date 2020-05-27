import React, {useEffect, useState, useCallback} from 'react';
import logo from './logo.svg';
import './App.css';

import signalrWorker from './signalrNotifications.worker';

function App() {
    const [worker, setWorker] = useState(null);

    const workerMessageHandler = useCallback((e) => {
        // alert(e.data);
        console.log(e)
    }, []);

    useEffect(() => {
        const w = new signalrWorker();

        w.addEventListener('message', workerMessageHandler);
        setWorker(w);

        return () => {
            w.terminate();
            setWorker(null);
        };
    }, [setWorker, workerMessageHandler]);

    useEffect(() => {
        if (worker != null) {
            worker.postMessage('test');
        }
    }, [worker]);

    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo"/>
                <p>
                    Edit <code>src/App.js</code> and save to reload.
                </p>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
        </div>
    );
}

export default App;
