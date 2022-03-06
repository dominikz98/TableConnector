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
    public class Accessors
    {
        [Fact]
        public async Task Not_Set()
        {
            var table = new EmptyTable();
            var exc = await Assert.ThrowsAsync<AccessorNotSetException>(() => table.Render(CancellationToken.None));
            Assert.Equal(nameof(IColumnRenderer<Student>.RenderAccessor), exc.Accessor);
        }

        class EmptyTable : Table<Student>
        {
            public override string Name => "Empty-Table";

            public override IColumnRenderer<Student>[] Columns => new ColumnRenderer<Student>[]
            {
            new ColumnRenderer<Student>()
            {
                Header = "Name",
                Name = "Name",
            },
            };

            public override Task<IReadOnlyCollection<Student>> Load(IReadOnlyCollection<ITableFilter> filter, CancellationToken cancellationToken)
                => Task.FromResult<IReadOnlyCollection<Student>>(new List<Student>()
                {
                    new Student("Spongebob", "Squarepants"),
                });
        }
    }
}
