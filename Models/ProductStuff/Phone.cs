namespace EKGMaster.Models.ProductStuff
{
    public class Phone : Product
    {
        public string ScreenSize { get; set; }
        public string OperatingSystem { get; set; }
        public string Storage {  get; set; }
        public string BatteryHealth { get; set; }

        public Phone(string screensize, string operatingSystem, string storage, string batteryhealth)
        {
            ScreenSize = screensize;
            OperatingSystem = operatingSystem;
            Storage = storage;
            BatteryHealth = batteryhealth;
        }
    }
}
