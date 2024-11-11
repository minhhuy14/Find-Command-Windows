namespace HFind
{
    internal class FilteredLineSource : ILineSource
    {
        private readonly ILineSource parent;
        private readonly Func<Line, bool> f;

        public FilteredLineSource(ILineSource parent, Func<Line, bool> f)
        {
            this.parent = parent ?? throw new ArgumentException(nameof(parent));
            this.f = f;
        }

        public string Name => parent.Name;

        public void Close()
        {
            parent.Close();
        }

        public void Open()
        {
            parent.Open();
        }

        public Line? ReadLine()
        {
            if (f == null)
            {
                return parent.ReadLine();
            }
            var line = parent.ReadLine();
            if (line == null)
            {
                return null;
            }
            else
            {
                while (line != null && f(line) == false)
                {
                    line = parent.ReadLine();
                }
                return line;
            }
        }
    }
}
