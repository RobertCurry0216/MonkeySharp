export type OutputProps = {
  output: string[];
};

export const ReplOutput = ({ output }: OutputProps) => {
  return (
    <div>
      {output.map((line, i) => (
        <p key={i}>{`${i}: ${line}`}</p>
      ))}
    </div>
  );
};
