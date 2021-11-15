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
    public class MaterialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Material> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.Material.GetAll();
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public Material GetOneById(int id)
        {
            try
            {
                var allObj = _unitOfWork.Material.GetFirstOrDefault(s => s.Id == id);
                return allObj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Upsert(Material material)
        {
            try
            {
                if (material.Id == 0)
                {
                    _unitOfWork.Material.Add(material);
                }
                else
                {
                    _unitOfWork.Material.Update(material);
                }
                _unitOfWork.Save();
                return Json(new { success = true, message = "Material Added Successful" });
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
                _unitOfWork.Material.Remove(id);
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
