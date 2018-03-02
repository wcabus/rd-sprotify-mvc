using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Controllers;
using Sprotify.WebApi.Models.Bands;
using Xunit;
using Band = Sprotify.Domain.Models.Band;

namespace Sprotify.WebApi.Tests
{
    public class BandsControllerTests
    {
        private BandsController _controller;
        private readonly Guid NotFound = Guid.Empty;
        private readonly Guid Found = Guid.NewGuid();

        public BandsControllerTests()
        {
            AutoMapper.Mapper.Reset();
            Startup.ConfigureAutoMapper();

            var service = Substitute.For<IBandService>();
            service.GetBands(Arg.Any<string>()).Returns(new List<Band>());

            service.GetBandById(NotFound).ReturnsNull();
            service.GetBandById(Found).Returns(new Band("Daft Punk"));

            _controller = new BandsController(service);
        }

        [Fact]
        public async Task GetBandsWithoutFilterShouldReturn200OK()
        {
            // When or Act
            var result = await _controller.GetBands();

            // Then or Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetBandById_ShouldReturnNotFound_WhenBandDoesntExist()
        {
            // When or Act
            var result = await _controller.GetBandById(NotFound);

            // Then or Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetBandById_ShouldReturnOK_WhenBandExists()
        {
            // When or Act
            var result = await _controller.GetBandById(Found);

            // Then or Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(((OkObjectResult)result).Value);
        }

        [Fact]
        public async Task CreateBand_ShouldReturnBadRequest_WhenNameMissing()
        {
            // Given or Arrange
            var model = new BandToCreate
            {
                Name = null
            };
            _controller.ModelState.AddModelError(nameof(model.Name), "Name is required");

            // When or Act
            var result = await _controller.CreateBand(model);

            // Then or Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
