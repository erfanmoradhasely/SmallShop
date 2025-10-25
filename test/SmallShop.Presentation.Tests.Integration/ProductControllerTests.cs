using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RESTFulSense.Clients;
using SmallShop.Application.Products.Create;
using SmallShop.Application.Products.Edit;
using SmallShop.Presentation.Api;
using SmallShop.Presentation.Api.Models;
using SmallShop.Query.Products.DTOs;
using System.Net.Http.Headers;


namespace SmallShop.Presentation.Api.Tests.Integration
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private const string Path = "/api/product";
        private readonly RESTFulApiFactoryClient _restClient;
        private readonly WebApplicationFactory<Program> _factory;

        public ProductControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            var httpClient = factory.CreateClient();
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW5AbG9jYWxob3N0LmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImFkbWluQGxvY2FsaG9zdC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjhlNDQ1ODY1LWEyNGQtNDU0My1hNmM2LTk0NDNkMDQ4Y2RiOSIsImV4cCI6MTc5NzQyMzAyNiwiaXNzIjoiU21hbGxTaG9wLkFwaSIsImF1ZCI6IlNtYWxsU2hvcFVzZXIifQ.A0tsItKKMuJTP45S6rSj1g9LOC7skpcrgOlRn3uvQJI";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _restClient = new RESTFulApiFactoryClient(httpClient);
        }



        [Fact]
        public async void Should_GetAllProducts()
        {
            //arrange

            //act
            var actual = await _restClient.GetContentAsync<ApiResult<ProductFilterResult>>(Path);

            //assert
            actual.IsSuccess.Should().BeTrue();
            actual.Data.Data.Should().HaveCountGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async void Should_CreateNewProduct()
        {
            //arrange
            var command = CreateSomeProduct();

            //act
            
            var id = await _restClient.PostContentAsync<CreateProductCommand, ApiResult<Guid>>(Path, command);
            var result = await _restClient.GetContentAsync<ApiResult<ProductFilterResult>>(Path);

            //assert
            result.Data.Data.Should().ContainSingle(x => x.Id == id.Data);
            await _restClient.DeleteContentAsync($"{Path}?Id={id.Data}");
        }

        private static CreateProductCommand CreateSomeProduct()
        {
            return new CreateProductCommand
            {
                Name = "Iphone 16",
                IsAvailable = true,
                ManufacturerEmail = "Aaapple@gmail.com",
                ManufacturerPhoneNumber = "09121010101",
                ProductionDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-4)),
                UserId = Guid.NewGuid(),
            };
        }



        [Fact]
        public async void Should_EditExistingProduct()
        {
            //arrange
            var createCommand = CreateSomeProduct();
            var id = await _restClient.PostContentAsync<CreateProductCommand, ApiResult<Guid>>(Path, createCommand);
            const string newManufacturerPhoneNumber = "09999911089";
            var editCommand = new EditProductCommand
            {
                Id = id.Data,
                Name = createCommand.Name,
                IsAvailable = createCommand.IsAvailable,
                ManufacturerEmail = createCommand.ManufacturerEmail,
                ManufacturerPhoneNumber = newManufacturerPhoneNumber,
                ProductionDate = createCommand.ProductionDate,
            };

            //act
            await _restClient.PutContentAsync(Path, editCommand);

            //assert
            var result = await _restClient.GetContentAsync<ApiResult<ProductFilterResult>>(Path);
            result.Data.Data.Should().ContainSingle(x => x.ManufacturerPhoneNumber == newManufacturerPhoneNumber);
            result.Data.Data.Should().NotContain(x => x.ManufacturerPhoneNumber == createCommand.ManufacturerPhoneNumber);
            await _restClient.DeleteContentAsync($"{Path}?Id={id.Data}");
        }
        

       

        [Fact]
        public async void Should_DeleteCourse()
        {
            //arrange
            var command = CreateSomeProduct();

            //act

            var id = await _restClient.PostContentAsync<CreateProductCommand, ApiResult<Guid>>(Path, command);

            //assert
            await _restClient.DeleteContentAsync($"{Path}?Id={id.Data}");
        }
    }
}
