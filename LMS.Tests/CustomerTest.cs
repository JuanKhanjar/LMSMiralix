using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.CustomerUCs;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace LMS.Tests
{
    public class CustomerTest
    {
        [Fact]
        public async Task ExecuteAsync_ValidCustomerId_ReturnsCustomer()
        {
            // Arrange
            int validCustomerId = 1;

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetCustomerWithGroupsAndProductsAsync(validCustomerId))
                .ReturnsAsync(new Customer
                {
                    // Initialize with customer data for testing
                    CustomerId = validCustomerId,
                    CustomerName = "TestCustomer"
                    // Add other properties and related data as needed
                });

            var mockLogger = new Mock<ILogger<GetCustomerWithGroupsAndProductsUC>>();

            var getCustomerWithGroupsAndProductsUC = new GetCustomerWithGroupsAndProductsUC(
                mockCustomerRepository.Object,
                mockLogger.Object);

            // Act
            var result = await getCustomerWithGroupsAndProductsUC.ExecuteAsync(validCustomerId);

            // Assert
            Assert.NotNull(result); // Customer should not be null
            Assert.Equal(validCustomerId, result.CustomerId);
            // Add more assertions based on the expected customer data
        }

        [Fact]
        public async Task ExecuteAsync_InvalidCustomerId_ThrowsException()
        {
            // Arrange
            int invalidCustomerId = -1; // Invalid customer ID

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockLogger = new Mock<ILogger<GetCustomerWithGroupsAndProductsUC>>();

            var getCustomerWithGroupsAndProductsUC = new GetCustomerWithGroupsAndProductsUC(
                mockCustomerRepository.Object,
                mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidCustomerIdException>(
                async () => await getCustomerWithGroupsAndProductsUC.ExecuteAsync(invalidCustomerId)
            );
        }

        [Fact]
        public async Task ExecuteAsync_CustomerNotFound_ThrowsException()
        {
            // Arrange
            int nonExistentCustomerId = 999; // Non-existent customer ID

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetCustomerWithGroupsAndProductsAsync(nonExistentCustomerId))
                .ReturnsAsync((Customer)null); // Simulate a customer not found

            var mockLogger = new Mock<ILogger<GetCustomerWithGroupsAndProductsUC>>();

            var getCustomerWithGroupsAndProductsUC = new GetCustomerWithGroupsAndProductsUC(
                mockCustomerRepository.Object,
                mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<CustomerNotFoundException>(
                async () => await getCustomerWithGroupsAndProductsUC.ExecuteAsync(nonExistentCustomerId)
            );
        }

        [Fact]
        public async Task ExecuteAsync_ValidCustomerId_ReturnsCustomerWithGroups()
        {
            // Arrange
            int validCustomerId = 1;

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetCustomerWithGroupsAndProductsAsync(validCustomerId))
                .ReturnsAsync(new Customer
                {
                    // Initialize with customer data for testing
                    CustomerId = validCustomerId,
                    CustomerName = "TestCustomer",
                    // Add other properties and related data as needed
                    Groups = new List<Group>
                    {
                        new Group
                        {
                            GroupId = 1,
                            GroupName = "Group1",
                            // Add other properties and related data as needed
                        },
                        new Group
                        {
                            GroupId = 2,
                            GroupName = "Group2",
                            // Add other properties and related data as needed
                        }
                    }
                });

            var mockLogger = new Mock<ILogger<GetCustomerWithGroupsAndProductsUC>>();

            var getCustomerWithGroupsAndProductsUC = new GetCustomerWithGroupsAndProductsUC(
                mockCustomerRepository.Object,
                mockLogger.Object);

            // Act
            var result = await getCustomerWithGroupsAndProductsUC.ExecuteAsync(validCustomerId);

            // Assert
            Assert.NotNull(result); // Customer should not be null
            Assert.Equal(validCustomerId, result.CustomerId);
            // Add more assertions based on the expected customer data and related groups
        }

        [Fact]
        public async Task ExecuteAsync_ValidCustomerId_ReturnsCustomerWithGroupsAndProducts()
        {
            // Arrange
            int validCustomerId = 1;

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetCustomerWithGroupsAndProductsAsync(validCustomerId))
                .ReturnsAsync(new Customer
                {
                    // Initialize with customer data for testing
                    CustomerId = validCustomerId,
                    CustomerName = "TestCustomer",
                    // Add other properties and related data as needed
                    Groups = new List<Group>
                    {
                        new Group
                        {
                            GroupId = 1,
                            GroupName = "Group1",
                            // Add other properties and related data as needed
                            GroupProducts = new List<GroupProduct>
                            {
                                new GroupProduct
                                {
                                    GroupProductId = 1,
                                    AddedQuantity = 5,
                                    // Add other properties and related data as needed
                                    PurchasedProduct = new PurchasedProduct
                                    {
                                        ProductId = 1,
                                        ProductName = "Product1",
                                        // Add other properties as needed
                                    }
                                }
                            }
                        },
                        new Group
                        {
                            GroupId = 2,
                            GroupName = "Group2",
                            // Add other properties and related data as needed
                        }
                    }
                });

            var mockLogger = new Mock<ILogger<GetCustomerWithGroupsAndProductsUC>>();

            var getCustomerWithGroupsAndProductsUC = new GetCustomerWithGroupsAndProductsUC(
                mockCustomerRepository.Object,
                mockLogger.Object);

            // Act
            var result = await getCustomerWithGroupsAndProductsUC.ExecuteAsync(validCustomerId);

            // Assert
            Assert.NotNull(result); // Customer should not be null
            Assert.Equal(validCustomerId, result.CustomerId);
            Assert.NotNull(result.Groups); // Groups should not be null
            Assert.Equal(2, result.Groups.Count); // There should be 2 groups
                                                  // Add more assertions based on the expected customer data, related groups, and group products
        }

    }

}