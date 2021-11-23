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
    public class SettingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Setting> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.Setting.GetAll();
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Upsert(Setting setting)
        {
            try
            {
                if (setting.Id == 0)
                {
                    _unitOfWork.Setting.Add(setting);
                }
                else
                {
                    _unitOfWork.Setting.Update(setting);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Setting Added Successful" });
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
                _unitOfWork.Setting.Remove(id);
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
