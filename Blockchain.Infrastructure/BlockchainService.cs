using Blockchain.Domain.Model;

namespace Blockchain.Infrastructure
{
    public class BlockchainService
    {
        private readonly List<Block> _blockchain;

        public BlockchainService()
        {
            _blockchain = new List<Block>();
            InitializeBlockchain();
        }

        private void InitializeBlockchain()
        {
            Console.WriteLine("Blockchain initialized");
            _blockchain.Add(Block.CreateGenesisBlock());
        }

        public IEnumerable<Block> GetBlockchain()
        {
            return _blockchain;
        }

        public void AddBlock(List<Transaction> transactions)
        {
            var latestBlock = _blockchain.Last();
            var newBlock = Block.CreateNewBlock(transactions, latestBlock);
            _blockchain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            Console.WriteLine($"Blockchain count: {_blockchain.Count}");
            for (int i = 1; i < _blockchain.Count; i++)
            {
                if (!_blockchain[i].IsValid())
                {
                    Console.WriteLine($"{i} not valid");
                    return false;
                }
            }
            return true;
        }
    }
}
