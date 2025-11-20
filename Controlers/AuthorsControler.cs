using Microsoft.AspNetCore.Mvc;
//using BookHubAPI.Data;
using BookHubAPI.Models;
using BookHubAPI.Services;
using FluentValidation;

namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _service;
        private readonly IValidator<Author> _validator;

        public AuthorsController(AuthorService service, IValidator<Author> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var author = await _service.GetByIdAsync(id);
            return author != null ? Ok(author) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            var result = _validator.Validate(author);
            if (!result.IsValid) return BadRequest(result.Errors);

            await _service.CreateAsync(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Author updated)
        {
            var result = _validator.Validate(updated);
            if (!result.IsValid) return BadRequest(result.Errors);

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
