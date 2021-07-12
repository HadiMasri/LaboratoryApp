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
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Patient> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.Patient.GetAll(m => m.Gender, t => t.Title);
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public Patient GetOneById(int id)
        {
            try
            {
                var allObj = _unitOfWork.Patient.GetFirstOrDefault(g => g.Gender , s => s.Id == id);
                return allObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Upsert(Patient patient)
        {
            try
            {
                if (patient.Id == 0)
                {
                    _unitOfWork.Patient.Add(patient);
                }
                else
                {
                    _unitOfWork.Patient.Update(patient);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Patient Added Successful" });
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
                _unitOfWork.Patient.Remove(id);
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
