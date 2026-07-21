using System;

namespace MVCPattern
{
    // Model
    class Student
    {
        public string Name { get; set; } = "";
        public string RollNo { get; set; } = "";
    }

    // View
    class StudentView
    {
        public void DisplayStudentDetails(string name, string rollNo)
        {
            Console.WriteLine("Student Details");
            Console.WriteLine("----------------");
            Console.WriteLine("Name    : " + name);
            Console.WriteLine("Roll No : " + rollNo);
        }
    }

    // Controller
    class StudentController
    {
        private Student model;
        private StudentView view;

        public StudentController(Student model, StudentView view)
        {
            this.model = model;
            this.view = view;
        }

        public void UpdateView()
        {
            view.DisplayStudentDetails(model.Name, model.RollNo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student model = new Student
            {
                Name = "Barnabas",
                RollNo = "231FA04776"
            };

            StudentView view = new StudentView();

            StudentController controller =
                new StudentController(model, view);

            controller.UpdateView();
        }
    }
}