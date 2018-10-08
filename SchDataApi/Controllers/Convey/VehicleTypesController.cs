using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using SchMod.Models.Convey;
using System.Data;
using System.Data.Common;

namespace SchDataApi.Controllers
{
    [Produces("application/json")]
    [Route("api/VehicleTypes")]
    public class VehicleTypesController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public VehicleTypesController(SchContext context)
        {
            _context = context;
        }

        // GET: api/VehicleTypes
        [HttpGet]
        public IEnumerable<VehicleType> Get(int mdBId)
        {
            List<VehicleType> VehicleTypeList = new List<VehicleType>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT VehicleTypeId, VehicleType FROM VehicleType WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        VehicleType vehType = new VehicleType();
                        if (!kMyReader.IsDBNull(0)) { vehType.VehicleTypeId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { vehType.VehType = kMyReader.GetString(1); }
                        VehicleTypeList.Add(vehType);
                    }
                }
            }
            return VehicleTypeList;
        }

        // GET: api/VehicleTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleType([FromRoute] int vtId, string dSess, int mdBId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync();
            }
            using (var command = conn.CreateCommand())
            {
                MySql = " SELECT VehicleType FROM VehicleType WITH (NOLOCK)";
                MySql = MySql + " WHERE VehicleTypeId = " + vtId;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;

                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    VehicleType vehicleType = new VehicleType();
                    vehicleType.VehicleTypeId = vtId;
                    if (!kMyReader.IsDBNull(0)) { vehicleType.VehType = kMyReader.GetString(0); }
                    return Ok(vehicleType);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // PUT: api/VehicleTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleType([FromRoute] int id, [FromBody] VehicleType vehicleType)
        {
            var vtid = vehicleType.VehicleTypeId;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE VehicleType SET ";
                    MySql = MySql + " VehicleType = '" + vehicleType.VehType + "'";
                    MySql = MySql + " WHERE VehicleTypeID = " + vehicleType.VehicleTypeId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + vehicleType.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(vtid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/VehicleTypes
        [HttpPost]
        public async Task<IActionResult> PostVehicleType([FromBody] VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " INSERT INTO VehicleType (  VehicleTypeId, VehicleType, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + vehicleType.VehType + "'";
                    MySql = MySql + ", 0,'" + vehicleType.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + vehicleType.CTerminal + "'," + vehicleType.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetVehicleType", new { id = vehicleType.VehicleTypeId }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleType = await _context.VehicleType.SingleOrDefaultAsync(m => m.AutoId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            _context.VehicleType.Remove(vehicleType);
            await _context.SaveChangesAsync();

            return Ok(vehicleType);
        }

        private bool VehicleTypeExists(int id)
        {
            return _context.VehicleType.Any(e => e.AutoId == id);
        }
    }
}