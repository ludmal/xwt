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
using XWT.Data;
using XWT.Data;

namespace XWT.Security {
    //class SecurityManager {
    //    public static SaltedHash LoadHash(string username) {
    //        SqlCommand cmd = new SqlCommand("auth");
    //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@username", username);
    //        DbHelper db = new DbHelper();
    //        SaltedHash s = null;
    //        SqlDataReader rdr = db.ExecuteReader(cmd);
    //        while (rdr.Read()) {
    //            s = new SaltedHash();
    //            s.Hash = rdr["PASS"].ToString();
    //            s.Salt = Convert.ToInt32(rdr["SALT"]);
    //        }
    //        rdr.Close();
    //        return s;
    //    }

    //    public static bool Authenticate(string username, string password) {
    //        SaltedHash p = LoadHash(username);
    //        if (p == null)
    //            return false;

    //        Password newP = new Password(password, p.Salt);
    //        if (newP.ComputeSaltedHash() == p.Hash) {
    //            return true;
    //        } else {
    //            return false;
    //        }
    //    }
    //}

    //public class SaltedHash {
    //    public string Hash { get; set; }
    //    public int Salt { get; set; }
    //}

}
