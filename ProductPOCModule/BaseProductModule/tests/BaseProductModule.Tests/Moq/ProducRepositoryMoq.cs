using BaseProductModule.Core.Model;
using BaseProductModule.Data.Model;
using BaseProductModule.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProductModule.Tests.Moq;

public static class ProductRepositoryMoq
{
    public static Mock<IProductRepository<Product>> GetMock()
    {
        var mock = new Mock<IProductRepository<Product>>();

        // Mock data
        var products = new List<Product>
        {
            new Product { Id = "P123", Name = "Test Product 1" },
            new Product { Id = "P456", Name = "Test Product 2" }
        };

        // Mock GetByIdAsync
        mock.Setup(repo => repo.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync((string id) => products.Find(p => p.Id == id));

        // Mock GetAllAsync
        mock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(products);

        // Mock CreateAsync
        mock.Setup(repo => repo.CreateAsync(It.IsAny<Product>()))
            .ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

        // Mock UpdateAsync
        mock.Setup(repo => repo.UpdateAsync(It.IsAny<string>(), It.IsAny<Product>()))
            .ReturnsAsync((string id, Product product) =>
            {
                var existingProduct = products.Find(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                }
                return existingProduct;
            });

        // Mock DeleteAsync
        mock.Setup(repo => repo.DeleteAsync(It.IsAny<string>()))
            .Callback((string id) =>
            {
                var product = products.Find(p => p.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                }
            });

        return mock;
    }
}
