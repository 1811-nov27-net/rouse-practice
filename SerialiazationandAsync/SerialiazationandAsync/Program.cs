using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialiazationandAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = GetPeople();
            var fileName = @"C:\Revature\PeopleData.xml";
            Task<List<Person>> listTask = DeserializeFromFileAsync(fileName);

            // At this point in time, I have not yet started reading the file

            // Synchronously waits on the task to get the return value
            List<Person> list = listTask.Result;
            // Only do .Result in Main()

            list[0].Id *= 2;
            Console.WriteLine(list[0].Name.MiddleName);

            SerializeToFile(fileName, list);
        }

        private static void SerializeToFile(string fileName, IList<Person> people)
        {
            // First, we need to convert the data in memory (the list of people) into some byte representation (aka serial representation)
            // We can use many formats for this; we could make up our own, use JSON, XML, orn some other format

            // "reflection" is when C# 'looks at itself', it lets you, for example, iterate through all the properties of a code in code
            var serializer = new XmlSerializer(typeof(List<Person>));

            // Second, we need to write that representation to a file
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, people);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Some error in file I/O: {e.Message}");
            }
            finally
            {
                fileStream?.Dispose();
            }   
        }

        // As soon as we start doing something asynchronously:
        // 1. Await some async method
        // 2. Make your method async, returning Task, and put 'Async' at end of method name
        // 3. 

        // Async on a method is a flag to tell people that this returns type 'Task', and needs to be awaited to actually get the result
        public async static Task<List<Person>> DeserializeFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> result;

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    // Copy the fileStream asynchronously into the memoryStream
                    await fileStream.CopyToAsync(memoryStream);

                    // When we await a task, other code can run in the meantime (like on another thread); out web server can receive other requests, etc, and WHEN the operation is done, 
                }

                // Doesn't support generics, returns "object", have to explicitly cast
                result = (List<Person>)serializer.Deserialize(memoryStream);
            }
             // Will automatically call .Dispose as though it was in 'finally'

            return result;
        }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 19,
                    Name = new Name
                    {
                        FirstName = "Devin",
                        MiddleName = "Andrew",
                        LastName = "Rouse"
                    },
                    Address = new Address
                    {
                        Street = "6826 Stampede Blvd NW",
                        City = "Bremerton",
                        State = "Washington"
                    },
                    Age = 26,
                    Nicknames = new List<string>
                    {
                        "Dev"
                    }
                },
                new Person
                {
                    Name = new Name
                    {
                        FirstName = "Joe",
                        LastName = "Average"
                    }
                }
            };
        }
    }

    
}
