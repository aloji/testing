using Xunit;

namespace TodoApi.Tests
{
    [CollectionDefinition(nameof(TodoApiCollection))]
    public class TodoApiCollection : ICollectionFixture<TodoApiMockWebApplicationFactory>
    {
    }
}
