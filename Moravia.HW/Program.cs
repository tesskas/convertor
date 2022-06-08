using System;
using System.IO;
using System.Xml.Linq;
using Moravia.HW.File;
using Moravia.HW.Storage;
using Newtonsoft.Json;

namespace Moravia.HW
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        static void previous()
        {
            // UPDATE 1 - Environment.CurrentDirectory is changeable
            var location = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            var sourceFileName = Path.Combine(location, "..\\..\\..\\SourceFiles\\Document1.xml");
            var targetFileName = Path.Combine(location, "..\\..\\..\\TargetFiles\\Document1.json");
            
            // UPDATE 2 - declaration
            string input = "";
            StreamReader reader = null;
            FileStream sourceStream = null;
            try
            {
                sourceStream = System.IO.File.Open(sourceFileName, FileMode.Open);
                reader = new StreamReader(sourceStream);
                input = reader.ReadToEnd();
            }
            // UPDATE 4 - be more specific
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File is not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //UPDATE 3a - close and dispose reader
            finally
            {
                reader.Close();
                sourceStream.Close();
            }
            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            var serializedDoc = JsonConvert.SerializeObject(doc);
            var targetStream = System.IO.File.Open(targetFileName, FileMode.Create, FileAccess.Write);

            // UPDATE 3b - close and dispose writer
            // var sw = new StreamWriter(targetStream);
            // sw.Write(serializedDoc);
            using (var sw = new StreamWriter(targetStream))
            {
                // UPDATE 5 - why ToString?
                sw.WriteLine(serializedDoc.ToString());
            }
        }

        static void print(string title, IFile file)
        {
            Console.WriteLine(title);
            Console.WriteLine(file.ToString());
        }

        static void httpTest()
        {
            var location = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            // Load from HTTP storage
            var url = "https://www.w3schools.com/xml/note.xml";
            var xmlFile = new XMLFile();
            var httpStorage = new HTTPStorage();
            httpStorage.Read(url, xmlFile);
            Console.WriteLine("Reading from URL: {0}", url);

            // Conversion XML to JSON
            print("XML:", xmlFile);
            var jsonFile = new JSONFile(xmlFile.ObjectContent);
            print("JSON:", jsonFile);

            // Save into local directory
            var targetFileName = Path.Combine(location, "..\\..\\..\\TargetFiles\\note.json");
            var fileStorage = new FileStorage();
            fileStorage.Write(targetFileName, jsonFile);
        }

        
        static void fileTest()
        {
            var location = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            // FILE Section
            var sourceAddress = Path.Combine(location, "..\\..\\..\\SourceFiles\\example.json");
            var targetAddress = Path.Combine(location, "..\\..\\..\\TargetFiles\\example.xml");
            var jsonFile = new JSONFile();
            var fileStorage = new FileStorage();
            fileStorage.Read(sourceAddress, jsonFile);

            // Conversion JSON to XML
            print("JSON:", jsonFile);
            var xmlFile = new XMLFile(jsonFile.ObjectContent);
            print("XML:", xmlFile);

            // Save into local directory
            fileStorage.Write(targetAddress, xmlFile);
        }

        static void Main(string[] args)
        {
            // previous();

            httpTest();
            fileTest();
        }
    }
}
