using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.BusinessUseCases.PurchasedProductsUCs;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Tests
{
    public class PurchasedProductTest
    {
        [Fact]
        public async Task ExecuteAsync_ValidCustomerId_ReturnsPurchasedProducts()
        {
            // Arrange
            int validCustomerId = 1;

            var mockPurchasedProductRepository = new Mock<IPurchasedProductRepository>();
            mockPurchasedProductRepository
                .Setup(repo => repo.GetPurchasedProductsByCustomerIdAsync(validCustomerId))
                .ReturnsAsync(new List<PurchasedProduct>
                {
                    new PurchasedProduct
                    {
                        ProductId = 1,
                        ProductName = "Product1",
                        PurchasedQty = 5,
                        // Add other properties and related data as needed
                    },
                    new PurchasedProduct
                    {
                        ProductId = 2,
                        ProductName = "Product2",
                        PurchasedQty = 3,
                        // Add other properties and related data as needed
                    }
                });

            var mockLogger = new Mock<ILogger<GetPurchasedProductsByCustomerIdUC>>();

            var getPurchasedProductsByCustomerIdUC = new GetPurchasedProductsByCustomerIdUC(
                mockPurchasedProductRepository.Object,
                mockLogger.Object);

            // Act
            var result = await getPurchasedProductsByCustomerIdUC.ExecuteAsync(validCustomerId);

            // Assert
            Assert.NotNull(result); // PurchasedProducts should not be null
            Assert.Equal(2, result.Count()); // There should be 2 purchased products
            // Add more assertions based on the expected purchased product data
        }

        [Fact]
        public async Task ExecuteAsync_InvalidCustomerId_ThrowsException()
        {
            // Arrange
            int invalidCustomerId = -1; // Invalid customer ID

            var mockPurchasedProductRepository = new Mock<IPurchasedProductRepository>();
            var mockLogger = new Mock<ILogger<GetPurchasedProductsByCustomerIdUC>>();

            var getPurchasedProductsByCustomerIdUC = new GetPurchasedProductsByCustomerIdUC(
                mockPurchasedProductRepository.Object,
                mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidCustomerIdException>(
                async () => await getPurchasedProductsByCustomerIdUC.ExecuteAsync(invalidCustomerId)
            );
        }

        [Fact]
        public async Task ExecuteAsync_NoPurchasedProducts_ReturnsEmptyCollection()
        {
            // Arrange
            int validCustomerId = 1;

            var mockPurchasedProductRepository = new Mock<IPurchasedProductRepository>();
            mockPurchasedProductRepository
                .Setup(repo => repo.GetPurchasedProductsByCustomerIdAsync(validCustomerId))
                .ReturnsAsync(new List<PurchasedProduct>());

            var mockLogger = new Mock<ILogger<GetPurchasedProductsByCustomerIdUC>>();

            var getPurchasedProductsByCustomerIdUC = new GetPurchasedProductsByCustomerIdUC(
                mockPurchasedProductRepository.Object,
                mockLogger.Object);

            // Act
            var result = await getPurchasedProductsByCustomerIdUC.ExecuteAsync(validCustomerId);

            // Assert
            Assert.NotNull(result); // PurchasedProducts should not be null
            Assert.Empty(result); // The collection should be empty
        }
    }
}
