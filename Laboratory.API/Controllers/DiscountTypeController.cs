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
    public class DiscountTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<DiscountType> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.DiscountType.GetAll();
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
