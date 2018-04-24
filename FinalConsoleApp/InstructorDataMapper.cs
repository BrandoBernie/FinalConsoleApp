using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinalConsoleApp
{
    public class InstructorDataMapper : IDataMapper<Instructor>
    {
        private string path;
        public InstructorDataMapper()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "Instructors.txt";
        }

        private List<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();

            //Read from Instructors.txt (using the System.IO)
            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                //read each line in Instructors.txt and populate a new instructor object
                //with values from line within the file
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');//create array from CSV (Comma Separated Values)
                    var instructor = new Instructor
                    {
                        ID = Int16.Parse(elems[0]),
                        FirstName = elems[1],
                        LastName = elems[2],
                        Address = elems[3],
                        City = elems[4],
                        Province = elems[5],
                        PostalCode = elems[6],
                        Phone = elems[7],
                        Email = elems[8],
                        HireDate = DateTime.Parse(elems[9])
                        
                    };
                    //Add each new instructor (one for each line in Instructors.txt) to list
                    instructors.Add(instructor);
                }
            }


            return instructors;
        }

        public List<Instructor> Find(string LastName)
        {
            throw new NotImplementedException();
        }

        public List<Instructor> Select()
        {
            return GetInstructors();
        }
    }
}
