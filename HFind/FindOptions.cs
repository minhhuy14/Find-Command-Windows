﻿namespace HFind
{
    public class FindOptions
    {
        public string StringToFind { get; set; } = string.Empty;
        public bool IsCaseSensitive { get; set; } = true;
        public bool FindDontConstain { get; set; } = false;
        public bool CountMode { get; set; } = false;
        public bool ShowLineNumber { get; set; } = false;
        public bool SkipOffLineFiles { get; set; } = true;

        public string Path { get; set; } = string.Empty;
        public bool HelpMode { get; set; } = false;





    }
}
