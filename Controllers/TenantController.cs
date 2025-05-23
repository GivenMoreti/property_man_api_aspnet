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
    public class TenantController : ControllerBase
    {
        //dependency injection
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public TenantController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var tenants = await _appDbContext
            .Tenants
            .ToListAsync();

            var tenantDTOs = _mapper.Map<List<TenantDTO>>(tenants);
            return Ok(tenantDTOs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {

            var tenant = await _appDbContext
            .Tenants
            .FindAsync(id);

            if (tenant == null) return NotFound();

            var tenantDTO = _mapper.Map<TenantDTO>(tenant);
            return Ok(tenantDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTenantDTO createTenantDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tenant = _mapper.Map<Tenant>(createTenantDTO);
            _appDbContext.Tenants.Add(tenant);

            await _appDbContext.SaveChangesAsync();

            var tenantDTO = _mapper.Map<TenantDTO>(tenant);
            return CreatedAtAction(nameof(GetById), new { id = tenant.TenantId }, tenantDTO);
        }
    }

}