namespace TableConnector.Tests.Data
{
    public class Student
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public Student(string first_Name, string last_Name)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
        }

        public Student() : this(string.Empty, string.Empty) { }
    }
}
