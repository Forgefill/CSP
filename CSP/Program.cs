using CSP.Models;
using System.Runtime.InteropServices;
using System.Text;

namespace CSPTimetable
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var subjects = new List<Subject>
            {
                new Subject { Id = 1, Name = "OOP", IsLecture = true },
                new Subject { Id = 2, Name = "DB", IsLecture = true },
                new Subject { Id = 3, Name = "Programming Fundamentals", IsLecture = true },
                new Subject { Id = 4, Name = "Data Structures and Algorithms", IsLecture = true },
                new Subject { Id = 5, Name = "Computer Networks", IsLecture = true },
                new Subject { Id = 6, Name = "Operating Systems", IsLecture = true },
                new Subject { Id = 10, Name = "Software Engineering", IsLecture = true }
            };

            var classrooms = new List<Classroom>
            {
                new Classroom { Id = 1, Name = "306", Capacity = 100 },
                new Classroom { Id = 2, Name = "43", Capacity = 70 },
                new Classroom { Id = 3, Name = "221", Capacity = 40 },
                new Classroom { Id = 4, Name = "01", Capacity = 100 },
                new Classroom { Id = 5, Name = "203", Capacity = 32 },
                new Classroom { Id = 6, Name = "202", Capacity = 32 }
            };

            var professors = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Black", Subjects = new List<Subject> { subjects[0] } },
                new Teacher { Id = 2, Name = "Green", Subjects = new List<Subject> { subjects[1] } },
                new Teacher { Id = 3, Name = "Purple", Subjects = new List<Subject> { subjects[4] } },
                new Teacher { Id = 4, Name = "Grey", Subjects = new List<Subject> { subjects[2] } },
                new Teacher { Id = 5, Name = "White", Subjects = new List<Subject> { subjects[5] } },
                new Teacher { Id = 7, Name = "Yellow", Subjects = new List<Subject> { subjects[6] } },
                new Teacher { Id = 10, Name = "Red", Subjects = new List<Subject> { subjects[3] } },
            };

            var timeslots = new List<Timeslot>
            {
                new Timeslot { Id = 1, TimeSlot = "Mon 09:00-10:30" },
                new Timeslot { Id = 2, TimeSlot = "Mon 10:40-12:10" },
                new Timeslot { Id = 3, TimeSlot = "Mon 12:20-13:50" },
                new Timeslot { Id = 4, TimeSlot = "Tue 09:00-10:30" },
                new Timeslot { Id = 5, TimeSlot = "Tue 10:40-12:10" },
                new Timeslot { Id = 6, TimeSlot = "Tue 12:20-13:50" },
                new Timeslot { Id = 7, TimeSlot = "Sun 09:00-10:30" },
                new Timeslot { Id = 8, TimeSlot = "Sun 10:40-12:10" },
                new Timeslot { Id = 9, TimeSlot = "Sun 12:20-13:50" }
            };


            var groups = new List<Group>
            {
                new Group { Id = 1, Name = "G-1", NumberOfStudents = 27, Subjects = subjects },
                new Group { Id = 2, Name = "G-2", NumberOfStudents = 30, Subjects = subjects }
            };

            CSPAlgo solver = new CSPAlgo(subjects, classrooms, professors, groups, timeslots);
            Timetable timetable = solver.GenerateTimetable();

            PrintTimetable(timetable);
        }



        static void PrintTimetable(Timetable timetable)
        {

            Console.WriteLine("Generated timetable:");
            Console.WriteLine(new string('-', 134));
            Console.WriteLine("| {0, -10} | {1, -40} | {2, -23} | {3, -15} | {4, -10} | {5, -17} |", "Group", "Subject", "Teacher", "Classroom", "Capacity", "Timeslot");
            Console.WriteLine(new string('-', 134));

            foreach (var scheduledClass in timetable.ScheduledClasses)
            {
                Console.WriteLine("| {0, -10} | {1, -40} | {2, -23} | {3, -15} | {4, -10} | {5, -17} |",
                    scheduledClass.Group.Name,
                    scheduledClass.Subject.Name,
                    scheduledClass.Professor.Name,
                    scheduledClass.Classroom.Name,
                    scheduledClass.Classroom.Capacity,
                    scheduledClass.Timeslot.TimeSlot);
            }

            Console.WriteLine(new string('-', 134));
        }
    }
}