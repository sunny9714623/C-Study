﻿using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            //WorkWithDirectories();
            WorkWithFiles();
        }
        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);

            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());

            WriteLine("GetFolderPath(SpecialFolder)");
            WriteLine("{0,-33} {1}", " .System", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", " .ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", " .MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", " .Personal", GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,10} |{2,-7} | {3,19:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                }
            }
        }
        static void WorkWithDirectories()
        {
            // define a directory path for a new folder
            // starting in the user's folder
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with: {newFolder}");

            // check if it exits
            WriteLine($"Does it exist? {Exists(newFolder)}");

            // create directory
            WriteLine("Creating it.....");
            CreateDirectory(newFolder);
            WriteLine($"Does it exits? {Exists(newFolder)}");

            WriteLine("Confirm the directory exist, and then press ENTER:");
            ReadLine();

            // delete directory
            WriteLine("Deleting it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exist?{Exists(newFolder)}");

        }

        static void WorkWithFiles()
        {
            // define a directory path to output files
            // starting in the user's folder
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "OutputFiles");
            CreateDirectory(dir);

            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");

            WriteLine($"Working with:{textFile}");

            // check if a file exits
            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello,c#");
            textWriter.Close(); //close file and release resources

            WriteLine($"Does it exist? {File.Exists(textFile)}");

            // copy the file,and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

            //WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            //Write("Confirm the files exist,and then press ENTER: ");
            //ReadLine();

            ////delete file
            //File.Delete(textFile);

            //WriteLine($"Does it exist? {File.Exists(textFile)}");

            ////read from the text file backup
            //WriteLine($"Reading contents of {backupFile}:");
            //StreamReader textReader = File.OpenText(backupFile);
            //WriteLine(textReader.ReadToEnd());
            //textReader.Close();

            // Managing paths
            WriteLine($"Folder Name:{GetDirectoryName(textFile)}");
            WriteLine($"File Name:{GetFileName(textFile)}");
            WriteLine("File Name without extension: {0}", GetFileNameWithoutExtension(textFile));
            WriteLine($"File extension:{GetExtension(textFile)}");
            WriteLine($"Random File Name:{GetRandomFileName()}");
            WriteLine($"Temprorary File Name:{GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"Contains {info.Length} bytes");


            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");

            //FileStream file = File.Open(pathToFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            var infos = new FileInfo(backupFile);
            WriteLine("Is the backup file compressed? {0}", infos.Attributes.HasFlag(FileAttributes.Compressed));
            
        }
    }
}
