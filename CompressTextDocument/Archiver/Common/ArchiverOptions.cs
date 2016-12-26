namespace CompressTextDocument.Archiver
{
    public class ArhiverInputOptions
    {
        public string File { get; set; }
        public string Destination { get; set; }
        public int DictionarySize { get; set; }
        public int MaxWordSize { get; set; }
        public bool CompressRepeating { get; set; }
        public bool FromMinToMax { get; set; }
        public bool DebugMode { get; set; }
    }

    public class ArhiverOutputOptions
    {
        public string File { get; set; }
        public string Destination { get; set; }
        
    }
}
