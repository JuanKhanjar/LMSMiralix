using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.GroupUCs;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.SqlServer.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LMS.Tests
{
    public class GroupProductTest
    {
        [Fact]
        public async Task CreateGroupAsync_ValidData_ReturnsCreatedGroup()
        {
            // Arrange
            int validCustomerId = 1;
            string groupName = "TestGroup";

            var mockGroupRepository = new Mock<IGroupRepository>();
            mockGroupRepository
                .Setup(repo => repo.CreateGroupAsync(validCustomerId, groupName))
                .ReturnsAsync(new Group
                {
                    // Initialize with group data for testing
                    GroupId = 1,
                    GroupName = groupName,
                    // Add other properties as needed
                });

            var mockLogger = new Mock<ILogger<CreateGroupUC>>();

            var createGroupUC = new CreateGroupUC(
                mockGroupRepository.Object,
                mockLogger.Object);

            // Act
            var result = await createGroupUC.ExcecuteAsync(validCustomerId, groupName);

            // Assert
            Assert.NotNull(result); // Created group should not be null
            Assert.Equal(groupName, result.GroupName);
            // Add more assertions based on the expected group data
        }

        [Fact]
        public async Task CreateGroupAsync_InvalidCustomerId_ThrowsException()
        {
            // Arrange
            int invalidCustomerId = -1; // Invalid customer ID
            string groupName = "TestGroup";

            var mockGroupRepository = new Mock<IGroupRepository>();
            var mockLogger = new Mock<ILogger<CreateGroupUC>>();

            var createGroupUC = new CreateGroupUC(
                mockGroupRepository.Object,
                mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidCustomerIdException>(
                async () => await createGroupUC.ExcecuteAsync(invalidCustomerId, groupName)
            );
        }

        [Fact]
        public async Task UpdateGroupNameAsync_ValidData_ReturnsTrue()
        {
            // Arrange
            int validGroupId = 1;
            string newGroupName = "UpdatedGroup";

            var mockGroupRepository = new Mock<IGroupRepository>();
            mockGroupRepository
                .Setup(repo => repo.UpdateGroupNameAsync(validGroupId, newGroupName))
                .ReturnsAsync(true);

            var mockLogger = new Mock<ILogger<UpdateGroupNameUC>>();

            var updateGroupNameUC = new UpdateGroupNameUC(
                mockGroupRepository.Object,
                mockLogger.Object);

            // Act
            var result = await updateGroupNameUC.ExcecuteAsync(validGroupId, newGroupName);

            // Assert
            Assert.True(result); // Update should be successful
        }

        [Fact]
        public async Task UpdateGroupNameAsync_InvalidData_ReturnsFalse()
        {
            // Arrange
            int invalidGroupId = -1; // Invalid group ID
            string newGroupName = "UpdatedGroup";

            var mockGroupRepository = new Mock<IGroupRepository>();
            mockGroupRepository
                .Setup(repo => repo.UpdateGroupNameAsync(invalidGroupId, newGroupName))
                .ReturnsAsync(false);

            var mockLogger = new Mock<ILogger<UpdateGroupNameUC>>();

            var updateGroupNameUC = new UpdateGroupNameUC(
                mockGroupRepository.Object,
                mockLogger.Object);

            // Act
            var result = await updateGroupNameUC.ExcecuteAsync(invalidGroupId, newGroupName);

            // Assert
            Assert.False(result); // Update should not be successful
        }

    }
}
