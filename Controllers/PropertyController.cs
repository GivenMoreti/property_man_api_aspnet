using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManApi.DBContext;
using PropertyManApi.DTO;
using PropertyManApi.Models;

namespace PropertyManApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        ///
        //dependency injection
        ///
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public PropertyController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        //get all properties
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            // var properties = await _appDbContext.Properties.ToListAsync();
            //this includes the units of this property
            var properties = await _appDbContext.Properties
            .Include(p => p.Units)
            .ToListAsync();

            var propertyDtos = _mapper.Map<List<PropertyDTO>>(properties);
            return Ok(propertyDtos);
        }

        //get property by its id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var property = await _appDbContext.Properties
        .Include(p => p.Units)
        .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (property == null) return NotFound();

            //convert found property to dto before returning it to user
            var dto = _mapper.Map<PropertyDTO>(property);
            return Ok(dto);
        }

        //create property
        [HttpPost]
        public async Task<ActionResult> Create(CreatePropertyDTO createPropertyDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //
            var property = _mapper.Map<Property>(createPropertyDTO);
            _appDbContext.Properties.Add(property);

            await _appDbContext.SaveChangesAsync();

            var dto = _mapper.Map<PropertyDTO>(property);
            return CreatedAtAction(nameof(GetById), new { id = property.PropertyId }, dto);

        }


        //update property 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePropertyDTO updatePropertyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingProperty = await _appDbContext.Properties.FindAsync(id);
            if (existingProperty == null)
            {
                return NotFound(new { Message = $"Property with ID {id} not found." });
            }

            _mapper.Map(updatePropertyDTO, existingProperty);
            _appDbContext.Properties.Update(existingProperty);
            await _appDbContext.SaveChangesAsync();
            return NoContent(); // 204


        }


        //delete property from db
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var property = await _appDbContext.Properties
                .Include(p => p.Units) // Optional: prevent FK constraint violation
                .FirstOrDefaultAsync(p => p.PropertyId == id);

            if (property == null)
            {
                return NotFound(new { Message = $"Property with ID {id} not found." });
            }

            // Optional: Check for related data like Units or Leases
            if (property.Units != null && property.Units.Any())
            {
                return Conflict(new
                {
                    Message = "Cannot delete property because it has associated units."
                });
            }

            _appDbContext.Properties.Remove(property);

            try
            {
                await _appDbContext.SaveChangesAsync();
                return NoContent(); // Returns HTTP 204
            }
            catch (Exception ex)
            {
                // Log the exception here in real applications
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "An error occurred while deleting the property.",
                    Error = ex.Message
                });
            }
        }
    }

}