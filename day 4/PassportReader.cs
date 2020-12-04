using System;
using System.Collections;
using System.Collections.Generic;

namespace day_4
{
    public class PassportReader
    {
        public List<Passport> Passports { get; }
        
        private PassportBuilder PassportBuilder { get; set; } 
            
        public PassportReader()
        {
            Passports = new List<Passport>();
            PassportBuilder = new PassportBuilder();
        }

        public void ReadLine(string line)
        {
            if (line == string.Empty)
            {
                Passports.Add(PassportBuilder.Build());
                PassportBuilder.Clear();
                return;
            }

            var chunks = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ParseChunks(chunks);
        }

        public void FinishReading()
        {
            Passports.Add(PassportBuilder.Build());
            PassportBuilder.Clear();
        }

        private void ParseChunks(string[] chunks)
        {
            var list = new List<string>(chunks);
            list.ForEach(chunk =>
            {
                var split = chunk.Split(':', StringSplitOptions.RemoveEmptyEntries);
                var key = split[0];
                var value = split[1];
                PassportBuilder.Set(key, value);
            });
        }
        
    }
}