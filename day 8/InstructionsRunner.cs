using System;
using System.Collections.Generic;
using System.Linq;

namespace day_8
{
    public class InstructionsRunner
    {
        private List<IInstruction> Instructions { get; }

        public InstructionsRunner()
        {
            Instructions = new List<IInstruction>();
        }

        public void ParseInstruction(string line)
        {
            var split = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = split[0];
            var argument = int.Parse(split[1]);

            IInstruction newInstruction = name switch
            {
                "nop" => new NoopInstruction(),
                "acc" => new AccInstruction(argument),
                "jmp" => new JumpInstruction(argument),
                _ => throw new ArgumentException($"Invalid line provided: {line}")
            };
            Instructions.Add(newInstruction);
        }

        public int Run()
        {
            if (!Instructions.Any())
                throw new Exception("Cannot run before instructions are loaded");
            
            var accumulator = 0;
            var currentPosition = 0;
            var visitedIndices = new List<int>();

            while (!visitedIndices.Contains(currentPosition))
            {
                visitedIndices.Add(currentPosition);
                
                var instruction = Instructions[currentPosition];
                accumulator += instruction.AccumulatorDelta;
                currentPosition += instruction.PositionDelta;
            }

            return accumulator;
        }
    }
}