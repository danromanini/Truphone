using Device.Management.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Device.Management.Repository.Interfaces
{
    public interface IDeviceContext
    {
        DbSet<Devices> Devices { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
