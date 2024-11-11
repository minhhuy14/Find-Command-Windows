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

            var sources = string.IsNullOrEmpty(findOptions.Path) ? new ConsoleLineSource() : new FileLineSource(findOptions.Path);

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