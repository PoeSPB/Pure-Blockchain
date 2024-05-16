using System.Text;
using System.Security.Cryptography;

namespace Blockchain.Domain.Model
{
    public class Block
    {
        public int Index { get; set; } // Номер блока в цепочке
        public DateTime Timestamp { get; set; } // Время создания блока
        public List<Transaction> Transactions { get; set; } // Список транзакций в блоке
        public string PreviousHash { get; set; } // Хэш предыдущего блока в цепочке
        public string Hash { get; set; } // Хэш текущего блока

        private Block(int index, DateTime timestamp, List<Transaction> transactions, string previousHash)
        {
            Index = index;
            Timestamp = timestamp;
            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        public static Block CreateGenesisBlock()
        {
            return new Block(0, DateTime.Now, new List<Transaction>(), "0");
        }

        public static Block CreateNewBlock(List<Transaction> transactions, Block previousBlock)
        {
            int newIndex = previousBlock.Index + 1;
            DateTime newTimestamp = DateTime.Now;
            return new Block(newIndex, newTimestamp, transactions, previousBlock.Hash);
        }

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string data = $"{Index}-{Timestamp}-{PreviousHash}-{string.Join(",", Transactions)}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool IsValid()
        {
            Console.WriteLine($"===[ Checking valid ]===");
            Console.WriteLine($"Current  hash     : \"{Hash}\"");
            Console.WriteLine($"Recalc   hash     : \"{CalculateHash()}\"");
            Console.WriteLine($"------------------------");
            Console.WriteLine($"Previous hash     : \"{PreviousHash}\"");
            Console.WriteLine($"Previous hash from: \"{Transactions.Last().From}\"");
            Console.WriteLine($"========================");
            if (Hash == CalculateHash() && PreviousHash == Transactions.Last().From)
            { 
                return true; 
            }
            else 
                return false;
            //return Hash == CalculateHash() && PreviousHash == Transactions.Last().From;
        }
    }
}
