using AutoMapper;
using Lab2.WebAPI.DTOs.DepartmentDTOs;
using Lab2.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [EndpointSummary("Retrieves all departments from the database")]
        [EndpointDescription("Example: GET /api/departments")]
        [Produces("application/json")] 
        [ProducesResponseType(200, Type = typeof(PaginatedResult<DepartmentDisplayDTO>))]
        public ActionResult<PaginatedResult<DepartmentDisplayDTO>> GetAll()
        {
            var res = _unitOfWork.DepartmentRepo.GetAll();
            var Items = _mapper.Map<List<DepartmentDisplayDTO>>(res);
            return Ok(Items);
        }

        [HttpPost]
        [EndpointSummary("Creates a new department in the database")]
        [EndpointDescription("Example: POST /api/departments")]
        [Consumes("application/json")] 
        [Produces("application/json")] 
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult CreateDept(DepartmentAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.DeptId <= 0) return BadRequest("Invalid Id");
                var dpt = _mapper.Map<Department>(dto);
                _unitOfWork.DepartmentRepo.Add(dpt);
                _unitOfWork.Complete();
                return Created();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("id")]
        [EndpointSummary("Updates an existing department by ID")]
        [EndpointDescription("Example: PUT /api/departments/{id}")]
        [Consumes("application/json")] 
        [Produces("application/json")] 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult EditDept(int id, DepartmentEditDTO dto)
        {
            if (id != dto.DeptId) return BadRequest();
            var tempDept = _unitOfWork.DepartmentRepo.GetById(id);
            if (tempDept is null) return NotFound();

            if (ModelState.IsValid)
            {
                _mapper.Map(dto, tempDept);
                _unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("id")]
        [EndpointSummary("Deletes a department by ID")]
        [EndpointDescription("Example: DELETE /api/departments/{id}")]
        [Produces("text/html")] 
        [ProducesResponseType(200, Type = typeof(Department))]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            var dept = _unitOfWork.DepartmentRepo.GetById(id);
            if (dept is null) return NotFound("This Department doesn't exist!!");

            _unitOfWork.DepartmentRepo.Delete(dept);
            return Ok(dept);
        }

        [HttpGet("id")]
        [EndpointSummary("Retrieves a department by ID")]
        [EndpointDescription("Example: GET /api/departments/{id}")]
        [Produces("text/html")] 
        [ProducesResponseType(200, Type = typeof(DepartmentDisplayDTO))]
        [ProducesResponseType(404)]
        public ActionResult<DepartmentDisplayDTO> GetById(int id)
        {
            var tempDepartment = _unitOfWork.DepartmentRepo.GetById(id);
            if (tempDepartment is null) return NotFound("this department doesn't exist!!");

            return _mapper.Map<DepartmentDisplayDTO>(tempDepartment);
        }
    }
}