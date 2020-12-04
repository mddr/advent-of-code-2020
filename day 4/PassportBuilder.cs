namespace day_4
{
    public class PassportBuilder
    {
        private Passport Passport { get; set; }

        public PassportBuilder()
        {
            Passport = new Passport();
        }

        public Passport Build() => Passport;

        public void Clear()
        {
            Passport = new Passport();
        }

        public void Set(string key, string value)
        {
            switch (key)
            {
                case "byr": 
                    Passport.BirthYear = int.Parse(value);
                    break;
                case "iyr": 
                    Passport.IssueYear = int.Parse(value);
                    break;
                case "eyr": 
                    Passport.ExpirationYear = int.Parse(value);
                    break;
                case "hgt": 
                    Passport.Height = value;
                    break;
                case "hcl":
                    Passport.HairColor = value;
                    break;
                case "ecl":
                    Passport.EyeColor = value;
                    break;
                case "pid":
                    Passport.PassportId = value;
                    break;
                case "cid":
                    Passport.CountryId = value;
                    break;
            }
        }
    }
}