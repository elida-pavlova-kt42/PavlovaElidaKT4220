using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PavlovaElidaKT4220.Filters.PrepodStepenFilters;
using PavlovaElidaKT4220.Database;
using Microsoft.EntityFrameworkCore;
using PavlovaElidaKT4220.Models;
using PavlovaElidaKT4220.Interfaces.StepenInterfaces;

namespace PavlovaElidaKT4220.Controllers
{
    [ApiController]
    [Route("controller")]
    public class StepenController : Controller
    {
        private readonly ILogger<StepenController> _logger;
        private readonly IStepenService _stepenService;
        private PrepodDbcontext _context;

        public StepenController(ILogger<StepenController> logger, IStepenService stepenService, PrepodDbcontext context)
        {
            _logger = logger;
            _stepenService = stepenService;
            _context = context;
        }

        [HttpPost(Name = "GetPrepodsByStepen")]
        public async Task<IActionResult> GetPrepodByStepenAsync(PrepodStepenFilters filter, CancellationToken cancellationToken = default)
        {
            var stepens = await _stepenService.GetPrepodByStepenAsync(filter, cancellationToken);

            return Ok(stepens);
        }

        [HttpPost("AddStepen", Name = "AddStepen")]
        public IActionResult CreateStepen([FromBody] Stepen stepen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stepen.Add(stepen);
            _context.SaveChanges();
            return Ok(stepen);
        }

        [HttpPut("EditStepen")]
        public IActionResult UpdateStepen(string stepenname, [FromBody] Stepen updatedStepen)
        {
            var existingStepen = _context.Stepen.FirstOrDefault(g => g.StepenName == stepenname);

            if (existingStepen == null)
            {
                return NotFound();
            }

            existingStepen.StepenName = updatedStepen.StepenName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteStepen")]
        public IActionResult DeleteStepen(string stepenname, Stepen updatedStepen)
        {
            var existingStepen = _context.Stepen.FirstOrDefault(g => g.StepenName == stepenname);

            if (existingStepen == null)
            {
                return NotFound();
            }
            _context.Stepen.Remove(existingStepen);
            _context.SaveChanges();

            return Ok();
        }
    }
}
