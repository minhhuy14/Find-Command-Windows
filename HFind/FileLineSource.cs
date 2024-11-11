namespace HFind
{
    internal class FileLineSource : ConsoleLineSource
    {
        private string path;

        public FileLineSource(string path)
        {
            this.path = path;
        }
    }
}