using AutoMapper;
using Lab2.WebAPI.DTOs.StudentDTOs;
using Lab2.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        IMapper _autoMapper;
        public StudentsController(IUnitOfWork unitOfwork, IMapper autoMapper)
        {
            _unitOfWork = unitOfwork;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        [EndpointSummary("Retrieves all students from the database")]
        [EndpointDescription("Example: GET /api/students")]
        //[Produces("application/xml")] 
        [ProducesResponseType(200, Type = typeof(List<StudentDisplayDTO>))]
        public ActionResult<List<StudentDisplayDTO>> GetAll()
        {
            var res = _unitOfWork.StudentRepo.GetAll();
            var result = _autoMapper.Map<List<StudentDisplayDTO>>(res);
            return Ok(result);
        }

        [HttpPost]
        [EndpointSummary("Creates a new student in the database")]
        [EndpointDescription("Example: POST /api/students")]
        [Consumes("application/json")] 
        [Produces("application/json")] 
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult CreateStudent(StudentAddDTO std)
        {
            if (ModelState.IsValid)
            {
                var tempDept = _unitOfWork.DepartmentRepo.GetById(std.DeptId);
                var tempSuperStudent = _unitOfWork.StudentRepo.GetById(std.SuperStudentId);
                if (tempSuperStudent == null) return BadRequest("That Super Student doesn't exit");

                if (tempDept is null) return BadRequest("That Department Doesnot exist");

                var student = _autoMapper.Map<Student>(std);
                _unitOfWork.StudentRepo.Add(student);
                _unitOfWork.Complete();
                return Created();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [EndpointSummary("Updates an existing student by ID")]
        [EndpointDescription("Example: PUT /api/students/{id}")]
        [Consumes("application/json")] 
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult EditStudent(int id, StudentEditDTO std)
        {
            if (ModelState.IsValid)
            {
                if (id != std.StId) BadRequest("Cannot update student id");

                var tempstudent = _unitOfWork.StudentRepo.GetById(id);
                if (tempstudent is null)
                {
                    return NotFound("That student doesn't exist");
                }

                var tempDept = _unitOfWork.DepartmentRepo.GetById(std.DeptId);
                var tempSuperStudent = _unitOfWork.StudentRepo.GetById(std.SuperStudentId);
                if (tempSuperStudent == null) return BadRequest("That Super Student doesn't exit");

                if (tempDept is null) return BadRequest("That Department Doesn't exist");

                _autoMapper.Map(std, tempstudent); // std is the source and tempstudent is the destination 
                _unitOfWork.Complete();
                return NoContent();
            }
            return BadRequest("invalid data entry");
        }

        [HttpDelete("{id}")]
        [EndpointSummary("Deletes a student by ID")]
        [EndpointDescription("Example: DELETE /api/students/{id}")]
        //[Produces("text/html")] // Produces HTML
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(404)]
        public ActionResult DeleteStudent(int id)
        {
            var tempStudent = _unitOfWork.StudentRepo.GetById(id);
            if (tempStudent is null) return NotFound();

            _unitOfWork.StudentRepo.Delete(tempStudent);
            _unitOfWork.Complete();

            return Ok(tempStudent);
        }

        [HttpGet("{id}")]
        [EndpointSummary("Retrieves a student by ID")]
        [EndpointDescription("Example: GET /api/students/{id}")]
        //[Produces("text/html")] // Produces HTML
        [ProducesResponseType(200, Type = typeof(StudentDisplayDTO))]
        [ProducesResponseType(404)]
        public ActionResult<StudentDisplayDTO> getById(int id)
        {
            var std = _unitOfWork.StudentRepo.GetById(id);
            if (std is null) return NotFound();

            var stdDto = _autoMapper.Map<StudentDisplayDTO>(std);
            return Ok(stdDto);
        }
    }
}