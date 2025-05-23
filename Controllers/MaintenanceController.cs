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
    public class MaintenanceController : ControllerBase
    {
        //dependency injection
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MaintenanceController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var maintenanceRequests = await _appDbContext
            .MaintenanceRequests
            .ToListAsync();

            var maintenanceRequestsDTOs = _mapper.Map<List<MaintenanceRequestDTO>>(maintenanceRequests);
            return Ok(maintenanceRequestsDTOs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {

            var maintenanceRequest = await _appDbContext
            .MaintenanceRequests
            .FindAsync(id);

            if (maintenanceRequest == null) return NotFound();

            var maintenanceRequestDTO = _mapper.Map<MaintenanceRequestDTO>(maintenanceRequest);
            return Ok(maintenanceRequestDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMaintenanceRequestDTO createMaintenanceRequestDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var maintenanceRequest = _mapper.Map<MaintenanceRequest>(createMaintenanceRequestDTO);
            _appDbContext.MaintenanceRequests.Add(maintenanceRequest);

            await _appDbContext.SaveChangesAsync();

            var maintenanceRequestDTO = _mapper.Map<MaintenanceRequestDTO>(maintenanceRequest);
            return CreatedAtAction(nameof(GetById), new { id = maintenanceRequest.MaintenanceRequestId }, maintenanceRequestDTO);
        }
    }

}