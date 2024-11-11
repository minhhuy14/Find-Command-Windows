namespace HFind
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("");
                return;
            }
            var findOptions = BuildOptions(args);

            if (findOptions.HelpMode)
            {
                Console.WriteLine("Usage: HFind [options] <string to find> <path>");
                Console.WriteLine("Options:");
                Console.WriteLine("  /v - find lines that don't contain the string");
                Console.WriteLine("  /c - count the number of lines that contain the string");
                Console.WriteLine("  /n - show line numbers");
                Console.WriteLine("  /i - case insensitive search");
                Console.WriteLine("  /off - search offline files");
                Console.WriteLine("  /? - show help");
                return;
            }
            var sources = LineSourceFactory.CreateInstance(findOptions.Path, findOptions.SkipOffLineFiles);

            foreach (var source in sources)
            {
                ProcessSource(source, findOptions);
            }

        }

        private static void ProcessSource(ILineSource source, FindOptions findOptions)
        {
            var stringComparison = findOptions.IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            source = new FilteredLineSource(source, (line) => findOptions.FindDontConstain ? !line.Text.Contains(findOptions.StringToFind) : line.Text.Contains(findOptions.StringToFind));
            Console.WriteLine($"-------------------- {source.Name.ToUpper()}------------------");
            Console.WriteLine("---------------------Search Results-------------------".ToUpper());
            try
            {
                source.Open();
                var line = source.ReadLine();
                while (line != null)
                {
                    Print(line, findOptions.ShowLineNumber);
                    line = source.ReadLine();
                }
            }
            finally
            {
                source.Close();

            }

        }

        private static void Print(Line line, bool printLineNumber)
        {
            if (printLineNumber)
            {
                Console.WriteLine($"[{line.LineNumber}] {line.Text}");
            }
            else
            {
                Console.WriteLine(line.Text);
            }
        }

        public static FindOptions BuildOptions(string[] args)
        {
            var options = new FindOptions();
            foreach (var arg in args)
            {
                if (arg == "/v")
                {
                    options.FindDontConstain = true;
                }
                else if (arg == "/c")
                {
                    options.CountMode = true;
                }
                else if (arg == "/n")
                {
                    options.ShowLineNumber = true;
                }
                else if (arg == "/i")
                {
                    options.IsCaseSensitive = false;
                }
                else if (arg == "/off" || arg == "/offline")
                {
                    options.SkipOffLineFiles = false;
                }
                else if (arg == "/?")
                {
                    options.HelpMode = true;
                }
                else
                {
                    if (string.IsNullOrEmpty(options.StringToFind))
                    {
                        options.StringToFind = arg;
                    }
                    else if (string.IsNullOrEmpty(options.Path))
                    {
                        options.Path = arg;
                    }
                    else
                    {
                        throw new ArgumentException(arg);
                    }

                }
            }

            return options;
        }
    }
}