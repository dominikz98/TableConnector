using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TableConnector.Contracts;
using TableConnector.Exceptions;
using TableConnector.Models;
using TableConnector.Tests.Data;
using Xunit;

namespace TableConnector.Tests
{
    public class Columns
    {
        [Fact]
        public async Task Missing_Header()
        {
            var table = new MissingHeaderTable();
            var exc = await Assert.ThrowsAsync<MissingColumnInfoException>(() => table.Render(CancellationToken.None));
            Assert.Equal(nameof(IColumn<Student>.Header), exc.Property);
        }

        [Fact]
        public async Task Header_NotUnique()
        {
            var table = new HeaderNotUniqueTable();
            var exc = await Assert.ThrowsAsync<HeaderNotUniqueException>(() => table.Render(CancellationToken.None));
            Assert.Equal("Name", exc.Header);
        }
    }

    class MissingHeaderTable : Table<Student>
    {
        public override string Name => "MissingHeader-Table";

        public override IColumnRenderer<Student>[] Columns => new ColumnRenderer<Student>[]
        {
            new ColumnRenderer<Student>()
            {
                Name = "Name",
                RenderAccessor = (entry) => entry.Last_Name
            },
        };

        public override Task<IReadOnlyCollection<Student>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
            => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
            {
                    new Student("Spongebob", "Squarepants"),
            });
    }

    class HeaderNotUniqueTable : Table<Student>
    {
        public override string Name => "HeaderNotUnique-Table";

        public override IColumnRenderer<Student>[] Columns => new ColumnRenderer<Student>[]
        {
            new ColumnRenderer<Student>()
            {
                Header = "Name",
                Name = "Name",
                RenderAccessor = (entry) => entry.Last_Name
            },
            new ColumnRenderer<Student>()
            {
                Header = "Name",
                Name = "First_Name",
                RenderAccessor = (entry) => entry.First_Name
            },
        };

        public override Task<IReadOnlyCollection<Student>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
            => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
            {
                    new Student("Spongebob", "Squarepants"),
            });
    }
}
