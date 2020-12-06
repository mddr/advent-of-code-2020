using System;
using System.Collections.Generic;

namespace day_6
{
    public class GroupReaderPartOne : IGroupReader
    {
        private HashSet<char> Answers { get; set; }

        public GroupReaderPartOne()
        {
            InitializeNewGroup();
        }

        public void ReadLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentException("Line cannot be empty");
            
            foreach (var t in line)
            {
                Answers.Add(t);
            }
        }

        public int GetAnswersCount() => Answers.Count;

        public void InitializeNewGroup()
        {
            Answers = new HashSet<char>();
        } 
    }
}