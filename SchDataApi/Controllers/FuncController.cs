using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchDataApi.DataLayer;
using static SchDataApi.GenFunc.BasicListFunc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchMod.Models.Studs;
using static SchDataApi.GenFunc.StdFunc;

namespace SchDataApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class FuncController : Controller
    {
        private readonly SchContext _context;

       public FuncController(SchContext context)
        {
            _context = context;

        }
        [HttpGet]
        [ActionName("GetSchClss")]
        public  List<SelectListItem> GetSchClss( string dSess, int mdBId)
        {
            return  GetSchClssF(_context, dSess, mdBId);
        }
        [HttpGet]
        [ActionName("GetFeeCat")]
        public List<SelectListItem> GetFeeCat(string dSess, int mdBId)
        {
            return GetFeeCatF(_context, dSess, mdBId);
        }

        [HttpGet]
        [ActionName("GetStdFeeName")]
        public List<SelectListItem> GetStdFeeName(string clss,string  tSess,string  stdFeeCat,string dSess, int mdBId)
        {
            return GetStdFeeNameF(_context,clss,tSess,stdFeeCat, dSess, mdBId);
        }

        [HttpGet]
        [ActionName("GetStdFeeDate")]
        public DateTime GetStdFeeDate(string clss,string  tSess, string stdFeeCat, string stdFeeCap, string dSess, int mdBId)
        {
            return GetStdFeeDateF(_context,clss,tSess, stdFeeCat, stdFeeCap, dSess, mdBId);
        }

        [HttpPut]
        [ActionName("CreateStd")]
        public async Task CreateStdAsync([FromBody] Students stds)
        {
            await CreateStdFAsync(_context, stds);
        }
        [HttpGet]
        [ActionName("getStdGenEdit")]
        public async Task<Students> GetStdGenEditAsync(int regNum, string dSess, int mdBId)
        {
            return await getStdGenEdit(_context, regNum, dSess, mdBId);
        }
        [HttpPost]
        [ActionName("saveEditGen")]
        public async Task<Students> SaveEditGenAsync([FromBody] Students students)
        {
           return await  GenFunc.StdFunc.SaveEditGenAsync(_context, students);
        }

        [HttpGet]
        [ActionName("getStdAddressEdit")]
        public async Task<Students> getStdAddressEditAsync(int regNum, string dSess, int mdBId)
        {
            return await getStdAddressEdit(_context, regNum, dSess, mdBId);
        }

        [HttpPost]
        [ActionName("saveEditAddress")]
        public async Task<Students> SaveEditAddressAsync([FromBody] Students students)
        {
            return await GenFunc.StdFunc.SaveEditAddressAsync(_context, students);
        }

        [HttpGet]
        [ActionName("getStdFamilyEdit")]
        public async Task<Students> getStdFamilyEditAsync(int regNum, string dSess, int mdBId)
        {
            return await getStdFamilyEdit(_context, regNum, dSess, mdBId);
        }

        [HttpPost]
        [ActionName("saveEditFamily")]
        public async Task<Students> SaveEditFamilyAsync([FromBody] Students students)
        {
            return await GenFunc.StdFunc.SaveEditFamilyAsync(_context, students);
        }

        [HttpGet]
        [ActionName("getStdHealthEdit")]
        public async Task<Students> getStdHealthEditAsync(int regNum, string dSess, int mdBId)
        {
            return await getStdHealthEdit(_context, regNum, dSess, mdBId);
        }

        [HttpPost]
        [ActionName("saveEditHealth")]
        public async Task<Students> SaveEditHealthAsync([FromBody] Students students)
        {
            return await GenFunc.StdFunc.SaveEditHealthAsync(_context, students);
        }

    }
}