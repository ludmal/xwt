#region License
/*
 **************************************************************
 *  Author: Ludmal de silva
 *          © XWT Solutions, 2010
 *          http://www.infonexsolutions.com/
 * 
 * Created: 12/11/2009
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 **************************************************************  
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace XWT.Data {
    public class Database {
        private DbHelper _DbHelper = null;
        private string _ConnectionKey = "con";
        private static Database _instance;
        private static object syncRoot = new object();

        private Database(string connectionKey) {
            if (!string.IsNullOrEmpty(_ConnectionKey))
                _ConnectionKey = connectionKey;

            _DbHelper = new DbHelper();
        }

        public static Database Create() {

            if (_instance == null) {
                lock (syncRoot) {
                    if (_instance == null) {
                        _instance = new Database();
                    }
                }
            }
            return _instance;
        }

        private Database()
            : this("") {
        }

        #region ExecuteReader
        public IDataReader ExecuteReader(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(_DbHelper.GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            } catch (Exception ex) {
                throw ex;
            } finally {
                //cnn.Close();
            }
        }

        public IDataReader ExecuteReader(string spName, SqlCommand cmd) {
            return ExecuteReader(spName, cmd, CommandType.StoredProcedure);
        }

        public IDataReader ExecuteReader(string sqlText) {
            return ExecuteReader(sqlText, null, CommandType.Text);
        }

        #endregion

        #region ExecuteScalar
        public int ExecuteScalar(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(_DbHelper.GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                int returnValue = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                return returnValue;
            } catch (Exception ex) {
                throw ex;
            } finally {
                cnn.Close();
            }
        }

        public int ExecuteScalar(string spName, SqlCommand cmd) {
            return ExecuteScalar(spName, cmd, CommandType.StoredProcedure);
        }

        public int ExecuteScalar(string sqlText) {
            return ExecuteScalar(sqlText, null, CommandType.Text);
        }

        #endregion

        #region ExecuteNonQuery
        public void ExecuteNonQuery(string sql, SqlCommand cmd, CommandType commandType) {
            SqlConnection cnn = new SqlConnection(_DbHelper.GetConnectionString());
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            } catch (Exception ex) {
                throw ex;
            } finally {
                cnn.Close();
            }
        }

        public void ExecuteNonQuery(string spName, SqlCommand cmd) {
            ExecuteNonQuery(spName, cmd, CommandType.StoredProcedure);
        }

        public void ExecuteNonQuery(string sqlText) {
            ExecuteNonQuery(sqlText, null, CommandType.Text);
        }
        #endregion

        #region ExecuteDataSet
        public DataSet ExecuteDataSet(string sql, SqlCommand cmd, CommandType commandType) {
            try {
                if (cmd == null) {
                    cmd = new SqlCommand();
                }
                SqlConnection cnn = new SqlConnection(_DbHelper.GetConnectionString());
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public DataSet ExecuteDataSet(string spName, SqlCommand cmd) {
            return ExecuteDataSet(spName, cmd, CommandType.StoredProcedure);
        }

        public DataSet ExecuteDataSet(string sqlText) {
            return ExecuteDataSet(sqlText, null, CommandType.Text);
        }

        #endregion
    }
}
