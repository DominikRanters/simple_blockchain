using System;

namespace Blockchain_Framework
{
    public class Block
    {
        public Block(string previousBlockHash, string message)
        {
            PreviousBlockHash = previousBlockHash;
            Message = message;
        }

        public string PreviousBlockHash { get; set; }
        public DateTime Timestamp = DateTime.Now;
        public string Message { get; set; }
    }
}