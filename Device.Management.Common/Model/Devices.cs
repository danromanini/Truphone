namespace Device.Management.Common.Model
{
    public record Devices
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
