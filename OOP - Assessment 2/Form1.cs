using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP___Assessment_2
{
    public partial class Form1 : Form
    {
        //Read in the files
        FileInfo[] files = Functions.readFiles();
        bool initialised = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Check if there are at least 2 files in the folder to compare
            if (files.Length < 2)
            {
                MessageBox.Show("There must be a minimum of 2 files in the data directory.\nThe program will now quit.");
                this.Close();
            }
            //Run this if at least 2 files are present
            else
            {
                //Add the file names to the listboxes
                foreach (FileInfo x in files)
                {
                    listBox1.Items.Add(x.Name);
                    listBox2.Items.Add(x.Name);
                }
                //Make the listboxes select first item by default
                listBox1.SelectedIndex = 0;
                listBox2.SelectedIndex = 0;
                //Activate the trigger for allowing the comparing of items
                initialised = true;
            }
        }

        //This exists as a seperate function so that the code isn't copy-pasted into both the listbox change events
        private void updateState()
        {
            //This first check is in place so that no comparisons can be made unless the items have already been loaded into the listboxes
            if (initialised == true)
            {
                //Check if files are the same
                if (Functions.isSame(files[listBox1.SelectedIndex], files[listBox2.SelectedIndex]))
                {
                    //Give the correct output
                    Result.ForeColor = Color.FromArgb(0, 192, 0);
                    Result.Text = "The two files are the same";
                }
                else
                {
                    Result.ForeColor = Color.FromArgb(192, 0, 0);
                    Result.Text = "The two files are different";
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Functions.getRoot());
        }
    }
}
