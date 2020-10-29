using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDAPI.Models;

namespace CRUDAPI.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
        private CipDbEntities db = new CipDbEntities();

        // GET: api/EmployeeDetails
        [HttpGet]
        [Route("api/EmployeeDetails/AllEmployeeDetails")]
        public IQueryable<EmployeeDetail> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: api/EmployeeDetails/5        
        //[ResponseType(typeof(EmployeeDetail))]
        [HttpGet]
        [Route("api/EmployeeDetails/GetEmployeeDetailsById/{id}")]
        public IHttpActionResult GetEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return Ok(employeeDetail);
        }

        // PUT: api/EmployeeDetails/5
        //[ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/EmployeeDetails/UpdateEmployeeDetails")]
        public IHttpActionResult PutEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(employeeDetail).State = EntityState.Modified;
           
            try
            {
                EmployeeDetail objEmp = new EmployeeDetail();
                objEmp = db.EmployeeDetails.Find(employeeDetail.EmpId);
                if (objEmp != null)
                {
                    objEmp.EmpName = employeeDetail.EmpName;
                    objEmp.Address = employeeDetail.Address;
                    objEmp.EmailId = employeeDetail.EmailId;
                    objEmp.DateOfBirth = employeeDetail.DateOfBirth;
                    objEmp.Gender = employeeDetail.Gender;
                    objEmp.PinCode = employeeDetail.PinCode;
                }

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(employeeDetail.EmpId))
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

        // POST: api/EmployeeDetails
        [HttpPost]
        [Route("api/EmployeeDetails/InsertEmployeeDetails")]
        //[ResponseType(typeof(EmployeeDetail))]
        public IHttpActionResult PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetails.Add(employeeDetail);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = employeeDetail.EmpId }, employeeDetail);
            return Ok(employeeDetail);
        }

        // DELETE: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetail))]
        public IHttpActionResult DeleteEmployeeDetail(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();

            return Ok(employeeDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailExists(int id)
        {
            return db.EmployeeDetails.Count(e => e.EmpId == id) > 0;
        }
    }
}