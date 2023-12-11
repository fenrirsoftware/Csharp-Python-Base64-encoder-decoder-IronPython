using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronPythonBase64
{
    public partial class Form1 : Form
    {
        private ScriptEngine pythonEngine;  //python engine 
        public Form1()
        {
            InitializeComponent();
            pythonEngine = Python.CreateEngine();

            // Modify the search paths to include the directory where the standard library has been installed
            var searchPaths = pythonEngine.GetSearchPaths();
            searchPaths.Add("..\\..\\Lib");
            pythonEngine.SetSearchPaths(searchPaths);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get user input from TextBox
            string originalString = textBox1.Text;

            // Execute the script with the user input
            var scope = pythonEngine.CreateScope();
            scope.SetVariable("originalString", originalString);
            string scriptPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HelloWorldBase64.py");
            pythonEngine.ExecuteFile(scriptPath, scope);


            // Get the result from Python script
            string encodedString = scope.GetVariable<string>("encodedString");
            string decodedString = scope.GetVariable<string>("decodedString");

            // Display results in labels
            textBox2.Text = "Original string: " + originalString;
            textBox3.Text = "Encoded string: " + encodedString;
            textBox4.Text = "Decoded string: " + decodedString;
        }
    }
}
