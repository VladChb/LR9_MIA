using Microsoft.AspNetCore.Mvc;
//using BookHubAPI.Data;
using BookHubAPI.Models;
using FluentValidation;
using BookHubAPI.Services;
// mongodb+srv://ChabaniukVladuslav:123456789Vladuslav@cluster0.mrfdr7l.mongodb.net/?appName=Cluster0
namespace BookHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MemberService _service;
        private readonly IValidator<Member> _validator;

        public MembersController(MemberService service, IValidator<Member> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _service.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var member = await _service.GetByIdAsync(id);
            return member != null ? Ok(member) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Member member)
        {
            var validation = _validator.Validate(member);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            await _service.CreateAsync(member);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Member updated)
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
