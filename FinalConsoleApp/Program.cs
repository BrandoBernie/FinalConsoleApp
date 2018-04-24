using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }


        private static void ShowMenu()
        {
            Console.WriteLine("Final Console Demo");
            Console.WriteLine();


            string option;
            bool repeat = true;

            do
            {
                Console.WriteLine("Make a selection:");
                Console.WriteLine("1- Show Instructors");
                Console.WriteLine("2- Show Students");
                Console.WriteLine("3- Find a Student");
                //Console.WriteLine("4- Find an Instructor");
                Console.WriteLine("0- Exit");
                Console.Write("Enter an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        //Get instructors
                        ShowInstructors();
                        break;
                    case "2":
                        //Get students
                        ShowStudents();
                        break;
                    case "3":
                        //Find students
                        FindStudent();
                        break;
                    //case "4":
                    //FindInstructor();
                    //FindPerson("Instructor");
                    //    break;
                    case "0":  // End
                        repeat = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong option. Please re-enter\n");
                        break;
                }

            } while (repeat);
        }

        private static void FindStudent()
        {
            Console.WriteLine("Enter the student name:  ");
            string name = Console.ReadLine();

            StudentDataMapper student_mapper = new StudentDataMapper();
            var searchStudents = student_mapper.Find(name);

            Console.WriteLine("--- Search Results ---");

            if(searchStudents.Count() > 0)
            {
                foreach(var s in searchStudents)
                {
                    Console.WriteLine(s.StudentName);
                }
            }
            else
            {
                Console.WriteLine($"No records found for {name}");
            }
            Console.WriteLine();
            
        }

        private static void ShowInstructors()
        {
            InstructorDataMapper instructor_mapper = new InstructorDataMapper();
            var instructors = instructor_mapper.Select();

            var output = new StringBuilder();
            output.AppendLine("ID\tFirst Name\tLast Name\tRank");
            output.AppendLine("--\t------------\t---------\t--------------");

            foreach(var instructor in instructors)
            {
                output.Append(instructor.ID.ToString());
                output.Append("\t");
                output.Append(instructor.FirstName.PadRight(10));
                output.Append("\t");
                output.Append(instructor.LastName.PadRight(10));
                output.Append("\t");
                output.Append(instructor.Rank.PadRight(10));
                output.AppendLine();
            }
            Console.WriteLine(output.ToString());
        }

        private static void ShowStudents()
        {
            //Instantiate the Student Data Mapper class
            StudentDataMapper student_mapper = new StudentDataMapper();
            var students = student_mapper.Select();
            //List<Student> students = student_mapper.Select();

            var output = new StringBuilder();
            output.AppendLine("Student ID\tFirst Name\tLast Name\tEnroll Date\tMajor");
            output.AppendLine("-----------\t----------\t-----------\t---------\t----------");

            //Loop through students list and display values
            foreach(var stu in students)
            {
                output.Append(stu.ID.ToString().PadRight(10));
                output.Append("\t");
                output.Append(stu.FirstName.PadRight(10));
                output.Append("\t");
                output.Append(stu.LastName.PadRight(10));
                output.Append("\t");
                output.Append(string.Format("{0:d}",stu.EnrollDate).PadRight(10));
                output.Append("\t");
                output.Append(stu.Major.PadRight(10));

                output.AppendLine();
            }
            Console.WriteLine(output.ToString());
        }
    }
}
