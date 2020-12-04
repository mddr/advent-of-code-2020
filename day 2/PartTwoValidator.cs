using System;
using System.Linq;

namespace day_2
{
    public class PartTwoValidator : IPasswordValidator
    {
        public bool IsValid(Password password)
        {
            var letters = new[]
            {
                // bounds are counted counted from 1 :(
                password.Sequence[password.LowerBound - 1],
                password.Sequence[password.UpperBound - 1]
            };

            return letters.Count(letter => letter == password.Letter) == 1;
        }
    }
}