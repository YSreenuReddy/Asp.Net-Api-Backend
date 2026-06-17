using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCoreEx1.Model;

namespace StudentCoreEx1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly StudentDbContext db;

        public HomeController(StudentDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = db.TblStudents.ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(TblStudent student)
        {
            db.TblStudents.Add(student);
            db.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TblStudent student)
        {
            var existing = db.TblStudents.Find(id);

            if (existing == null)
            {
                return NotFound();
            }
            existing.StudentName = student.StudentName;

            existing.StudentAge = student.StudentAge;

            existing.StudentCourse = student.StudentCourse;

            db.SaveChanges();
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = db.TblStudents.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            db.TblStudents.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }
    }
}
