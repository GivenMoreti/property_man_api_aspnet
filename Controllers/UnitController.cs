
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManApi.DBContext;
using PropertyManApi.DTO;
using PropertyManApi.Models;

namespace PropertyManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public UnitController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //include the leases it has and 
            // maintenance requests
            var units = await _appDbContext
            .Units
            .Include(u => u.Leases)
            .Include(u => u.MaintenanceRequests)
            .ToListAsync();

            var unitDTOs = _mapper.Map<List<UnitDTO>>(units);
            return Ok(unitDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            //include the leases it has and 
            // maintenance requests
            var unit = await _appDbContext.Units
            .Include(u => u.Leases)
            .ThenInclude(l => l.Tenant)
            .Include(u => u.MaintenanceRequests)
            .FirstOrDefaultAsync(u => u.UnitId == id);

            if (unit == null) return NotFound();

            var unitDTO = _mapper.Map<UnitDTO>(unit);
            return Ok(unitDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUnitDTO createUnitDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var unit = _mapper.Map<Unit>(createUnitDTO);
            _appDbContext.Units.Add(unit);

            await _appDbContext.SaveChangesAsync();

            var unitDTO = _mapper.Map<UnitDTO>(unit);
            return CreatedAtAction(nameof(GetById), new { id = unit.UnitId }, unitDTO);
        }

    }

}