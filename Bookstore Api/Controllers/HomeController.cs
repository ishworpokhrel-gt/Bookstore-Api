using Bookstore_Api.Data;
using Bookstore_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Bookstore_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Books.ToList());
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult Getbyid([FromRoute] int id)
        {
            var books = _db.Books.FirstOrDefault(u => u.Id == id);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[controller]")]

        public IActionResult Push(PostModel book)
        {
            var data = new Book()
            {
                Author = book.Author,
                Title = book.Title,
                price = book.price
            };
            _db.Books.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult updateAll([FromRoute] int id, PostModel book)
        {
            var data = _db.Books.FirstOrDefault(u => u.Id == id);
            if (data != null)
            {
                data.price = book.price;
                data.Author = book.Author;
                data.Title = book.Title;
                _db.Books.Update(data);
                _db.SaveChanges();
                return Ok(data);
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]

        public IActionResult deleteall([FromRoute] int id) 
        { 
            var data=_db.Books.FirstOrDefault(u=>u.Id==id);
            if (data!=null)
            {
                _db.Books.Remove(data);
                _db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


    }
}
