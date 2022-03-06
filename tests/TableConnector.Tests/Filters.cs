using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TableConnector.Contracts;
using TableConnector.Models;
using TableConnector.Tests.Data;
using Xunit;

namespace TableConnector.Tests
{
    public class Filters
    {
        [Fact]
        public async Task Bool_Filter()
        {
            var table = new FilterTable();
            var filter = new List<ITableFilter>()
            {
                new RemovePatrickFilter()
            };
            var rendered = await table.Render(filter, CancellationToken.None);

            Assert.NotNull(rendered);
            Assert.Equal(1, rendered.Rows.Count);
            Assert.Equal("Squarepants", rendered.Rows.First().Columns.First().Value);
        }
    }

    class FilterTable : Table<Student>
    {
        public override string Name => "Filter-Table";

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
        {
            var result = new List<Student>()
            {
                new Student("Spongebob", "Squarepants"),
                new Student("Patrick", "Star")
            };

            if (FilterResolver.TryGet<RemovePatrickFilter>(filter, out var removePatrick))
                result = result.Where(x => !x.First_Name.Equals("patrick", StringComparison.OrdinalIgnoreCase)).ToList();

            return Task.FromResult<IReadOnlyCollection<Student>>(result);
        }
    }

    class RemovePatrickFilter : ITableFilter { }
}
