using Device.Management.Common.Model;
using Device.Management.Repository.Interfaces;
using Device.Management.Service.Interfaces;

namespace Device.Management.Service
{
    public class DeviceService : IDevicesService
    {
        protected readonly IDeviceRepository _repository;

        public DeviceService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Devices>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<Devices>> GetDeviceByBrand(string brandName)
        {
            return _repository.GetByBrand(brandName);
        }

        public async Task<Devices> GetDeviceById(Guid deviceId)
        {
            return _repository.GetById(deviceId);
        }

        public async Task<string> CreateDevice(Devices devices)
        {
            if (_repository.Create(devices))
            {
                return "Device creation success!";
            }
            else
            {
                return "Device creation fail!";
            }
        }

        public async Task<string> UpdateDevice(Devices devices)
        {
            if (_repository.Update(devices))
            {
                return "Device update success!";
            }
            else
            {
                return "Device update fail!";
            }
        }

        public async Task<string> DeleteDevice(Guid deviceId)
        {
            if (_repository.Delete(deviceId))
            {
                return "Device deleted successfully!";
            }
            else
            {
                return "Device delete fail!";
            }
        }

    }
}
