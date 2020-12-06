using System;
using System.Collections.Generic;
using System.Linq;

namespace day_6
{
    public class GroupReaderPartTwo : IGroupReader
    {
        private Dictionary<char, int> Answers { get; set; }
        private int PeopleInGroup { get; set; }

        public GroupReaderPartTwo()
        {
            InitializeNewGroup();
        }
        
        public void ReadLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentException("Line cannot be empty");

            PeopleInGroup++;
            foreach (var t in line)
            {
                if (Answers.ContainsKey(t))
                    Answers[t]++;
                else
                    Answers.Add(t, 1);
            }
        }

        public int GetAnswersCount()
            => Answers
                .Count(a => a.Value == PeopleInGroup);
                

        public void InitializeNewGroup()
        {
            Answers = new Dictionary<char, int>();
            PeopleInGroup = 0;
        }
    }
}