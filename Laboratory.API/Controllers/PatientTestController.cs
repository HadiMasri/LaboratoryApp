using Laboratory.DAL.Entities;
using Laboratory.DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientTestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientTestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Patient_Test> GetAll(int id)
        {
            try
            {
                var allObj = _unitOfWork.PatientTest.GetAll(t => t.Test, p => p.Patient, c => c.Test.Category, g => g.Patient.Gender, f => f.PatientId == id);
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Upsert(Patient_Test patient_Test)
        {
            try
            {
                if (patient_Test.Id == 0)
                {
                    _unitOfWork.PatientTest.Add(patient_Test);
                }
                else
                {
                    _unitOfWork.PatientTest.Update(patient_Test);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Test Added To Patients Successful" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                _unitOfWork.PatientTest.Remove(id);
                _unitOfWork.Save();
                return Json(new { success = true, message = " Deleted Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
