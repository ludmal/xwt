using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XWT.Data;
using System.Data.SqlClient;
using XWT.Data;

namespace XWT.Security
{
    public class UserManager
    {
        public static UserCreateStatus CreateUser(string username, string password, string firstname, string lastname, string email, bool active)
        {
            try
            {
                string sql = string.Format("INSERT INTO [USERS] ([USER_NAME],[USER_SALT],[USER_FIRSTNAME],[USER_LASTNAME],[USER_EMAIL],[USER_ACTIVE]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", username, password, firstname, lastname, email, active);
                Database db = Database.Create();
                db.ExecuteNonQuery(sql);
                return UserCreateStatus.Success;
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Message.ToLower().Contains("duplicate") && sqlex.Message.ToLower().Contains("PK_USERS"))
                {
                    return UserCreateStatus.DuplicateUsername;
                }
                else if (sqlex.Message.ToLower().Contains("duplicate") && sqlex.Message.ToLower().Contains("IX_USERS_1"))
                {
                    return UserCreateStatus.DuplicateEmail;
                }
                return UserCreateStatus.Failure;

            }
            catch (Exception ex)
            {
                return UserCreateStatus.Failure;
            }
        }

        public static bool DeleteUser(string username)
        {
            try
            {
                string sql = string.Format("DELETE FROM USERS WHERE USER_NAME='{0}'", username);
                Database db = Database.Create();
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static bool UpdateUser(string username, string password, string firstname, string lastname, string email, bool active)
        {
            try
            {
                string sql = string.Format("UPDATE [USERS] SET [USER_SALT] = '{0}',[USER_FIRSTNAME] = '{1}',[USER_LASTNAME] ='{2}',[USER_EMAIL] = '{3}',[USER_ACTIVE] = '{4}' WHERE USER_NAME='{5}'", password, firstname, lastname, email, active, username);
                Database db = Database.Create();
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
