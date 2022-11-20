using Device.Management.Api.Controllers;
using Device.Management.Common.Model;
using Device.Management.Repository.Interfaces;
using Device.Management.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Diagnostics.CodeAnalysis;


namespace Device.Management.Tests
{
    public class DeviceControllerTests
    {
       
        [Fact]
        public async Task GetAllDevices_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.GetAll()).Returns(Task.FromResult(GetDevicesTest()));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert            
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);            
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task GetAllDevices_WhenCalled_ReturnsHttpNotFound()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            IEnumerable<Devices> devices = new List<Devices>();
            moqService.Setup(x => x.GetAll()).Returns(Task.FromResult(devices));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert            
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No devices founded", notFoundObjectResult.Value);

        }

        [Fact]
        public async Task Should_Returns_DevicesById_Successfully()
        {
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.GetDeviceById(It.IsAny<Guid>())).Returns(Task.FromResult(GetDevice()));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetById(Guid.NewGuid());

            // Assert            
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Returns_DevicesById_ReturnsHttpNotFound()
        {
            var moqService = new Mock<IDevicesService>();            
            moqService.Setup(x => x.GetDeviceById(It.IsAny<Guid>())).Returns(Task.FromResult<Devices>(null));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetById(Guid.NewGuid());

            // Assert            
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No device founded", notFoundObjectResult.Value);
        }

        [Fact]
        public async Task Should_Returns_DevicesByBrand_Successfully()
        {
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.GetDeviceByBrand(It.IsAny<string>())).Returns(Task.FromResult(GetDevicesTest()));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetByBrand(It.IsAny<string>());

            // Assert            
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Returns_DevicesByBrand_ReturnsHttpNotFound()
        {
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.GetDeviceByBrand(It.IsAny<string>())).Returns(Task.FromResult<IEnumerable<Devices>>(null));


            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.GetByBrand(It.IsAny<string>());

            // Assert            
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No devices founded", notFoundObjectResult.Value);
        }

        
        [Fact]
        public async Task Should_Add_Devices_Successfully()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.CreateDevice(It.IsAny<Devices>())).Returns(Task.FromResult("Device creation fail!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Add(It.IsAny<Devices>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(500, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Add_Devices_ReturnHttp500()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.CreateDevice(It.IsAny<Devices>())).Returns(Task.FromResult("Device creation fail!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Add(It.IsAny<Devices>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(500, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Update_Device_Successfully()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.UpdateDevice(It.IsAny<Devices>())).Returns(Task.FromResult("Device update success!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Update(It.IsAny<Devices>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Update_Device_ReturnHttp500()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.CreateDevice(It.IsAny<Devices>())).Returns(Task.FromResult("Device update fail!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Add(It.IsAny<Devices>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(500, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Delete_Device_Successfully()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.DeleteDevice(It.IsAny<Guid>())).Returns(Task.FromResult("Device deleted successfully!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Delete(It.IsAny<Guid>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(200, (result as IStatusCodeActionResult).StatusCode);
        }

        [Fact]
        public async Task Should_Delete_Device_ReturnHttp500()
        {
            // Arrange
            var moqService = new Mock<IDevicesService>();
            moqService.Setup(x => x.DeleteDevice(It.IsAny<Guid>())).Returns(Task.FromResult("Device delete fail!"));

            var controller = new DeviceController(moqService.Object);

            // Act
            var result = await controller.Delete(It.IsAny<Guid>());

            // Assert

            Assert.NotNull(result);
            Assert.IsAssignableFrom<IStatusCodeActionResult>(result);
            Assert.Equal(500, (result as IStatusCodeActionResult).StatusCode);
        }


        private IEnumerable<Devices> GetDevicesTest()
        {
            var devices = new List<Devices>();
            devices.Add(new Devices()
            {
                Id = new Guid("8ab71c86-29a6-4481-b21d-f2387e93e130"),
                Name = "Galaxy S22",
                Brand = "Samsung",
                CreationTime = DateTime.Now
            });
            devices.Add(new Devices()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Iphone 14",
                Brand = "Apple",
                CreationTime = DateTime.Now
            });
            return devices;
        }

        private Devices GetDevice()
        {
            var device = new Devices
            {
                Id = new Guid("8ab71c86-29a6-4481-b21d-f2387e93e130"),
                Name = "Galaxy S22",
                Brand = "Samsung",
                CreationTime = DateTime.Now
            };
            
            return device;
        }

    }
}
