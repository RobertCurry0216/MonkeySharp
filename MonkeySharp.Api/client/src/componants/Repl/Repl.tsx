import { useState, useEffect } from "react";
import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
} from "@microsoft/signalr";

import { ReplInput } from "./ReplInput";
import { ReplOutput } from "./ReplOutput";

const URL = "https://localhost:5001/monkeysharp/repl";

export const Repl = () => {
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [output, setOutput] = useState([] as string[]);
  const [connected, setConnected] = useState(false);

  // connect on mount
  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withAutomaticReconnect()
      .withUrl(URL)
      .build();
    setConnection(newConnection);
  }, []);

  // refresh connection
  useEffect(() => {
    if (connection === null) return;
    const setupConnection = async () => {
      try {
        await connection.start();
        connection.on("WriteLine", (line) => {
          setOutput((o) => [...o, line]);
        });

        connection.on("Write", (line) => {
          setOutput((o) => {
            o[o.length - 1] += line;
            return [...o];
          });
        });
      } catch (err) {
        console.log(err);
      }
      setConnected(connection?.state === HubConnectionState.Connected);
    };
    setupConnection();
  }, [connection]);

  const parseCode = async (input: string) => {
    if (connection === null) return;
    try {
      await connection.send("ParseRawCode", input);
    } catch (err) {
      console.log(err);
      setOutput(["connection error :("]);
    }
  };
  return (
    <>
      {connected || <h3>Loading...</h3>}
      {connected && (
        <div>
          <ReplInput parseCode={parseCode} />
          <ReplOutput output={output} />
        </div>
      )}
    </>
  );
};
