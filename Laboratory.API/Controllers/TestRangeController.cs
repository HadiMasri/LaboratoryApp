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
    public class TestRangeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestRangeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<TestRange> GetAll(int testId)
        {
            try
            {
                var allObj = _unitOfWork.TestRange.GetAll(t => t.Test, g => g.Gender,null, null, s => s.TestId == testId);
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public IActionResult Upsert(TestRange testRange)
        {
            try
            {
                if (testRange.Id == 0)
                {
                    _unitOfWork.TestRange.Add(testRange);
                }
                else
                {
                    _unitOfWork.TestRange.Update(testRange);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Test Range Added Successful" });
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
                _unitOfWork.TestRange.Remove(id);
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
