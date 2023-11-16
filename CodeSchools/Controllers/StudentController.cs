using CodeSchools.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeSchools.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly CodeSchoolDbContext dbContext;
        public StudentController(CodeSchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = (
                from master in this.dbContext.Student_master
                from details in this.dbContext.Student_details
                where master.Id == details.Student_master_id
                select new
                {
                    Student_id = master.Id,
                    Name = master.Name,
                    Address = details.Address,
                    Phone = details.Phone,
                    Dob = details.Dob
                }).ToList();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student payload)
        {
            var masterData = new StudentMaster
            {
                Name = payload.Name,
                Student_details = new StudentDetails
                {
                    Address = payload.Address,
                    Phone = payload.Phone,
                    Dob = payload.Dob
                }
            };
            this.dbContext.Add(masterData);
            this.dbContext.SaveChanges();
            return Created("201", payload);
        }
    }
}
