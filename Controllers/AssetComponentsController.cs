using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildingCommissioningAPI.Data;
using BuildingCommissioningAPI.Models;

namespace BuildingCommissioningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetComponentsController : ControllerBase
    {
        private readonly CommissioningDbContext _context;

        public AssetComponentsController(CommissioningDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetComponent>>> Get()
        {
            return await _context.AssetComponents.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<AssetComponent>> Post(AssetComponent component)
        {
            _context.AssetComponents.Add(component);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = component.Id }, component);
        }
        [HttpPost("SaveComponents")]
        public async Task<IActionResult> SaveComponents([FromBody] List<AssetComponent> components)
        {
            _context.AssetComponents.AddRange(components);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Components saved successfully" });
        }

    }
}
