using Device.Management.Api.Controllers;
using Device.Management.Common.Model;
using Device.Management.Repository.Interfaces;
using Device.Management.Service;
using Device.Management.Service.Interfaces;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Xunit;

namespace Device.Management.Tests
{
    public class DeviceServiceTest
    {
        [Fact]
        public async Task Should_GetAllDevices_ReturnDevicesList()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.GetAll()).Returns(GetDevicesTest());


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetAll();

            // Assert                        
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetAllDevices_ReturnNull()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            IEnumerable<Devices> devicesList = new List<Devices>();
            moqRepository.Setup(x => x.GetAll()).Returns(devicesList);


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetAll();

            // Assert                        
            Assert.False(result.Any());
        }


        [Fact]
        public async Task Should_GetDevicesById_ReturnDevicesList()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(GetDevice());


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetDeviceById(It.IsAny<Guid>());

            // Assert                        
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetDevicesById_ReturnNull()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            
            moqRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns((Devices)null);


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetDeviceById(It.IsAny<Guid>());

            // Assert                        
            Assert.Null(result);
        }


        [Fact]
        public async Task Should_GetDevicesByBrand_ReturnDevicesList()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.GetByBrand(It.IsAny<string>())).Returns(GetDevicesTest());


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetDeviceByBrand(It.IsAny<string>());

            // Assert                        
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetDevicesByBrand_ReturnNull()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            IEnumerable<Devices> devicesList = new List<Devices>();
            moqRepository.Setup(x => x.GetByBrand(It.IsAny<string>())).Returns(devicesList);


            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.GetDeviceByBrand(It.IsAny<string>());

            // Assert                        
            Assert.False(result.Any());
        }


        [Fact]
        public async Task Should_Add_Devices_Successfully()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Create(It.IsAny<Devices>())).Returns(true);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.CreateDevice(It.IsAny<Devices>());

            // Assert                        
            Assert.Contains("Device creation success!", result);
        }

        [Fact]
        public async Task Should_Add_Devices_Fail()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Create(It.IsAny<Devices>())).Returns(false);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.CreateDevice(It.IsAny<Devices>());

            // Assert                        
            Assert.Contains("Device creation fail!", result);
        }

        [Fact]
        public async Task Should_Update_Devices_Successfully()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Update(It.IsAny<Devices>())).Returns(true);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.UpdateDevice(It.IsAny<Devices>());

            // Assert                        
            Assert.Contains("Device update success!", result);
        }

        [Fact]
        public async Task Should_Update_Devices_Fail()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Update(It.IsAny<Devices>())).Returns(false);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.UpdateDevice(It.IsAny<Devices>());

            // Assert                        
            Assert.Contains("Device update fail!", result);
        }

        [Fact]
        public async Task Should_Delete_Devices_Successfully()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(true);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.DeleteDevice(It.IsAny<Guid>());

            // Assert                        
            Assert.Contains("Device deleted successfully!", result);
        }

        [Fact]
        public async Task Should_Delete_Devices_Fail()
        {
            // Arrange
            var moqRepository = new Mock<IDeviceRepository>();
            moqRepository.Setup(x => x.Delete(It.IsAny<Guid>())).Returns(false);

            // Act
            var service = new DeviceService(moqRepository.Object);

            // Act
            var result = await service.DeleteDevice(It.IsAny<Guid>());

            // Assert                        
            Assert.Contains("Device delete fail!", result);
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
