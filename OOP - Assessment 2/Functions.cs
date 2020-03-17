using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Assessment_2
{
    class Functions
    {
        //Specifies static root directory
        private static string folder = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\data";

        //Returns the static root directory
        public static string getRoot()
        {
            return folder;
        }

        //Returns array containing all files found in root directory
        public static FileInfo[] readFiles()
        {
            DirectoryInfo root = new DirectoryInfo(folder);
            //Finds all files regardless of their extension
            FileInfo[] temp = root.GetFiles("*.*");
            //Returns "FileInfo" array
            return temp;
        }

        //Function that takes in 2 FileInfo instances and returns true if they are the same
        public static bool isSame(FileInfo fileOne, FileInfo fileTwo)
        {
            //First checks length of files (quick check to see if they aren't equal)
            if (fileOne.Length != fileTwo.Length)
            {
                return false;
            }
            else
            {
                //Compare the files byte by byte
                if (File.ReadAllBytes(fileOne.FullName).SequenceEqual(File.ReadAllBytes(fileTwo.FullName)))
                {
                    return true;
                }
                //Not the same
                else
                {
                    return false;
                }
            }
        }
    }
}
