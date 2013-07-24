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
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Configuration;
using XWT.Data;

namespace XWT {
    public class DataModelBase {

        private TableInfo _TableInfo = null;
        public TableInfo TableInfo {
            get {
                return _TableInfo;
            }
            set {
                _TableInfo = value;
            }
        }

        public const BindingFlags MemberAccess =
          BindingFlags.Public | BindingFlags.NonPublic |
          BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase;

        public const BindingFlags MemberPublicInstanceAccess =
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase;


        public XWT.Data.Database DataBase {
            get;
            private set;
        }

        public DataModelBase() {
            DataBase = Database.Create();
        }

        public virtual void BindTableInfo() {
            //_TableInfo = new TableInfo() { TableName = tableName, UniqueField = uniqueField, OrderByField = orderbyField };
        }

        public DataSet GetData(string sql) {
            return DataBase.ExecuteDataSet(sql);
        }

        public IDataReader GetDataByReader(string sql) {
            return DataBase.ExecuteReader(sql);
        }

        private string GetSortOrder() {
            return !string.IsNullOrEmpty(_TableInfo.OrderByField) ? string.Format(" ORDER BY {0} {1}", _TableInfo.OrderByField, !string.IsNullOrEmpty(_TableInfo.SortOrder) ? _TableInfo.SortOrder : " ASC ") : "";
        }

        public IDataReader GetData() {
            if (_TableInfo == null) {
                BindTableInfo();
            }
            return DataBase.ExecuteReader(string.Format("SELECT {2} * FROM {0} {1}", _TableInfo.TableName, GetSortOrder(), _TableInfo.Count != 0 ? "TOP " + _TableInfo.Count.ToString() : string.Empty));
        }

        public IDataReader GetData(object uniqueFieldValue) {
            if (_TableInfo == null) {
                BindTableInfo();
            }
            return DataBase.ExecuteReader(string.Format("SELECT * FROM {0} WHERE {1}='{2}'", _TableInfo.TableName, _TableInfo.UniqueField, uniqueFieldValue.ToString()));

        }


        public string GenerateUniqueId(int stringSize) {
            string chars = "abcdefghijkmnopqrstuvwxyz1234567890";
            StringBuilder result = new StringBuilder(stringSize);
            int count = 0;
            foreach (byte b in Guid.NewGuid().ToByteArray()) {
                result.Append(chars[b % (chars.Length - 1)]);
                count++;
                if (count >= stringSize)
                    return result.ToString();
            }
            return result.ToString();
        }


        /// <summary>
        /// Generates a unique Id with 8 characters made up of
        /// numbers and lower case alpha characters.
        /// </summary>
        public string GenerateUniqueId() {
            return GenerateUniqueId(8);
        }

        /// Generates a unique numeric ID. Generated off a GUID and
        /// returned as a 64 bit long value
        /// </summary>
        /// <returns></returns>
        public long GenerateUniqueNumericId() {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        /// Copies the content of a data row to another. Runs through the target's fields
        /// and looks for fields of the same name in the source row. Structure must mathc
        /// or fields are skipped.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool CopyDataRow(DataRow source, DataRow target) {
            DataColumnCollection columns = target.Table.Columns;

            for (int x = 0; x < columns.Count; x++) {
                string fieldname = columns[x].ColumnName;

                try {
                    target[x] = source[fieldname];
                } catch { ;}  // skip any errors
            }

            return true;
        }

        public void CopyObjectFromDataRow(DataRow row, object targetObject) {
            MemberInfo[] miT = targetObject.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess, null, null);
            foreach (MemberInfo Field in miT) {
                string Name = Field.Name;
                if (!row.Table.Columns.Contains(Name))
                    continue;

                if (Field.MemberType == MemberTypes.Field) {
                    ((FieldInfo)Field).SetValue(targetObject, row[Name]);
                } else if (Field.MemberType == MemberTypes.Property) {
                    ((PropertyInfo)Field).SetValue(targetObject, row[Name], null);
                }
            }
        }

        /// <summary>
        /// Copies the content of an object to a DataRow with matching field names.
        /// Both properties and fields are copied. If a field copy fails due to a
        /// type mismatch copying continues but the method returns false
        /// </summary>
        /// <param name="row"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool CopyObjectToDataRow(DataRow row, object target) {
            bool result = true;

            MemberInfo[] miT = target.GetType().FindMembers(MemberTypes.Field | MemberTypes.Property, MemberAccess, null, null);
            foreach (MemberInfo Field in miT) {
                string name = Field.Name;
                if (!row.Table.Columns.Contains(name))
                    continue;

                try {
                    if (Field.MemberType == MemberTypes.Field) {
                        row[name] = ((FieldInfo)Field).GetValue(target);
                    } else if (Field.MemberType == MemberTypes.Property) {
                        row[name] = ((PropertyInfo)Field).GetValue(target, null);
                    }
                } catch { result = false; }
            }

            return result;
        }

        public void CopyObjectData(object source, Object target) {
            CopyObjectData(source, target, MemberAccess);
        }

        public void CopyObjectData(object source, Object target, BindingFlags memberAccess) {
            CopyObjectData(source, target, null, memberAccess);
        }

        public void CopyObjectData(object source, Object target, string excludedProperties) {
            CopyObjectData(source, target, excludedProperties, MemberAccess);
        }

        /// <summary>
        /// Copies the data of one object to another. The target object 'pulls' properties of the first. 
        /// This any matching properties are written to the target.
        /// 
        /// The object copy is a shallow copy only. Any nested types will be copied as 
        /// whole values rather than individual property assignments (ie. via assignment)
        /// </summary>
        /// <param name="source">The source object to copy from</param>
        /// <param name="target">The object to copy to</param>
        /// <param name="excludedProperties">A comma delimited list of properties that should not be copied</param>
        /// <param name="memberAccess">Reflection binding access</param>
        public void CopyObjectData(object source, object target, string excludedProperties, BindingFlags memberAccess) {
            string[] excluded = null;
            if (!string.IsNullOrEmpty(excludedProperties))
                excluded = excludedProperties.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            MemberInfo[] miT = target.GetType().GetMembers(memberAccess);
            foreach (MemberInfo Field in miT) {
                string name = Field.Name;

                // Skip over any property exceptions
                if (!string.IsNullOrEmpty(excludedProperties) &&
                    excluded.Contains(name))
                    continue;

                if (Field.MemberType == MemberTypes.Field) {
                    FieldInfo SourceField = source.GetType().GetField(name);
                    if (SourceField == null)
                        continue;

                    object SourceValue = SourceField.GetValue(source);
                    ((FieldInfo)Field).SetValue(target, SourceValue);
                } else if (Field.MemberType == MemberTypes.Property) {
                    PropertyInfo piTarget = Field as PropertyInfo;
                    PropertyInfo SourceField = source.GetType().GetProperty(name, memberAccess);
                    if (SourceField == null)
                        continue;

                    if (piTarget.CanWrite && SourceField.CanRead) {
                        object SourceValue = SourceField.GetValue(source, null);
                        piTarget.SetValue(target, SourceValue, null);
                    }
                }
            }
        }

        public void DataReaderToObject(IDataReader reader, object instance, string fieldsToSkip) {
            if (string.IsNullOrEmpty(fieldsToSkip))
                fieldsToSkip = string.Empty;
            else
                fieldsToSkip = "," + fieldsToSkip + ",";

            fieldsToSkip = fieldsToSkip.ToLower();

            if (reader.IsClosed)
                throw new InvalidOperationException("DataReader passed to DataReaderToObject cannot be closed");

            PropertyInfo[] Properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties) {
                if (!Property.CanRead || !Property.CanWrite)
                    continue;

                string Name = Property.Name;
                object[] att = Property.GetCustomAttributes(true);

                if (fieldsToSkip.Contains("," + Name.ToLower() + ","))
                    continue;


                object value = null;
                try {
                    PersistentAttribute dataAtt = null;
                    if (att != null && att.Length > 0) {
                        dataAtt = (PersistentAttribute)att[0];
                    }
                    if (dataAtt != null && !string.IsNullOrEmpty(dataAtt.FieldName)) {
                        value = reader[dataAtt.FieldName];
                        if (value is DBNull) {
                            value = null;
                        } else {
                            if (Property.PropertyType == typeof(Boolean)) {
                                if (value.ToString() == "1") {
                                    value = true;
                                } else { value = false; }
                            }
                        }
                    } else {
                        value = reader[Name];

                        if (value is DBNull) {
                            value = null;
                        } else {
                            if (Property.PropertyType == typeof(Boolean)) {
                                if (value.ToString() == "1") {
                                    value = true;
                                } else { value = false; }
                            }
                        }

                    }
                } catch {
                    // Ignore fields that don't exist in the Reader
                    continue;
                }

                Property.SetValue(instance, value, null);
            }
        }

        public List<TType> DataReaderToObjectList<TType>(IDataReader reader) {
            return DataReaderToObjectList<TType>(reader, string.Empty);
        }

        public List<TType> DataReaderToObjectList<TType>(IDataReader reader, string fieldsToSkip) {
            if (reader == null)
                return null;
            List<TType> items = new List<TType>();

            while (reader.Read()) {
                var inst = Activator.CreateInstance<TType>();
                DataReaderToObject(reader, inst, fieldsToSkip);

                items.Add(inst);
            }

            return items;
        }

        private string FormatValue(object value) {
            if (value is Boolean) {
                value = Convert.ToBoolean(value) ? "1" : "0";
            } else if (value is DateTime) {
                value = Convert.ToDateTime(value).ToSqlDateTime();
            }
            return value.ToString();
        }

        public void Create(object t) {
            try {
                var instance = t;
                char[] c = { ',' };
                string fields = string.Empty;
                string values = string.Empty;

                PropertyInfo[] Properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo Property in Properties) {
                    //if (!Property.CanRead || !Property.CanWrite)
                    //    continue;

                    string Name = Property.Name;
                    object[] att = Property.GetCustomAttributes(true);

                    //if (fieldsToSkip.Contains("," + Name.ToLower() + ","))
                    //    continue;

                    try {
                        PersistentAttribute dataAtt = null;
                        if (att != null && att.Length > 0) {
                            dataAtt = (PersistentAttribute)att[0];
                        }
                        if (dataAtt != null && !string.IsNullOrEmpty(dataAtt.FieldName)) {
                            if (dataAtt.IsIdentity)
                                continue;

                            fields += string.Format("{0},", dataAtt.FieldName);
                            object v = Property.GetValue(instance, null);

                            values += string.Format("'{0}',", FormatValue(v));
                        }
                    } catch {
                        // Ignore fields that don't exist in the Reader
                        continue;
                    }

                }

                string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", _TableInfo.TableName, fields.TrimEnd(c), values.TrimEnd(c));
                DataBase.ExecuteNonQuery(sql);
            } catch (Exception ex) {

                throw;
            }
        }

        public void Update(object t) {
            var instance = t;
            char[] c = { ',' };
            string fieldsValues = string.Empty;
            string where = string.Empty;

            PropertyInfo[] Properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties) {
                //if (!Property.CanRead || !Property.CanWrite)
                //    continue;

                string Name = Property.Name;
                object[] att = Property.GetCustomAttributes(true);

                //if (fieldsToSkip.Contains("," + Name.ToLower() + ","))
                //    continue;

                try {
                    PersistentAttribute dataAtt = null;
                    if (att != null && att.Length > 0) {
                        dataAtt = (PersistentAttribute)att[0];
                    }
                    if (dataAtt != null && !string.IsNullOrEmpty(dataAtt.FieldName)) {
                        if (dataAtt.IsUnique) {
                            where = string.Format("{0}='{1}'", dataAtt.FieldName, FormatValue(Property.GetValue(instance, null)));
                            continue;
                        }

                        fieldsValues += string.Format(" {0}='{1}',", dataAtt.FieldName, FormatValue(Property.GetValue(instance, null)));
                    }
                } catch {
                    // Ignore fields that don't exist in the Reader
                    continue;
                }

            }

            string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", _TableInfo.TableName, fieldsValues.TrimEnd(c), where);
            DataBase.ExecuteNonQuery(sql);
        }

        public void Delete(object t) {
            var instance = t;
            char[] c = { ',' };
            string uniqueField = string.Empty;
            string values = string.Empty;

            PropertyInfo[] Properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties) {
                //if (!Property.CanRead || !Property.CanWrite)
                //    continue;

                string Name = Property.Name;
                object[] att = Property.GetCustomAttributes(true);

                //if (fieldsToSkip.Contains("," + Name.ToLower() + ","))
                //    continue;

                try {
                    PersistentAttribute dataAtt = null;
                    if (att != null && att.Length > 0) {
                        dataAtt = (PersistentAttribute)att[0];
                    }
                    if (dataAtt != null && !string.IsNullOrEmpty(dataAtt.FieldName)) {
                        if (dataAtt.IsUnique) {
                            uniqueField = dataAtt.FieldName;
                            values += string.Format("{0}", Property.GetValue(instance, null));
                            break;
                        }
                    }
                } catch {
                    // Ignore fields that don't exist in the Reader
                    continue;
                }

            }

            string sql = string.Format("DELETE {0} WHERE {1}='{2}'", _TableInfo.TableName, uniqueField, values.TrimEnd(c));
            DataBase.ExecuteNonQuery(sql);
        }

    }


}
