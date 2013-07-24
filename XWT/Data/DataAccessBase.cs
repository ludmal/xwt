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
using XWT.Data;

namespace XWT.Data
{
    public class DataAccessBase
    {
        public string InsertSP { get; set; }
        public string DeleteSP { get; set; }
        public string UpdateSP { get; set; }

        private Database _Database = null;
        public Database DataBase
        {
            get
            {
                return _Database;
            }
            set
            {
                _Database = value;
            }

        }

        public DataAccessBase()
        {
            _Database = Database.Create();
        }

        private List<SqlParameter> _parameterCollection = new List<SqlParameter>();
        public List<SqlParameter> ParameterCollection
        {
            get { return _parameterCollection; }
            set { _parameterCollection = value; }
        }

        public virtual void Insert()
        {
            Insert(null);
        }

        public virtual void Insert(IDataObject dataObject)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = InsertSP;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in _parameterCollection)
            {
                cmd.Parameters.Add(para);
            }
            ExecuteScalar(cmd);
        }

        public virtual IDataReader GetReader(string spName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in _parameterCollection)
            {
                cmd.Parameters.Add(para);
            }
            return DataBase.ExecuteReader(spName, cmd);
        }

        public void ExecuteScalar(SqlCommand cmd)
        {
            DataBase.ExecuteScalar(cmd.CommandText, cmd);
        }

        public IDataReader  ExecuteReader(SqlCommand cmd)
        {
            return DataBase.ExecuteReader(cmd.CommandText, cmd);
        }

    }
}
