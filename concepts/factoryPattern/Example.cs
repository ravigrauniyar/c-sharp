using System;
namespace Internship
{
    // INSTITUTE FACTORY CLASS AND ITS IMPLEMENTATION
    public abstract class Institute
    {
        public abstract ITeacher viewTeacher();
        public abstract IStudent viewStudent();
    }
    public class HSEBFaculty : Institute
    {
        public override ITeacher viewTeacher()
        {
            return new FullTimeTeacher();
        }
        public override IStudent viewStudent()
        {
            return new PlusTwoStudent();
        }
    }
    public class TUFaculty : Institute
    {
        public override ITeacher viewTeacher()
        {
            return new PartTimeTeacher();
        }
        public override IStudent viewStudent()
        {
            return new BachelorStudent();
        }
    }
    
    // ITEACHER INTERFACE AND ITS CONCRETE CLASSES
    public interface ITeacher
    {
        void shift();
        void salary();
    }
    public class PartTimeTeacher : ITeacher
    {
        public void salary()
        {
            Console.WriteLine("Teacher - Part Time Salary\n");
        }

        public void shift()
        {
            Console.WriteLine("Teacher - Part Time Shift\n");
        }
    }
    public class FullTimeTeacher : ITeacher
    {
        public void salary()
        {
            Console.WriteLine("Teacher - Full Time Salary\n");
        }

        public void shift()
        {
            Console.WriteLine("Teacher - Full Time Shift\n");
        }
    }
    // ISTUDENT INTERFACE AND ITS CONCRETE CLASSES
    public interface IStudent
    {

        void shift();
        void fee();
    }
    public class PlusTwoStudent : IStudent
    {
        public void fee()
        {
            Console.WriteLine("Student - Plus Two Fee\n");
        }

        public void shift()
        {
            Console.WriteLine("Student - Plus Two Shift\n");
        }
    }
    public class BachelorStudent : IStudent
    {
        public void fee()
        {
            Console.WriteLine("Student - Bachelor Fee\n");
        }
        public void shift()
        {
            Console.WriteLine("Student - Bachelor Shift\n");
        }
    }
    // A FACULTY APP THAT GIVES FACULTY INFORMATION TO THE CLIENT
    public class Faculty
    {
        private readonly Institute _institute;
        public Faculty(Institute institute)
        {
            _institute = institute;
        }
        public void GetInformation()
        {
            var teacher = _institute.viewTeacher();
            var student = _institute.viewStudent();

            teacher.salary();
            teacher.shift();
            student.fee();
            student.shift();
        }
    }
    // DEMO CLASS TO RUN MAIN METHOD FOR CLIENT
    public class FactoryExample
    {
        public void designPatternDemo()
        {
            Institute hsebInstitute = new HSEBFaculty();
            Faculty hsebFaculty = new Faculty(hsebInstitute);

            Console.WriteLine("\nHSEB Faculty Information:\n");
            hsebFaculty.GetInformation();

            Institute tuInstitute = new TUFaculty();
            Faculty tuFaculty = new Faculty(tuInstitute);

            Console.WriteLine("\nTU Faculty Information:\n");
            tuFaculty.GetInformation();
        }
    }
}