using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDAPI.Models;

namespace CRUDAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        private CipDbEntities db = new CipDbEntities();

        // GET: api/Departments
        [HttpGet]
        [Route("api/Departments/GetDepartments")]
        public IQueryable<Department> GetDepartments()
        {
            return db.Departments;
        }

        // GET: api/Departments/5
        //[ResponseType(typeof(Department))]
        [HttpGet]
        [Route("api/Departments/GetDepartmentById/{id}")]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        //[ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/Departments/UpdateDepartment")]
        public IHttpActionResult PutDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            db.Entry(department).State = EntityState.Modified;

            try
            {
                Department objDepartment = new Department();
                objDepartment = db.Departments.Find(department.Id);
                if (objDepartment != null)
                {
                    objDepartment.Name = department.Name;
                    objDepartment.Description = department.Description;                   
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Departments        
        [HttpPost]
        [Route("api/Departments/InsertDepartment")]
        //[ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departments.Add(department);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);

            return Ok(department);
        }

        // DELETE: api/Departments/5
        [HttpPost]
        [Route("api/Departments/DeleteDepartment/{id}")]
        //[ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.Id == id) > 0;
        }
    }
}