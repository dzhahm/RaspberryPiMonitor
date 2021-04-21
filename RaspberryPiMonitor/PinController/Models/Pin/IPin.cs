using RaspberryPiMonitor.PinController.Models.Enums;

namespace RaspberryPiMonitor.PinController.Models
{
    public interface IPin
    {
        int PinNumber { get; set; }

        string PinName { get; set; }

        EPinType PinType { get; set; }

        EIOType IOType { get; set; }
    }
}
