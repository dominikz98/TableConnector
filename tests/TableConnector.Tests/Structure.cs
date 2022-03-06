using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TableConnector.Tests.Data;
using Xunit;

namespace TableConnector.Tests
{
    public class Structure
    {
        [Fact]
        public async Task General_Render()
        {
            var table = new StudentTable();
            var rendered = await table.Render(CancellationToken.None);

            Assert.NotNull(rendered);
            Assert.Equal(2, rendered.Rows.Count);
            Assert.Equal(2, rendered.Rows.First().Columns.Count);
            Assert.Equal("Star", rendered.Rows.First().Columns.First().Value);
        }

        [Fact]
        public async Task General_Print()
        {
            var table = new StudentTable();
            var printed = await table.Render(CancellationToken.None);

            Assert.NotNull(printed);
            Assert.Equal(2, printed.Rows.Count);
            Assert.Equal(2, printed.Rows.First().Columns.Count);
            Assert.Equal("Star", printed.Rows.First().Columns.First().Value);
        }
    }
}