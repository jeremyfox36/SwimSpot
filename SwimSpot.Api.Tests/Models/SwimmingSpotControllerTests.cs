using Microsoft.AspNetCore.Mvc;
using Moq;
using SwimSpot.Api.Controllers;
using SwimSpot.Api.Models;
using SwimSpot.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            _mockRepo.Setup(repo => repo.GetAllSwimmingSpots())
                .Returns(new List<SwimmingSpot>() { new SwimmingSpot(), new SwimmingSpot() });

            var result = _swimmingSpotController.GetAllSwimmingSpots();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            var swimmingSpots = Assert.IsType<List<SwimmingSpot>>(okObjectResult.Value);
            Assert.Equal(2, swimmingSpots.Count);
        }


    }
}
