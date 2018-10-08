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
    [Route("api/VehicleDescriptions")]
    public class VehicleDescriptionsController : Controller
    {
        private String MySql;
        private readonly SchContext _context;

        public VehicleDescriptionsController(SchContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDescriptions
        [HttpGet]
        public IEnumerable<VehicleDescription> Get (int mdBId)
        {
            List<VehicleDescription> VehicleDescList = new List<VehicleDescription>();
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {

                MySql = " SELECT  VehicleID, VehicleName, VehicleType, vDriver, vNumber, DriverAddress, DriverDetails,"
                    + "VehicleDetails, ContactPhone, Capacity, Circuit FROM VehicleDescription WITH (NOLOCK)";
                MySql = MySql + " WHERE  Dormant = 0";
                MySql = MySql + " AND dBID = " + mdBId;
                MySql = MySql + " AND VehicleID > 0";
                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = command.ExecuteReader();
                if (kMyReader.HasRows)
                {
                    while (kMyReader.Read())
                    {
                        VehicleDescription vehDesc = new VehicleDescription();
                        if (!kMyReader.IsDBNull(0)) { vehDesc.VehicleId = kMyReader.GetInt32(0); }
                        if (!kMyReader.IsDBNull(1)) { vehDesc.VehicleName = kMyReader.GetString(1); }
                        if (!kMyReader.IsDBNull(2)) { vehDesc.VehicleType = kMyReader.GetString(2); }
                        if (!kMyReader.IsDBNull(3)) { vehDesc.VDriver = kMyReader.GetString(3); }
                        if (!kMyReader.IsDBNull(4)) { vehDesc.VNumber = kMyReader.GetString(4); }
                        if (!kMyReader.IsDBNull(5)) { vehDesc.DriverAddress = kMyReader.GetString(5); }
                        if (!kMyReader.IsDBNull(6)) { vehDesc.DriverDetails = kMyReader.GetString(6); }
                        if (!kMyReader.IsDBNull(7)) { vehDesc.VehicleDetails = kMyReader.GetString(7); }
                        if (!kMyReader.IsDBNull(8)) { vehDesc.ContactPhone = kMyReader.GetString(8); }
                        if (!kMyReader.IsDBNull(9)) { vehDesc.Capacity = kMyReader.GetInt32(9); }
                        if (!kMyReader.IsDBNull(10)) { vehDesc.Circuit = kMyReader.GetString(10); }
                        VehicleDescList.Add(vehDesc);
                    }
                }
            }
            return VehicleDescList;
        }

        // GET: api/VehicleDescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDescription([FromRoute] int vhId, int ndBId)
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
                MySql = " SELECT VehicleName, VehicleType, vDriver, vNumber, DriverAddress, DriverDetails, VehicleDetails, "
                    + " ContactPhone, Capacity, Circuit FROM VehicleDescription WITH (NOLOCK)";
                MySql = MySql + " WHERE VehicleId = " + vhId;
                MySql = MySql + " AND Dormant = 0";
                MySql = MySql + " AND dBID = " + ndBId;

                command.CommandType = CommandType.Text;
                command.CommandText = MySql;
                DbDataReader kMyReader = await command.ExecuteReaderAsync();
                if (kMyReader.HasRows)
                {
                    kMyReader.Read();
                    VehicleDescription vehDesc = new VehicleDescription();
                    vehDesc.VehicleId = vhId;
                    if (!kMyReader.IsDBNull(0)) { vehDesc.VehicleName = kMyReader.GetString(0); }
                    if (!kMyReader.IsDBNull(1)) { vehDesc.VehicleType = kMyReader.GetString(1); }
                    if (!kMyReader.IsDBNull(2)) { vehDesc.VDriver = kMyReader.GetString(2); }
                    if (!kMyReader.IsDBNull(3)) { vehDesc.VNumber = kMyReader.GetString(3); }
                    if (!kMyReader.IsDBNull(4)) { vehDesc.DriverAddress = kMyReader.GetString(4); }
                    if (!kMyReader.IsDBNull(5)) { vehDesc.DriverDetails = kMyReader.GetString(5); }
                    if (!kMyReader.IsDBNull(6)) { vehDesc.VehicleDetails = kMyReader.GetString(6); }
                    if (!kMyReader.IsDBNull(7)) { vehDesc.ContactPhone = kMyReader.GetString(7); }
                    if (!kMyReader.IsDBNull(8)) { vehDesc.Capacity = kMyReader.GetInt32(8); }
                    if (!kMyReader.IsDBNull(9)) { vehDesc.Circuit = kMyReader.GetString(9); }
                    return Ok(vehDesc);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // PUT: api/VehicleDescriptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDescription([FromRoute] int id, [FromBody] VehicleDescription vehDesc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehDesc.VehicleId)
            {
                return BadRequest();
            }
            var vtid = vehDesc.VehicleId;
            try
            {
                var conn = _context.Database.GetDbConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var command = conn.CreateCommand())
                {
                    MySql = " UPDATE VehicleDescription SET ";
                    MySql = MySql + " VehicleName = '" + vehDesc.VehicleName + "',";
                    MySql = MySql + " VehicleType = '" + vehDesc.VehicleType + "',";
                    MySql = MySql + " vDriver = '" + vehDesc.VDriver + "',";
                    MySql = MySql + " vNumber = '" + vehDesc.VNumber + "',";
                    MySql = MySql + " DriverAddress = '" + vehDesc.DriverAddress + "',";
                    MySql = MySql + " DriverDetails = '" + vehDesc.DriverDetails + "',";
                    MySql = MySql + " VehicleDetails = '" + vehDesc.VehicleDetails + "',";
                    MySql = MySql + " ContactPhone = '" + vehDesc.ContactPhone + "',";
                    MySql = MySql + " Capacity = " + vehDesc.Capacity + ",";
                    MySql = MySql + " Circuit = '" + vehDesc.Circuit + "'";

                    MySql = MySql + " WHERE VehicleID = " + vehDesc.VehicleId;
                    MySql = MySql + " AND Dormant = 0";
                    MySql = MySql + " AND dBID = " + vehDesc.DBid;

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
                //UpdateAcaSession(acaSession);
                //    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDescriptionExists(vtid))
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

        // POST: api/VehicleDescriptions
        [HttpPost]
        public async Task<IActionResult> PostVehicleDescription([FromBody] VehicleDescription vehDesc)
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
                    MySql = " INSERT INTO VehicleDescription (  VehicleID, VehicleName, VehicleType, vDriver, vNumber,"
                        + " DriverAddress, DriverDetails, VehicleDetails, ContactPhone, Capacity, Circuit, ";
                    MySql = MySql + " Dormant, LoginName, ModTime, cTerminal, dBID) Values (0, '";
                    MySql = MySql + vehDesc.VehicleName + "','" + vehDesc.VehicleType + "','" + vehDesc.VDriver + "','";
                    MySql = MySql + vehDesc.VNumber + "','" + vehDesc.DriverAddress + "','" + vehDesc.DriverDetails + "','";
                    MySql = MySql + vehDesc.VehicleDetails + "','" + vehDesc.ContactPhone + "'," + vehDesc.Capacity + ",'";
                    MySql = MySql + vehDesc.Circuit;
                    MySql = MySql + "', 0,'" + vehDesc.LoginName + "'," + GenFunc.GloFunc.ToOADate(DateTime.Now);
                    MySql = MySql + ",'" + vehDesc.CTerminal + "'," + vehDesc.DBid + ")";

                    command.CommandType = CommandType.Text;
                    command.CommandText = MySql;
                    command.ExecuteNonQuery();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            //return CreatedAtAction("GetVehicleDescription", new { vhId = vehDesc.VehicleId, ndBId = vehDesc.DBid  }, vehDesc);  
            return Ok(vehDesc);
        }

        // DELETE: api/VehicleDescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleDescription([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicleDescription = await _context.VehicleDescription.SingleOrDefaultAsync(m => m.AutoId == id);
            if (vehicleDescription == null)
            {
                return NotFound();
            }

            _context.VehicleDescription.Remove(vehicleDescription);
            await _context.SaveChangesAsync();

            return Ok(vehicleDescription);
        }

        private bool VehicleDescriptionExists(int id)
        {
            return _context.VehicleDescription.Any(e => e.AutoId == id);
        }
    }
}