# TableConnector

# Minimal setup:
```csharp
var table = new StudentTable();
var rendered = await table.Render<Student>(CancellationToken.None);

class StudentTable : Table<Student>
{
    public override string Name => "Student-Table";

    public override IColumnRenderer<Student>[] Columns => new ColumnRenderer<Student>[]
    {
        new ColumnRenderer<Student>()
        {
            Header = "Last_Name",
            Name = "Name",
            RenderAccessor = (student) => student.Last_Name
        },
        new ColumnRenderer<Student>()
        {
            Header = "First_Name",
            Name = "Surename",
            RenderAccessor = (student) => student.First_Name
        }
    };

    public override Task<IReadOnlyCollection<Student>> Load<TFilter>(ITableFilter<TFilter> filter, CancellationToken cancellationToken)
        => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
        {
            new Student("Spongebob", "Squarepants"),
            new Student("Patrick", "Star")
        });
}

class Student
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
```