using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Blockchain_Framework
{
    internal class Program
    {
        private static readonly List<Block> Blockchain = new List<Block>();
            
        public static void Main(string[] args)
        {
            var firstBlock = new Block("", $"Ich bin der 1te Block");
            AddBlock(firstBlock);

            for (var i = 2; i <= 10; i++)
            {
                var lastBlock = Blockchain.LastOrDefault();
                var hash = CreateSha256Hash(lastBlock);
                var newBlock = new Block(hash, $"Ich bin der {i}te Block");
                AddBlock(newBlock);
            }
        }

        private static void AddBlock(Block block)
        {
            Blockchain.Add(block);
            
            Console.WriteLine();
            Console.WriteLine("------------------ New Block -----------------------");
            Console.WriteLine($"Previous Hash: {block.PreviousBlockHash}");
            Console.WriteLine($"Timestamp: {block.Timestamp}");
            Console.WriteLine($"Message: {block.Message}");
            Console.WriteLine();
                
            // Warte 10 Sekunden
            Thread.Sleep(10000);
        }

        private static string CreateSha256Hash(Block block)
        {
            // Create a SHA256   
            using (var sha256Hash = SHA256.Create())  
            {  
                var blockAsString = $"{block.PreviousBlockHash} {block.Timestamp} {block.Message}";
                var hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(blockAsString));  
  
                // Convert byte array to a string   
                var builder = new StringBuilder();  
                foreach (var hashByte in hashBytes)
                {
                    builder.Append(hashByte.ToString("x2"));
                }  
                return builder.ToString();  
            } 
        }
    }
}