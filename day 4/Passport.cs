using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_4
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }


        public bool IsValid()
        {
            var validators = new List<bool>
            {
                IsYearValid(BirthYear, 1920, 2002),
                IsYearValid(IssueYear, 2010, 2020),
                IsYearValid(ExpirationYear, 2020, 2030),
                IsHeightValid(),
                IsHairColorValid(),
                IsEyeColorValid(),
                IsPassportIdValid(),
            };
            return validators.All(valid => valid);
        }

        private bool IsYearValid(int? year, int min, int max)
            => year.HasValue
               && year >= min
               && year <= max;

        private bool IsHeightValid()
        {
            if (string.IsNullOrEmpty(Height))
                return false;
            
            bool ValidateHeight(string unit, int min, int max)
            {
                var removed = Height.Replace(unit, string.Empty);
                var parsedCorrectly = int.TryParse(removed, out var height);
                return parsedCorrectly
                       && height >= min
                       && height <= max;
            }
            
            return Height.Contains("cm")
                ? ValidateHeight("cm", 150, 193)
                : Height.Contains("in") 
                  && ValidateHeight("in", 59, 76);
        }

        private bool IsHairColorValid()
            => !string.IsNullOrEmpty(HairColor) 
               && new Regex(@"^#[0-9a-f]{6}$").IsMatch(HairColor);

        private bool IsEyeColorValid()
            => !string.IsNullOrEmpty(EyeColor)
               && new List<string>
               {
                   "amb",
                   "blu",
                   "brn",
                   "gry",
                   "grn",
                   "hzl",
                   "oth",
               }.Contains(EyeColor);

        private bool IsPassportIdValid()
            => !string.IsNullOrEmpty(PassportId)
               && new Regex(@"^[0-9]{9}$").IsMatch(PassportId);
    }
}