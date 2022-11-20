using Device.Management.Common.Model;

namespace Device.Management.Repository.Interfaces
{
    public interface IDeviceRepository
    {
        IEnumerable<Devices> GetAll();

        Devices GetById(Guid deviceId);

        IEnumerable<Devices> GetByBrand(string brandName);        

        bool Create(Devices device);

        bool Update(Devices device);

        bool Delete(Guid deviceId);
    }
}
