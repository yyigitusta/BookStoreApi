using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private static readonly List<string> books = new()
        {
            "CleanCode","C# in Depth","Desing Patterns"
        };

        [HttpGet]
        public IActionResult Get() => Ok(books);

        [HttpPost]
        public IActionResult Post([FromBody] string title)
        {
            books.Add(title);
            return CreatedAtAction(nameof(Get), new { }, books);
        }
        [HttpGet("count")]
        public IActionResult Count() => Ok(books.Count);
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= books.Count)
            {
                return NotFound();
            }
            books.RemoveAt(id);
            return NoContent();
        }
    }
}
