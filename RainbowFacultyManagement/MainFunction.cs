using System;

namespace RainbowFacultyManagement
{
    class MainFunction
    {
        static void Main(string[] args)
        {
            bool flag = true;
            AddUpdateFacultyData obj = new AddUpdateFacultyData();
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Rainbow School Faculty Management System");
                Console.WriteLine("\n---------------------------------------------------");
                Console.WriteLine("\nPlease select a menu option and press enter");
                Console.WriteLine("\n********************************" +
                    "\n 1. Add Faculty record" +
                    "\n 2. Update Faculty record" +
                    "\n 3. Display all records" +
                    "\n 4. Search for a Faculty" +
                    "\n 5. Exit" +
                    "\n********************************");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        obj.AddRecords();
                        break;
                    case "2":
                        obj.UpdateRecords();
                        break;
                    case "3":
                        obj.DisplayAllRecords();
                        break;
                    case "4":
                        obj.DisplayRecordByFacultyId();
                        break;
                    case "5":
                        flag = false;
                        break;
                    default:
                        Main(null);
                        break;
                }
                
            }
        }
    }
}
