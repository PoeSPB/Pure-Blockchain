using Microsoft.AspNetCore.Mvc;
using Blockchain.Infrastructure;
using Blockchain.Domain.Model;

namespace Blockchain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainController : ControllerBase
    {
        private readonly BlockchainService _blockchainService;

        public BlockchainController(BlockchainService blockchainService)
        {
            Console.WriteLine("Construct Blockchain");
            _blockchainService = blockchainService;
        }

        // Метод для получения всей цепочки блоков
        [HttpGet]
        public ActionResult<IEnumerable<Block>> GetBlockchain()
        {
            return Ok(_blockchainService.GetBlockchain());
        }

        // Метод для добавления нового блока в цепочку
        [HttpPost]
        public ActionResult AddBlock(List<Transaction> transactions)
        {
            Console.WriteLine("Trying to add block to Blockchain");
            try
            {
                _blockchainService.AddBlock(transactions);
                Console.WriteLine("Successfully added new block to Blockchain");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Метод для проверки целостности цепочки блоков
        [HttpGet("validate")]
        public ActionResult<bool> IsBlockchainValid()
        {
            return Ok(_blockchainService.IsChainValid());
        }
        /*

        // GET: api/<BlockchainController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BlockchainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlockchainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlockchainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlockchainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
