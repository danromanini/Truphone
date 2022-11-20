using Device.Management.Common.Model;
using Device.Management.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Device.Management.Repository
{
    public class DeviceContext : DbContext, IDeviceContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DevicesDB");
        }

        public virtual DbSet<Devices> Devices { get; set; }


        #region savechanges
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if (!this.ChangeTracker.HasChanges()) return Task.FromResult(0);

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion savechanges

    }
}
