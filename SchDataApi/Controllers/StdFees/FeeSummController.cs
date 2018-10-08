using Microsoft.AspNetCore.Mvc;
using SchMod.ViewModels.StdFees;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SchDataApi.GenFunc.GloVar;
using static SchDataApi.GenFunc.StdFunc;
using SchDataApi.DataLayer;

namespace SchDataApi.Controllers.StdFees
{
    [Produces("application/json")]
    [Route("api/FeeSumm")]
    public class FeeSummController : Controller
    {
        private readonly SchContext _context;

        public FeeSummController(SchContext context)
        {
            _context = context;
        }

        // GET: api/FeeSumm
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FeeSumm/5
        [HttpGet("{regNum}", Name = "GetFeeSumm")]
        public async Task<IEnumerable<FeeSumm>> GetAsync([FromRoute] int regNum,string dSess, int mdBId)
        {
            IEnumerable<FeeSumm> feeSumm = await getFeeSumm(_context, regNum, dSess, mdBId);
            return feeSumm;
        }

        // POST: api/FeeSumm
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/FeeSumm/5
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
