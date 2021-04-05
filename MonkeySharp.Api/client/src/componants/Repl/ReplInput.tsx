import React, { useState } from "react";

type ReplInputProps = {
  parseCode: (input: string) => Promise<void>;
};

export const ReplInput = ({ parseCode }: ReplInputProps) => {
  const [raw, setRaw] = useState("");

  const onSubmitHandler = (e: React.FormEvent) => {
    e.preventDefault();
    console.log(raw);
    parseCode(raw);
  };

  return (
    <div>
      <form onSubmit={onSubmitHandler}>
        <input
          type="text"
          name="replInput"
          id="replInput"
          value={raw}
          onChange={(e) => {
            setRaw(e.target.value);
          }}
        />
        <input type="submit" value="submit" style={{ display: "none" }} />
      </form>
    </div>
  );
};
