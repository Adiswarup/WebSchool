using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchDataApi.GenFunc
{
    public static class ConVeyFunc
    {
      public static int   getStopID(SchContext _context, string stp,int mdBId)
        {
            int stpId = -1;
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                    kMySql = " SELECT StopID ";
                    kMySql = kMySql + " FROM  Stops";
                    kMySql = kMySql + " WHERE dBID = " + mdBId;
                    kMySql = kMySql + " AND  Dormant = 0";
                    kMySql = kMySql + " AND Stops = '" + stp + "'";
                    command.CommandText = kMySql;
                    command.CommandType = CommandType.Text;
                    stpId =(int) command.ExecuteScalar();
            }
            conn.Close();
            return stpId;
        }
    }
}
