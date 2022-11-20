using Device.Management.Common.Model;
using Device.Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Device.Management.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private protected DeviceContext _dbContext;

        public DeviceRepository(DeviceContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public IEnumerable<Devices> GetAll()
        {
            var deviceList = new List<Devices>();

            try
            {
                var devices = _dbContext.Devices.AsNoTracking();

                if (devices != null || devices.Any())
                {
                    deviceList.AddRange(devices);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return deviceList;
        }

        public IEnumerable<Devices> GetByBrand(string brandName)
        {

            var deviceList = new List<Devices>();

            try
            {
                var devices = _dbContext.Devices.Where(x => x.Brand == brandName).AsNoTracking();

                if (devices != null || devices.Any())
                {
                    deviceList.AddRange(devices);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return deviceList;
        }

        public Devices GetById(Guid deviceId)
        {
            return _dbContext.Devices.Where(x => x.Id == deviceId).AsNoTracking().FirstOrDefaultAsync().Result;
        }

        public bool Create(Devices device)
        {
            try
            {
                _dbContext.Devices.Add(device);

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Create Device Error", ex);
            }
        }
                
        public bool Update(Devices device)
        {
            try
            {
                _dbContext.Devices.Update(device);

                _dbContext.SaveChangesAsync();

                if (_dbContext.Entry(device).State != EntityState.Unchanged)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Update Device Error", ex);
            }
        }

        public bool Delete(Guid deviceId)
        {
            try
            {
                var device = _dbContext.Devices.Find(deviceId);

                if (device == null)
                {
                    throw new ArgumentNullException("Device not found");
                }

                _dbContext.Devices.Remove(device);

                _dbContext.SaveChangesAsync();

                if (_dbContext.Entry(device).State != EntityState.Detached && _dbContext.Entry(device).State != EntityState.Deleted)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Device Error", ex);
            }
        }
    }
}
