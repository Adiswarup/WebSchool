using Microsoft.EntityFrameworkCore;
using SchDataApi.DataLayer;
using System.Data;

namespace SchDataApi.GenFunc
{
    public static class ActiveFunc
    {
       public static int GetActivityID(SchContext _context, string tAct, int tActGrID, int mdBId)
        {
            int ActGrpId = -1;
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT   ActivityID ";
                kMySql = kMySql + " FROM  Activity";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                kMySql = kMySql + " AND ActivityName = '" + tAct + "'";
                kMySql = kMySql + " AND ActGroupID = " + tActGrID ;
                command.CommandText = kMySql;
                command.CommandType = CommandType.Text;
                ActGrpId = (int)command.ExecuteScalar();
            }
            conn.Close();
            return ActGrpId;
        }
        public static int GetActivityGroupID(SchContext _context, string tActGr, int mdBId)
        {
            int ActGrpId = -1;
            string kMySql = "";
            var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            using (var command = conn.CreateCommand())
            {
                kMySql = " SELECT   ActGroupID ";
                kMySql = kMySql + " FROM  ActivityGroup";
                kMySql = kMySql + " WHERE dBID = " + mdBId;
                kMySql = kMySql + " AND  Dormant = 0";
                kMySql = kMySql + " AND ActGroupName = '" + tActGr + "'" ;
                command.CommandText = kMySql;
                command.CommandType = CommandType.Text;
                ActGrpId = (int)command.ExecuteScalar();
            }
            conn.Close();
            return ActGrpId;
        }
   }
}
