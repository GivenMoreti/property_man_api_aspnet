using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManApi.DBContext;
using PropertyManApi.DTO;
using PropertyManApi.Models;

namespace PropertyManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaseController : ControllerBase
    {

        //dependency injection
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public LeaseController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var leases = await _appDbContext
            .Leases
            .ToListAsync();

            var leaseDTOs = _mapper.Map<List<LeaseDTO>>(leases);
            return Ok(leaseDTOs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {

            var lease = await _appDbContext
            .Leases
            .FindAsync(id);

            if (lease == null) return NotFound();

            var leaseDTO = _mapper.Map<LeaseDTO>(lease);
            return Ok(leaseDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateLeaseDTO createLeaseDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lease = _mapper.Map<Lease>(createLeaseDTO);
            _appDbContext.Leases.Add(lease);

            await _appDbContext.SaveChangesAsync();

            var leaseDTO = _mapper.Map<LeaseDTO>(lease);
            return CreatedAtAction(nameof(GetById), new { id = lease.LeaseId }, leaseDTO);
        }


    }

}