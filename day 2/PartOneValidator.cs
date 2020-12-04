using System.Linq;

namespace day_2
{
    public class PartOneValidator : IPasswordValidator
    {
        public bool IsValid(Password password)
        {
            var letterAmount = password.Sequence.Count(c => c == password.Letter);
            return letterAmount >= password.LowerBound && letterAmount <= password.UpperBound;
        }
    }
}