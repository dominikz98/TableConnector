# TableConnector

# Minimal setup:
```csharp
var table = new StudentTable();
var rendered = await table.Render(CancellationToken.None);

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

    public override Task<IReadOnlyCollection<Student>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
        => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
        {
            new Student("Spongebob", "Squarepants"),
            new Student("Patrick", "Star")
        });
}
```