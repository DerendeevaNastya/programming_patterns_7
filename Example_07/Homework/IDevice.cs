namespace Example_07.Homework
{
    public interface IDevice
    {
        string GetDeviceName();
    }
    
    public class UsbFlashDrive : IDevice
    {
        public string GetDeviceName() => "USB Flash Drive";
    }

    public class WiFi : IDevice
    {
        public string GetDeviceName() => "Wi-Fi";
    }
}