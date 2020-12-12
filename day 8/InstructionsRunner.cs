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
                "nop" => new NoopInstruction(argument),
                "acc" => new AccInstruction(argument),
                "jmp" => new JumpInstruction(argument),
                _ => throw new ArgumentException($"Invalid line provided: {line}")
            };
            Instructions.Add(newInstruction);
        }

        public int RunPartOne()
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

        public int RunPartTwo()
        {
            if (!Instructions.Any())
                throw new Exception("Cannot run before instructions are loaded");
            
            var accumulator = 0;
            var currentPosition = 0;
            var testedSwitches = new List<int>();

            while (currentPosition < Instructions.Count)
            {
                accumulator = 0;
                currentPosition = 0;
                var alreadySwitched = false;
                
                var visitedIndices = new List<int>();
                while (!visitedIndices.Contains(currentPosition) && currentPosition < Instructions.Count)
                {
                    visitedIndices.Add(currentPosition);
                    
                    var instruction = Instructions[currentPosition];
                    if (!alreadySwitched && !testedSwitches.Contains(currentPosition))
                    {
                        switch (instruction)
                        {
                            case NoopInstruction _:
                                instruction = new JumpInstruction(instruction.Argument);
                                alreadySwitched = true;
                                testedSwitches.Add(currentPosition);
                                break;
                            case JumpInstruction _:
                                instruction = new NoopInstruction(instruction.Argument);
                                alreadySwitched = true;
                                testedSwitches.Add(currentPosition);
                                break;
                        }
                    }

                    accumulator += instruction.AccumulatorDelta;
                    currentPosition += instruction.PositionDelta;
                }
            }

            return accumulator;
        }
    }
}