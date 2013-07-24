using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Minifier {
    class Program {
        public jsMinifierHandler Handler {
            get { return _Handler; }
            set { _Handler = value; }
        }
        private jsMinifierHandler _Handler = null;


        public string InputFile {
            get { return _InputFile; }
            set { _InputFile = value; }
        }
        private string _InputFile = "";


        public string OutputFile {
            get { return _OutputFile; }
            set { _OutputFile = value; }
        }
        private string _OutputFile = "";


        public string MinifiedOutput {
            get { return _MinifiedOutput; }
            set { _MinifiedOutput = value; }
        }
        private string _MinifiedOutput = "";

        static void WalkDirectoryTree(System.IO.DirectoryInfo root) {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try {
                files = root.GetFiles("*.*");
            }
                // This is thrown if even one of the files requires permissions greater
                // than the application provides.
            catch (UnauthorizedAccessException e) {
                //log.Add(e.Message);
            } catch (System.IO.DirectoryNotFoundException e) {
                Console.WriteLine(e.Message);
            }

            if (files != null) {
                foreach (System.IO.FileInfo fi in files) {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    //Console.WriteLine(fi.FullName);
                    string fileName = fi.FullName.Substring(fi.FullName.LastIndexOf("\\") + 1);
                    string fileExt = fileName.Substring(fileName.LastIndexOf('.') + 1);
                    if (fileExt == "css" || fileExt == "js") {
                        Minify(fi.FullName);
                    } else {
                        //Console.ForegroundColor = ConsoleColor.White;
                        //Console.WriteLine(fileName);
                    }
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs) {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo);
                }
            }
        }


        static void Main(string[] args) {
            String strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            WalkDirectoryTree(new DirectoryInfo(strPath));

        }

        static void Minify(string fileName) {
            jsMinifierHandler Handler = new jsMinifierHandler();

            Handler.InputFile = fileName;

            if (string.IsNullOrEmpty(Handler.OutputFile)) {
                if (Handler.InputFile.ToLower().Contains("*.js")) {
                    // *** Force to .min.js extension
                    Handler.OutputFile = ".min.js";
                } else {
                    Handler.OutputFile = Handler.InputFile.ToLower().Replace(".js", ".min.js");
                }
            }


            if (!Handler.MiniFy()) {
                Console.WriteLine(string.Format("Unable to convert:\r\n\r\n{0}", Handler.ErrorMessage));
                return;
            }

            if (Handler.FilesProcessed > 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File: " + Handler.InputFile.ToString() +
                                        "    Bytes: " + Handler.InputSize.ToString("n0") +
                                        " --> " + Handler.OutputSize.ToString("n0") +
                                        "  -- " + (100M - ((decimal)((decimal)Handler.OutputSize / (decimal)Handler.InputSize) * 100)).ToString("n2") + "% compressed");
                Console.ForegroundColor = ConsoleColor.White;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No files compressed");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
