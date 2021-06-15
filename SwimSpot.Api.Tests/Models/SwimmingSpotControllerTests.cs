using Microsoft.AspNetCore.Mvc;
using Moq;
using SwimSpot.Api.Controllers;
using SwimSpot.Api.Models;
using SwimSpot.Shared;
using System.Collections.Generic;
using Xunit;


namespace SwimSpot.Api.Tests.Models
{
    public class SwimmingSpotControllerTests
    {
        private readonly Mock<ISwimmingSpotRepository> _mockRepo;
        private readonly SwimmingSpotController _swimmingSpotController;

        public SwimmingSpotControllerTests()
        {
            _mockRepo = new Mock<ISwimmingSpotRepository>();
            _swimmingSpotController = new SwimmingSpotController(_mockRepo.Object);
            
        }
     
        [Fact]
        public void GetAllSwimmingSpots_ReturnsOkObjectResult()
        {
            var result = _swimmingSpotController.GetAllSwimmingSpots();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetAllSwimmingSpots_ActionExecutes_ReturnsExactNumberOfSwimmingSpots()
        {
            //arrange
            _mockRepo.Setup(repo => repo.GetAllSwimmingSpots())
                .Returns(new List<SwimmingSpot>() { new SwimmingSpot(), new SwimmingSpot() });
            //act
            var result = _swimmingSpotController.GetAllSwimmingSpots();
            //assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            var swimmingSpots = Assert.IsType<List<SwimmingSpot>>(okObjectResult.Value);

            Assert.Equal(2, swimmingSpots.Count);
        }

        [Fact]
        public void GetSwimmingSpotById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // arrange
            var fakeId = 2;
            
            // act
            var notFoundResult = _swimmingSpotController.GetSwimmingSpotById(fakeId);
            
            // assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetSwimmingSpotById_ExistingIdPassed_ReturnsOkResult()
        {
            
            var testId = 1;
            // arrange
            _mockRepo.Setup(repo => repo.GetSwimmingSpotById(testId))
                .Returns(new SwimmingSpot() { SwimmingSpotId = 1, Latitude = 55.645521772338500M, Longitude = -2.906058530106536M, Comments = new List<SwimmingSpotComment>() });
            // act
            var okResult = _swimmingSpotController.GetSwimmingSpotById(testId);
            // assert
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void GetSwimmingSpotById_ExistingIdPassed_ReturnsRightItem()
        {
            // arrange
            var testId = 1;
            _mockRepo.Setup(repo => repo.GetSwimmingSpotById(testId))
                .Returns(new SwimmingSpot() { SwimmingSpotId = 1, Latitude = 55.645521772338500M, Longitude = -2.906058530106536M, Comments = new List<SwimmingSpotComment>()});
            // act
            var result = _swimmingSpotController.GetSwimmingSpotById(testId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            // assert
            Assert.IsType<SwimmingSpot>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as SwimmingSpot).SwimmingSpotId);
        }
    }
}
