using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RainbowFacultyManagement
{

    public class AddUpdateFacultyData
    {
        
        public string filePath = @"C:\\FSD Program\\Faculty_data.txt";
        public void DisplayAllRecords()
        {
            
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            foreach (var item in facultyList)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("Faculty Id : "+item.facultyId);
                Console.WriteLine("\nFaculty Name : "+item.facultyName);
                Console.WriteLine("\nFaculty Class : "+item.facultyClass);
                Console.WriteLine("**********************************************");
            }
            Console.ReadKey();
        }

        public void DisplayRecordByFacultyId()
        {
            Console.WriteLine("Enter Faculty ID : ");
            var facultyId = Convert.ToInt32(Console.ReadLine());
            
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            foreach (var item in facultyList)
            {
                if(item.facultyId == facultyId)
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Faculty Id : " + item.facultyId);
                    Console.WriteLine("\nFaculty Name : " + item.facultyName);
                    Console.WriteLine("\nFaculty Class : " + item.facultyClass);
                    Console.WriteLine("**********************************************");
                    break;
                }
            }
            Console.ReadKey();
        }

        public void AddRecords()
        {
            Console.WriteLine("Enter Faculty ID : ");
            var FacultyId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter Faculty Name : ");
            var FacultyName = Console.ReadLine();
            Console.WriteLine("\nEnter Faculty Class : ");
            var FacultyClass = Console.ReadLine();
            
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData)
                                  ?? new List<Data>();

            // Add any new employees
            facultyList.Add(new Data()
            {
                facultyId = FacultyId,
                facultyName = FacultyName,
                facultyClass = FacultyClass
            });

            // Update json data string
            jsonData = JsonConvert.SerializeObject(facultyList);
            System.IO.File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Faculty record created successfully!");
            Console.ReadKey();
        }

        public void UpdateRecords()
        {
            
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
            Console.Write("Enter Faculty ID to Update faculty : ");
            var facultyId = Convert.ToInt32(Console.ReadLine());
            if (facultyId > 0)
            {
                Console.Write("Enter new Faculty name : ");
                var facultyName = Convert.ToString(Console.ReadLine());
                Console.Write("Enter new Faculty class : ");
                var facultyClass = Convert.ToString(Console.ReadLine());


                foreach (var item in facultyList)
                {

                    if(item.facultyId == facultyId)
                    {
                        item.facultyName = !string.IsNullOrEmpty(facultyName) ? facultyName : "";
                        item.facultyClass = !string.IsNullOrEmpty(facultyClass) ? facultyClass : "";
                        break;
                    }
                                        
                }
                jsonData = JsonConvert.SerializeObject(facultyList);
                System.IO.File.WriteAllText(filePath, jsonData);
                Console.WriteLine("Faculty record updated successfully!");
                Console.ReadKey();
            }
        }
        
    }
}

