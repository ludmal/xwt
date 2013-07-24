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
using XWT.Data;
using System.Reflection;

namespace XWT {
    public class LogicBase<T> : ILogicBase
               where T : DataModelBase, new() {
        private T _Model = default(T);
        public T Data {
            get {
                if (_Model == null) {
                    _Model = new T();
                }
                return _Model;
            }
            set { _Model = value; }
        }
    }

    //public class LogicBase<T,K> : ILogicBase
    //    where T : DataModelBase, new()
    //           where K : ValidationBase, new() {
    //    private T _Model = default(T);
    //    public T Data {
    //        get {
    //            if (_Model == null) {
    //                _Model = new T();
    //            }
    //            return _Model;
    //        }
    //        set { _Model = value; }
    //    }

    //    private K _Validations = default(K);
    //    public K Validations {
    //        get {
    //            if (_Validations == null) {
    //                _Validations = new K();
    //            }
    //            return _Validations;
    //        }
    //        set { _Validations = value; }
    //    }
    //}

    public class LogicBase<TData, TEntity> : ILogicBase
        where TData : DataModelBase, new()
        where TEntity : class, new() {
        private TData _Model = default(TData);
        public TData Data {
            get {
                if (_Model == null) {
                    _Model = new TData();
                }
                return _Model;
            }
            set { _Model = value; }
        }

        public virtual List<TEntity> GetAll(string orderByField, int recordCount) {
            return GetAll(orderByField, SortOrder.Asc, recordCount);
        }

        public virtual List<TEntity> GetAll(string orderByField, SortOrder sortOrder, int recordCount) {
            if (recordCount != 0) {
                Data.TableInfo.Count = recordCount;
            }
            Data.TableInfo.OrderByField = orderByField;
            Data.TableInfo.SortOrder = sortOrder.ToString();
            return Data.DataReaderToObjectList<TEntity>(Data.GetData());
        }

        public virtual List<TEntity> GetAll(string orderByField) {
            return GetAll(orderByField, 0);
        }

        public virtual List<TEntity> GetAll() {
            return Data.DataReaderToObjectList<TEntity>(Data.GetData());
        }

        public virtual List<TEntity> Execute(Query query) {
            return Data.DataReaderToObjectList<TEntity>(Data.GetDataByReader(query.ConstructQuery()));
        }

        public virtual TEntity Get(object uniqueValue) {
            List<TEntity> items = Data.DataReaderToObjectList<TEntity>(Data.GetData(uniqueValue));
            if (items.Count > 0) { return items[0]; }
            return null;
        }

        public virtual bool Create(TEntity entity) {
            try {
                Data.Create(entity);
                return true;
            } catch (Exception ex) {
                throw ex;
            }

        }

        public virtual bool Delete(TEntity entity) {
            try {
                Data.Delete(entity);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public virtual bool Update(TEntity entity) {
            try {
                Data.Update(entity);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
