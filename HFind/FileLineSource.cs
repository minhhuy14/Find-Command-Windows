namespace HFind
{
    internal class FileLineSource : ILineSource
    {
        private readonly string path;
        private StreamReader? reader;
        private readonly string fileName;
        private int lineNumber;

        public string Name => fileName;

        public FileLineSource(string path, string fileName)
        {
            this.path = path;
            this.fileName = fileName;

        }

        public void Close()
        {
            reader?.Close();
            reader = null;
        }

        public void Open()
        {
            if (reader != null)
            {
                throw new InvalidOperationException();
            }
            lineNumber = 0;
            this.reader = new StreamReader(new FileStream(this.path, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        public Line? ReadLine()
        {
            if (reader == null)
            {
                throw new InvalidOperationException();
            }
            var s = reader.ReadLine();
            if (s == null)
            {
                return null;
            }

            else
            {
                return new Line() { LineNumber = ++lineNumber, Text = s };
            }
        }
    }
}