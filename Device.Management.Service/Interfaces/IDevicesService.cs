using Device.Management.Common.Model;

namespace Device.Management.Service.Interfaces
{
    public interface IDevicesService
    {
        Task<IEnumerable<Devices>> GetAll();

        Task<Devices> GetDeviceById(Guid deviceId);

        Task<IEnumerable<Devices>> GetDeviceByBrand(string brandName);

        Task<string> CreateDevice(Devices devices);

        Task<string> UpdateDevice(Devices devices);

        Task<string> DeleteDevice(Guid deviceId);

    }
}
