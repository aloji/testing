using Xunit;

namespace TodoApi.Tests.net5._0
{
    [CollectionDefinition(nameof(TodoApiCollection))]
    public class TodoApiCollection : ICollectionFixture<TodoApiMockWebApplicationFactory>
    {
    }
}
