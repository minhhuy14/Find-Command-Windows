namespace HFind
{
    internal interface ILineSource
    {
        string Name { get; }
        Line? ReadLine();
        void Open();
        void Close();
    }
}
