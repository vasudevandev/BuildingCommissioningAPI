namespace BuildingCommissioningAPI.Models
{
    public class AssetComponent
    {
        public int Id { get; set; }
        public string SystemType { get; set; }   // Access, Fire, etc.
        public string ComponentType { get; set; } // Controller, Reader, etc.
        public float X { get; set; }
        public float Y { get; set; }
        public string Metadata { get; set; }     // Optional key-value info (can store JSON)
    }
}
