using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minifier {
    public interface IJavaScriptMinifier {
        void Minify(string src, string dst);
        string MinifyString(string src);
    }
}
