using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentsCount = Students.Count;
            int studentsHigher = 0;
            if (studentsCount < 5) throw new InvalidOperationException();
            else
            {
                studentsCount = studentsCount / 5;

                foreach(Student student in Students)
                {
                    foreach(double grade in student.Grades)
                    {
                        if (grade > averageGrade) studentsHigher++;
                    }
                }

                if (studentsHigher / studentsCount < 1) return 'A';
                else if (studentsHigher / studentsCount < 2) return 'B';
                else if (studentsHigher / studentsCount < 3) return 'C';
                else if (studentsHigher / studentsCount < 4) return 'D';
                else return 'F';
            }

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading requires at least 5 students.");
            else base.CalculateStudentStatistics(name);
        }
    }
}
