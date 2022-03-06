using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TableConnector.Contracts;
using TableConnector.Models;

namespace TableConnector.Tests.Data
{
    public class StudentTable : Table<Student>
    {
        public override string Name => "Student-Table";

        public override IColumnRenderer<Student>[] Columns => new ColumnRenderer<Student>[]
        {
            new ColumnRenderer<Student>()
            {
                Header = "Last_Name",
                Name = "Name",
                RenderAccessor = (student) => student.Last_Name,
                IsPrintable = false
            },
            new ColumnRenderer<Student>()
            {
                Header = "First_Name",
                Name = "Surename",
                RenderAccessor = (student) => student.First_Name,
                IsPrintable = false
            }
        };

        public override Task<IReadOnlyCollection<Student>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
            => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
            {
                new Student("Spongebob", "Squarepants"),
                new Student("Patrick", "Star")
            });
    }
}
