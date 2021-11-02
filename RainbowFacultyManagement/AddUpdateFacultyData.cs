using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RainbowFacultyManagement
{

    public class AddUpdateFacultyData
    {
        
        public string filePath = @"C:\\FSD Program\\Faculty_data.txt";
        public void DisplayAllRecords()
        {

            try
            {
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
                foreach (var item in facultyList)
                {
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Faculty Id : " + item.facultyId);
                    Console.WriteLine("\nFaculty Name : " + item.facultyName);
                    Console.WriteLine("\nFaculty Class : " + item.facultyClass);
                    Console.WriteLine("**********************************************");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayRecordByFacultyId()
        {
            try
            {
                Console.WriteLine("Enter Faculty ID : ");
                var facultyId = Convert.ToInt32(Console.ReadLine());
                bool flag = true;
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
                foreach (var item in facultyList)
                {
                    if (item.facultyId == facultyId)
                    {
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Faculty Id : " + item.facultyId);
                        Console.WriteLine("\nFaculty Name : " + item.facultyName);
                        Console.WriteLine("\nFaculty Class : " + item.facultyClass);
                        Console.WriteLine("**********************************************");
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Faculty not found. Please try again.");
                    DisplayRecordByFacultyId();
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void AddRecords()
        {
            try
            {
                bool flag = true;
                Console.WriteLine("Enter Faculty ID : ");
                var FacultyId = Convert.ToInt32(Console.ReadLine());
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData)
                                      ?? new List<Data>();

                if (FacultyId > 0)
                {
                    foreach (var item in facultyList)
                    {

                        if (item.facultyId == FacultyId)
                        {
                            Console.WriteLine("Faculty ID exists in records. Please enter a new faculty ID");
                            AddRecords();
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("\nEnter Faculty Name : ");
                        var FacultyName = Console.ReadLine();
                        Console.WriteLine("\nEnter Faculty Class : ");
                        var FacultyClass = Console.ReadLine();
                        // Add any new faculty
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
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateRecords()
        {
            try
            {
                bool flag = true;
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                var facultyList = JsonConvert.DeserializeObject<List<Data>>(jsonData);
                Console.Write("Enter Faculty ID to Update faculty : ");
                var facultyId = Convert.ToInt32(Console.ReadLine());
                if (facultyId > 0)
                {
                    foreach (var item in facultyList)
                    {

                        if (item.facultyId == facultyId)
                        {
                            Console.Write("Enter new Faculty name : ");
                            var facultyName = Convert.ToString(Console.ReadLine());
                            Console.Write("Enter new Faculty class : ");
                            var facultyClass = Convert.ToString(Console.ReadLine());
                            item.facultyName = !string.IsNullOrEmpty(facultyName) ? facultyName : "";
                            item.facultyClass = !string.IsNullOrEmpty(facultyClass) ? facultyClass : "";
                            flag = false;
                            break;
                        }

                    }
                    if (flag)
                    {
                        Console.WriteLine("Faculty not found. Please try again");
                        UpdateRecords();
                    }

                    jsonData = JsonConvert.SerializeObject(facultyList);
                    System.IO.File.WriteAllText(filePath, jsonData);
                    Console.WriteLine("Faculty record updated successfully!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
       
    }
}

