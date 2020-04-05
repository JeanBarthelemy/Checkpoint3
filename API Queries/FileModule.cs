using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.IO;
using Newtonsoft.Json;

namespace API_Queries
{
    public class FileModule : NancyModule
    {
        public FileModule()
        {
            Get("/file/get/{path}", parameters => ReturnFileSelected(parameters.path));
            Get("/file/delete/{path}", parameters => DeleteFileSelected(parameters.path));
            Get("/file/put/{path}", parameters => AddNewFile(parameters.path));
        }

        public static string ReturnFileSelected(string path)
        {
            Files file = new Files(path);
            string filePath = "test-files/" + path;
            if (File.Exists(filePath))
            {
                file.Name = Path.GetFileNameWithoutExtension(path);
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var streamReader = new StreamReader(fileStream, Encoding.UTF8);
                string fileContent = streamReader.ReadToEnd();
                file.Content = fileContent;
                string fileJson = JsonConvert.SerializeObject(file);
                streamReader.Close();
                return fileJson;
            }
            else
            {
                return "File not existing";
            }
        }

        public static string DeleteFileSelected(string path)
        {
            Files file = new Files(path);
            string filePath = @"C:\Users\Student\source\repos\Checkpoint 3\API Queries\bin\Debug\test-files\" + path;
            if (File.Exists(filePath))
            {
                file.Name = Path.GetFileNameWithoutExtension(path);
                file.Content = "deleted content";
                string fileJson = JsonConvert.SerializeObject(file);
                string deletedText = "File of the following path has been deleted : " + filePath;
                File.Delete(filePath);
                return deletedText + "\r" + "\r" + fileJson;
            }
            else
            {
                return "File not existing";
            }
                
        }

        public static string AddNewFile(string path)
        {
            Files file = new Files(path);
            string filePath = @"C:\Users\Student\source\repos\Checkpoint 3\API Queries\bin\Debug\test-files\" + path;
            if (!File.Exists(filePath))
            {
                file.Name = Path.GetFileNameWithoutExtension(path);
                file.Content = "";
                string fileJson = JsonConvert.SerializeObject(file);
                var createdFile = File.Create(filePath);
                string createdText = "File has been created at the following path : " + filePath;
                createdFile.Close();
                return createdText + "\r" + "\r" + fileJson;
            }
            else
            {
                return "The file already exists";
            }
            
        }
    }
}
