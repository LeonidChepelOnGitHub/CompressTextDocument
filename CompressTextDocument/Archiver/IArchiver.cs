using System;

namespace CompressTextDocument.Archiver
{

    public class ProgressEventArgs
    {
        public ProgressEventArgs(int p) { Progress = p; }
        public int Progress { get; private set; } // readonly
    }


    public interface IArhiver
    {
        string ReplaceStartSequenceString { get; set; }
        event Action<object, ProgressEventArgs> OnProgressChanged;
        void Compress(ArhiverInputOptions options);
        void UnCompress(ArhiverOutputOptions options);
    }
}
