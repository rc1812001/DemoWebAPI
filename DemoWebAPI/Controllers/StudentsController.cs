using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Model;
using Model.DBModels;
using Model.RequestModels;
using Model.ResponseModels;

namespace DemoWebAPI.Controllers
{
    /// <summary>
    /// CRUD operations using DB    
    /// </summary>
    [ApiController]
    [Route("Students/api")]
    public class StudentsController : ControllerBase
    {
        private readonly ApidemoContext _context;  //DB context for Request and Response

        /// <summary>
        /// Created constructor for students controller
        /// </summary>
        /// <param name="context"></param>
        public StudentsController(ApidemoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>


        [HttpGet]

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            #region 
            // fetch data from db
            List<StudentDTO> students = await _context.StudentTables.Select(s => new StudentDTO()
            {

                ID = s.StudentId,
                Name = s.StudentName,
                MobileNumber = s.MobileNumber,
                City = s.City,
            }).ToListAsync();
            #endregion
            return students;
        }

        /// <summary>
        /// Get StudentDetails By ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetailsByUserId(int id)
        {
            var existingStudent = await _context.StudentTables.FirstOrDefaultAsync(u => u.StudentId == id);

            if (existingStudent != null)
            {
                StudentDTO studentDTO = new StudentDTO()
                {
                    ID = existingStudent.StudentId,
                    Name = existingStudent.StudentName,
                    MobileNumber = existingStudent.MobileNumber,
                    City = existingStudent.City,

                };
                return Ok(studentDTO);
            }
            return BadRequest();
        }
        /// <summary>
        /// Create student
        /// </summary>
        /// <param name="studentCreateRequest"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<StudentDTO> CreateStudent(StudentCreateRequest studentCreateRequest)
        {
            StudentTable studentTable = new StudentTable()
            {

                StudentName = studentCreateRequest.Name,
                MobileNumber = studentCreateRequest.MobileNumber,
                City = studentCreateRequest.City,
            };

            _context.StudentTables.Add(studentTable);
            await _context.SaveChangesAsync();

            StudentDTO studentDTO = new StudentDTO()
            {
                ID = studentTable.StudentId,
                MobileNumber = studentTable.MobileNumber,
                Name = studentTable.StudentName,
                City = studentTable.City,
            };

            return studentDTO;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="studentDTO"></param>
        /// <returns></returns>

        [HttpPut("update/{ID}")]
        public async Task<StudentDTO> StudentUpdateRequest(int ID, StudentDTO studentDTO)
        {
            var existingStudent = _context.StudentTables.Where(i => i.StudentId == studentDTO.ID).FirstOrDefault<StudentTable>();

            if (existingStudent != null)
            {
                existingStudent.StudentName = studentDTO.Name;
                existingStudent.MobileNumber = studentDTO.MobileNumber;
                existingStudent.City = studentDTO.City;

                await _context.SaveChangesAsync();
            }
            else
            {
                return studentDTO;
            }
            return studentDTO;
        }
        /// <summary>
        /// To delete existing user
        /// </summary>
        /// <param name="id">Provide UserId here</param>
        /// <returns></returns>

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid userid");
            }

            StudentTable studentTable = await _context.StudentTables.FirstOrDefaultAsync(u => u.StudentId == id);
            if (studentTable != null)
            {
                _context.StudentTables.Remove(studentTable);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}

