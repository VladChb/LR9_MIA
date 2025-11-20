using Microsoft.AspNetCore.Mvc;
//using BookHubAPI.Data;
using BookHubAPI.Models;
using FluentValidation;
using BookHubAPI.Services;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;
        private readonly IValidator<Book> _validator;

        public BooksController(BookService service, IValidator<Book> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _service.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var book = await _service.GetByIdAsync(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
             book.Id = null;
        
            var validation = _validator.Validate(book);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            await _service.CreateAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Book updated)
        {
            var validation = _validator.Validate(updated);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            updated.Id = id;
            await _service.UpdateAsync(updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
