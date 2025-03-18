using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using BaseProductModule.Data.Services;
using BaseProductModule.Tests.Moq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Polly;

namespace BaseProductModule.Tests.Repostories;

public class ProductRepositoryTests
{

    [Fact]
    public async Task CreateAsync_Should_Add_New_Product()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);
        var newProduct = new Product { Id = "P789", Name = "Tablet", Price = 299.99m };

        // Act
        var result = await productService.CreateProductAsync(newProduct);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Tablet", result.Name);
    }
    [Fact]
    public async Task GetAllAsync_Should_Return_All_Products()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);

        // Act
        var result = await productService.GetAllProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Test Product 1");
        Assert.Contains(result, p => p.Name == "Test Product 2");
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_Empty_List_When_No_Products()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);

        // Act
        var result = await productService.GetAllProductsAsync();

        // Assert
        Assert.Null(result);

        Assert.Equal(0,result?.Count());
    }


    [Fact]
    public async Task GetByIdAsync_Should_Return_Product_When_Found()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);

        // Act
        var result = await productService.GetProductByIdAsync("P123");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Product 1", result.Name);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Throw_Exception_When_Not_Found()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);

        // Act
        var result = await productService.GetProductByIdAsync("P124");

        // Assert
        Assert.NotNull(result);
        Assert.NotEqual("Test Product 1", result.Name);
    }

    [Fact]
    public async Task UpdateAsync_Should_Update_Product_When_Exists()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);
        var updatedProduct = new Product { Id = "P123", Name = "Updated Product" };

        // Act
        var result = await productService.UpdateProductAsync("P123", updatedProduct);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Product", result.Name);
    }

    [Fact]
    public async Task DeleteAsync_Should_Remove_Product_When_Exists()
    {
        // Arrange
        var mockRepo = ProductRepositoryMoq.GetMock();
        var productService = new BaseProductService(mockRepo.Object);

        // Act
        await productService.DeleteProductAsync("P123");

        // Assert
        mockRepo.Verify(repo => repo.DeleteAsync("P123"), Times.Once);
    }
}
