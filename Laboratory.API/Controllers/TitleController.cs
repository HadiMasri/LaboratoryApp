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
    public class TitleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TitleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Title> GetAll()
        {
            try
            {
                var allObj = _unitOfWork.Title.GetAll();
                return allObj.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
