using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularAppwithcore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Cherry",
            "Date",
            "Elderberry"
        };
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return fruits;
        }
        // GET: api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= fruits.Count)
            {
                return NotFound();
            }
            return fruits[id];
        }
        // POST: api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty.");
            }
            fruits.Add(value);
            return CreatedAtAction(nameof(Get), new { id = fruits.Count - 1 }, value);
        }
        // PUT: api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= fruits.Count)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty.");
            }
            fruits[id] = value;
            return NoContent();
        }
        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= fruits.Count)
            {
                return NotFound();
            }
            fruits.RemoveAt(id);
            return NoContent();
        }
        // GET: api/values/search?query=apple
        [HttpGet("search")]
        public ActionResult<IEnumerable<string>> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Query cannot be null or empty.");
            }
            var results = fruits.Where(f => f.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!results.Any())
            {
                return NotFound("No matching fruits found.");
            }
            return results;
        }
        // GET: api/values/random
        [HttpGet("random")]
        public ActionResult<string> GetRandomFruit()
        {
            if (!fruits.Any())
            {
                return NotFound("No fruits available.");
            }
            var random = new Random();
            int index = random.Next(fruits.Count);
            return fruits[index];
        }
        // GET: api/values/count
        [HttpGet("count")]
        public ActionResult<int> GetFruitCount()
        {
            return fruits.Count;
        }
        // GET: api/values/contains?value=apple
        [HttpGet("contains")]
            
        public ActionResult<bool> ContainsFruit(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty.");
            }
            bool contains = fruits.Any(f => f.Equals(value, StringComparison.OrdinalIgnoreCase));
            return contains;
        }
        
        

    }
}
