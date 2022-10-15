using HalYonetim;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class DataLayer
    {
        static DataLayer instance;
        private DataLayer()
        {

        }
        public static DataLayer GetLayer
        {
            get
            {
                if (instance == null)
                    instance = new DataLayer();
                return instance;
            }
        }
        public string CnnString
        {
            get
            {

                string serverName = DbSettings.Instance.GetValue(DbSettingsEnum.SunucuAdi);
                string databaseName = DbSettings.Instance.GetValue(DbSettingsEnum.Veritabani);
                string providerName = "System.Data.SqlClient";
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.MultipleActiveResultSets = true;
                if (DbSettings.Instance.GetValue(DbSettingsEnum.OturumAcmaSekli) == "SQL")
                {
                    sqlBuilder.UserID = DbSettings.Instance.GetValue(DbSettingsEnum.KullaniciAdi);
                    sqlBuilder.Password = DbSettings.Instance.GetValue(DbSettingsEnum.Sifre);
                    sqlBuilder.IntegratedSecurity = false;
                }
                else
                    sqlBuilder.IntegratedSecurity = true;

                string providerString = sqlBuilder.ToString();

                return providerString;

            }
        }

        public bool SqlBulkCopy(string tableName, DataTable dtData)
        {
            try
            {
                using (var connection = new SqlConnection(CnnString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        bulkCopy.BatchSize = 100;
                        bulkCopy.DestinationTableName = string.Format("dbo.{0}", tableName);
                        try
                        {
                            bulkCopy.WriteToServer(dtData);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }

        public bool SqlBulkCopy(string tableName, DataTable dtData, SqlTransaction trn)
        {
            try
            {

                using (var bulkCopy = new SqlBulkCopy(trn.Connection, SqlBulkCopyOptions.Default, trn))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = string.Format("dbo.{0}", tableName);
                    try
                    {
                        bulkCopy.WriteToServer(dtData);
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        trn.Rollback();
                        return false;
                    }
                }
                trn.Commit();
                return true;

            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }
        public int ExecQuery(string Query)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand("", cn))
                {
                    try
                    {

                        cn.Open();
                        cmd.CommandTimeout = 99999;
                        if (Query.IndexOf(';') > -1)
                            foreach (string sql in Query.Split(';'))
                            {
                                cmd.CommandText = sql;
                                result = cmd.ExecuteNonQuery();
                            }
                        else
                        {
                            cmd.CommandText = Query;
                            result = cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        return default(int);
                    }
                }
            }
            return result;
        }
        public int ExecQuery(string Query, params SqlParameter[] prm)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, cn))
                {

                    try
                    {
                        cn.Open();
                        foreach (SqlParameter p in prm)
                            cmd.Parameters.Add(p);
                        cmd.CommandTimeout = 99999;
                        result = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        return -1;
                    }
                    finally
                    {

                        cmd.Parameters.Clear();
                    }
                }
            }
            return result;
        }
        public int ExecQuery(string Query, CommandType type, params SqlParameter[] prm)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, cn))
                {
                    try
                    {
                        cn.Open();
                        cmd.CommandType = type;
                        cmd.CommandTimeout = 999999;
                        if (prm != null)
                        {
                            foreach (SqlParameter p in prm)
                                cmd.Parameters.Add(p);
                        }
                        result = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        return default(int);
                    }
                }
            }
            return result;
        }
        public int ExecQuery(string Query, SqlTransaction trn, params SqlParameter[] prm)
        {
            int result = 0;
            SqlConnection cn = trn.Connection;
            using (SqlCommand cmd = new SqlCommand(Query, cn))
            {
                try
                {
                    cmd.Transaction = trn;
                    cmd.CommandTimeout = 99999;
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    foreach (SqlParameter p in prm)
                        cmd.Parameters.Add(p);
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                    return default(int);
                }
            }
            return result;
        }

        public int ExecQuery(string Query, SqlTransaction trn)
        {
            int result = 0;
            SqlConnection cn = trn.Connection;
            using (SqlCommand cmd = new SqlCommand(Query, cn))
            {
                try
                {
                    cmd.Transaction = trn;
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    HataLog.Instance.HataLogYaz(ex);
                    return default(int);
                }
            }
            return result;
        }

        public int ExecQuery(string Query, SqlTransaction trn, CommandType type, params SqlParameter[] prm)
        {
            int result = 0;
            SqlConnection cn = trn.Connection;
            SqlCommand cmd = new SqlCommand(Query, cn);
            try
            {
                cmd.Transaction = trn;
                cmd.CommandType = type;
                if (cn.State == ConnectionState.Closed) cn.Open();
                foreach (SqlParameter p in prm)
                    cmd.Parameters.Add(p);
                result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                trn.Rollback();
                HataLog.Instance.HataLogYaz(ex);
                return default(int);
            }
            return result;
        }

        public object ExecScalar(string Query)
        {
            object result = null;
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand("", cn))
                {
                    try
                    {
                        cn.Open();
                        if (Query.IndexOf(';') > -1)
                            foreach (string sql in Query.Split(';'))
                            {
                                cmd.CommandText = sql;
                                result = cmd.ExecuteScalar();
                            }
                        else
                        {
                            cmd.CommandText = Query;
                            result = cmd.ExecuteScalar();
                        }
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        return null;
                    }
                }
            }
            return result;
        }

        public object ExecScalar(string Query, params SqlParameter[] prm)
        {
            object result = 0;
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, cn))
                {
                    try
                    {
                        cn.Open();
                        foreach (SqlParameter p in prm)
                            cmd.Parameters.Add(p);
                        result = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                        return null;
                    }
                }
            }
            return result;
        }

        public object ExecScalar(string Query, SqlTransaction trns, params SqlParameter[] prm)
        {
            object result = 0;
            SqlConnection cn = trns.Connection;
            using (SqlCommand cmd = new SqlCommand(Query, cn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    foreach (SqlParameter p in prm)
                        cmd.Parameters.Add(p);
                    cmd.Transaction = trns;
                    result = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    //cn.Close();
                }
                catch (Exception ex)
                {
                    trns.Rollback();
                    HataLog.Instance.HataLogYaz(ex);
                    return null;
                }
            }
            return result;
        }

        public DataTable FillData(string Query)
        {
            DataTable result = new DataTable();
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, cn))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            cn.Open();
                            adp.SelectCommand.CommandTimeout = 99999;
                            adp.Fill(result);
                            cn.Close();
                        }
                        catch (Exception ex)
                        {
                            HataLog.Instance.HataLogYaz(ex);
                            return null;
                        }
                    }
                }
            }
            return result;
        }
        public DataTable FillData(string Query, params SqlParameter[] prm)
        {
            DataTable result = new DataTable();
            using (SqlConnection cn = new SqlConnection(CnnString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, cn))
                {
                    foreach (SqlParameter p in prm)
                        cmd.Parameters.Add(p);
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            cn.Open();
                            adp.SelectCommand.CommandTimeout = 99999;
                            adp.Fill(result);
                            cmd.Parameters.Clear();
                            cn.Close();
                        }
                        catch (Exception ex)
                        {
                            HataLog.Instance.HataLogYaz(ex);
                            return null;
                        }
                    }
                }
            }
            return result;
        }

        public SqlDataReader ReadData(string Query)
        {
            SqlDataReader rd = null;
            SqlConnection cn = new SqlConnection(CnnString);

            using (SqlCommand cmd = new SqlCommand(Query, cn))
            {
                try
                {
                    cn.Open();
                    cmd.CommandTimeout = 999999;
                    rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                }

            }
            return rd;
        }
        public SqlDataReader ReadData(string Query, params SqlParameter[] prm)
        {
            SqlDataReader result = null;
            SqlConnection cn = new SqlConnection(CnnString);
            using (SqlCommand cmd = new SqlCommand(Query, cn))
            {
                foreach (SqlParameter p in prm)
                    cmd.Parameters.Add(p);
                try
                {
                    cn.Open();
                    cmd.CommandTimeout = 99999;
                    result = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                    return null;
                }
            }
            return result;
        }

        public SqlTransaction OpenTransaction()
        {
            SqlConnection cn = new SqlConnection(CnnString);
            cn.Open();
            SqlTransaction trn = cn.BeginTransaction();
            return trn;
        }
    }
}
