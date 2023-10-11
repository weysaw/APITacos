using APITacos;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace APITacosTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient _client;
        private const string Url = "/api/tacos";
        public UnitTest1(WebApplicationFactory<Program> factory, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsListOfTacos()
        {
            var response = await _client.GetAsync(Url);
            
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(content);

            Assert.NotEmpty(content);
        }

        [Fact]
        public async Task? Get_WithValidId_ReturnSpecificTaco()
        {
            const int id = 0;
            var response = await _client.GetAsync($"{Url}/{id}");

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(content);

            Assert.NotEmpty(content);
            Assert.NotNull(content);
        }
    }
}