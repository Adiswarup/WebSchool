using Microsoft.AspNetCore.Mvc;
using SchDataApi.DataLayer;
using SchMod.ViewModels.StdFees;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.StdFunc;

namespace SchDataApi.Controllers.StdFees
{
    [Produces("application/json")]
    [Route("api/FeeForms")]
    public class FeeFormsController : Controller
    {
        private readonly SchContext _context;

        public FeeFormsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/FeeForms
        [HttpGet]
        public IEnumerable<string> GetFeeData(int UniReg)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FeeForms/5
        [HttpGet("{regNum}", Name = "GetStdFee")]
        public async Task<FeeForm> GetAsync([FromRoute] int regNum, string dSess, int mdBId)
        {
            FeeForm feeForm = await getStdDetails(_context, regNum, dSess, mdBId);
                return feeForm;
        }
        
        // POST: api/FeeForms
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/FeeForms/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
