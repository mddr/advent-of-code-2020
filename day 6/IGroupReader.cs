namespace day_6
{
    public interface IGroupReader
    {
        void ReadLine(string line);
        int GetAnswersCount();
        void InitializeNewGroup();
    }
}