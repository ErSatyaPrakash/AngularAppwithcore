using Microsoft.AspNetCore.Mvc;

namespace AngularAppwithcore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // Sample fruit list
        public static List<Fruit> fruits = new List<Fruit>
        {
            new Fruit { Name = "Apple", Color = "Red", Taste = "Sweet" },
            new Fruit { Name = "Banana", Color = "Yellow", Taste = "Sweet" },
            new Fruit { Name = "Cherry", Color = "Red", Taste = "Sweet and Tart" },
            new Fruit { Name = "Date", Color = "Brown", Taste = "Very Sweet" },
            new Fruit { Name = "Elderberry", Color = "Dark Purple", Taste = "Tart" },
            new Fruit { Name = "Fig", Color = "Purple", Taste = "Mildly Sweet" },
            new Fruit { Name = "Grapes", Color = "Green or Purple", Taste = "Sweet or Tart" },
            new Fruit { Name = "Kiwi", Color = "Brown (outside), Green (inside)", Taste = "Tangy and Sweet" },
            new Fruit { Name = "Mango", Color = "Yellow-Orange", Taste = "Juicy and Sweet" },
            new Fruit { Name = "Orange", Color = "Orange", Taste = "Citrusy and Sweet" }
        };

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> Get()
        {
            return Ok(fruits);
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public ActionResult<Fruit> Get(int id)
        {
            if (id < 0 || id >= fruits.Count)
                return NotFound();
            return Ok(fruits[id]);
        }

        // POST: api/values
        [HttpPost]
        public ActionResult Post([FromBody] Fruit fruit)
        {
            if (fruit == null || string.IsNullOrEmpty(fruit.Name))
                return BadRequest("Invalid fruit data.");

            fruits.Add(fruit);
            return CreatedAtAction(nameof(Get), new { id = fruits.Count - 1 }, fruit);
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Fruit fruit)
        {
            if (id < 0 || id >= fruits.Count)
                return NotFound();

            if (fruit == null || string.IsNullOrEmpty(fruit.Name))
                return BadRequest("Invalid fruit data.");

            fruits[id] = fruit;
            return NoContent();
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= fruits.Count)
                return NotFound();

            fruits.RemoveAt(id);
            return NoContent();
        }

        // GET: api/values/search?query=apple
        [HttpGet("search")]
        public ActionResult<IEnumerable<Fruit>> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return BadRequest("Query cannot be null or empty.");

            var results = fruits.Where(f => f.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!results.Any())
                return NotFound("No matching fruits found.");

            return Ok(results);
        }

        // GET: api/values/random
        [HttpGet("random")]
        public ActionResult<Fruit> GetRandomFruit()
        {
            if (!fruits.Any())
                return NotFound("No fruits available.");

            var random = new Random();
            int index = random.Next(fruits.Count);
            return Ok(fruits[index]);
        }

        // GET: api/values/count
        [HttpGet("count")]
        public ActionResult<int> GetFruitCount()
        {
            return Ok(fruits.Count);
        }

        // GET: api/values/contains?value=apple
        [HttpGet("contains")]
        public ActionResult<bool> ContainsFruit(string value)
        {
            if (string.IsNullOrEmpty(value))
                return BadRequest("Value cannot be null or empty.");

            bool contains = fruits.Any(f => f.Name.Equals(value, StringComparison.OrdinalIgnoreCase));
            return Ok(contains);
        }
    }
}
