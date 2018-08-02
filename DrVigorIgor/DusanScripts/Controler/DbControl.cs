using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CldMedAPI.Data;
using System.Diagnostics;

namespace CldMedAPI.Controler
{
    /// <summary>
    /// Usage:
    /// 1. Create DbControl object with username and password
    /// 2. Call getPerscriptions with the health id
    /// 3. Have fun
    /// </summary>
    public class DbControl
    {
        private string connstr="Server = tcp:drvigor.database.windows.net,1433;Initial Catalog = medrockdatabase; Persist Security Info=False;User ID = @user; Password=@pass; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        private SqlConnection dbconn;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Username for database login</param>
        /// <param name="password">Password for database login</param>
        public DbControl(string username, string password)
        {
            connstr=connstr.Replace("@user", username).Replace("@pass",password);
            dbconn = new SqlConnection(connstr);
        }
        /// <summary>
        /// Opens the database connection
        /// </summary>
        /// <returns>Information of successfulness</returns>
        public bool Open()
        {
            bool flg = false;
            try { dbconn.Open(); flg = true; }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return flg;
        }
        /// <summary>
        /// Closes the database connection
        /// </summary>
        /// <returns>Information of successfulness</returns>
        public bool Close()
        {
            bool flg = false;
            try { if(dbconn.State!=ConnectionState.Closed)dbconn.Close();
                flg = true;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return flg;
        }
        public List<Perscription> getPerscriptions(string healthID)
        {
            if (dbconn == null) throw new NullReferenceException();
            List<Perscription> pers = new List<Perscription>();
            //var dr = new SqlCommand(,dbconn);
            try
            {
                var cmd = new SqlCommand(QueryStrings.selectPerData, dbconn);
                cmd.Parameters.AddWithValue("@par", healthID);
                if (!Open()) throw new Exception("Error accessing database");
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    User usr = new User();
                    usr.Id = (Int32)sdr["Uid"];
                    usr.Name= (String)sdr["Name"];
                    usr.Username = (String)sdr["Username"];
                    Perscription p = new Perscription();
                    p.Id = (Int32)sdr["Pid"];
                    p.Interval = (String)sdr["Inter"];
                    p.Count = (Int32)sdr["Count"];
                    p.Dose = (String)sdr["Dose"];
                    Medication m = new Medication();
                    m.Id = (Int32)sdr["Mid"];
                    m.Name = (String)sdr["MName"];
                    m.Barcode = (String)sdr["Barcode"];
                    p.Usr = usr;
                    p.Med = m;
                    pers.Add(p);
                }
                if (!Close()) throw new Exception("Error accessing database");
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return pers;
        }
        public ConnectionState State{ get { return dbconn.State; } }
    }
}
