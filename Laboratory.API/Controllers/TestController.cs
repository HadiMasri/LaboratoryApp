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
    public class TestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Test> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.Test.GetAll(t => t.Category, u => u.Unit);
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Upsert(Test test)
        {
            try
            {
                if (test.Id == 0)
                {
                    _unitOfWork.Test.Add(test);
                }
                else
                {
                    _unitOfWork.Test.Update(test);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Test Added Successful" });
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
                _unitOfWork.Test.Remove(id);
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
