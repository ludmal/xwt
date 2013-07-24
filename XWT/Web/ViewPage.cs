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

namespace XWT.Web {
    public class ViewPage<TLogic> : XWTBasePage, IViewControl
                        where TLogic : ILogicBase, new()
                        {
        private TLogic _Logic = default(TLogic);
        public TLogic Logic {
            get {
                if (_Logic == null) {
                    _Logic = new TLogic();
                }
                return _Logic;
            }
            set { _Logic = value; }
        }
    }

    public class ViewPage<TLogic, TModel> : XWTBasePage, IViewControl
        where TLogic : ILogicBase, new()
        where TModel : new() {

        private TLogic _Logic = default(TLogic);
        public TLogic Logic {
            get {
                if (_Logic == null) {
                    _Logic = new TLogic();
                }
                return _Logic;
            }
            set { _Logic = value; }
        }

        private TModel _Model = default(TModel);
        public TModel Model {
            get {
                if (_Model == null) {
                    _Model = new TModel();
                }
                return _Model;
            }
            set { _Model = value; }
        }
    }

    public class ViewPage : XWTBasePage {

    }

}
