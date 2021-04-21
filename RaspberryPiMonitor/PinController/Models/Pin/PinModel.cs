using RaspberryPiMonitor.PinController.Models.Enums;

namespace RaspberryPiMonitor.PinController.Models.Pin
{

    public class PinModel : IPin
    {
        public int PinNumber { get => _pinNumber; set => _pinNumber = value; }
        public string PinName { get => _pinName; set => _pinName = value; }
        public EPinType PinType { get => _pinType; set => _pinType = value; }
        public EIOType IOType { get => _ioType; set => _ioType = value; }

        /// <summary>
        /// 
        /// </summary>
        public PinModel()
        {
            _pinNumber = 0;
            _pinName = "Empty";
            _pinType = EPinType.None;
            _ioType = EIOType.X;
        }

        /// <summary>
        /// Create a representative model object for Raspberry Pi pin
        /// </summary>
        /// <param name="pinNumber">Number of the pin defined by the Raspberry Pi schematic</param>
        /// <param name="pinName">Name of the pin defined by the Raspberry Pi schematic</param>
        /// <param name="pinType">Type of the pin. I.e POWER, GND, GPIO</param>
        /// <param name="io"><Input/Output status of the pin/param>
        /// <param name="GPIOPinMode">If the pin is GPIO, it is the the binary input/output representation. I.e PullDown (Low voltage for binary "1" representation) or PullUp</param>
        public PinModel(int pinNumber, string pinName, EPinType pinType, EIOType io)
        {
            _pinNumber = pinNumber;
            _pinName = pinName;
            _pinType = pinType;
            _ioType = io;
        }

        private int _pinNumber;

        private string _pinName;

        private EPinType _pinType;

        private EIOType _ioType;
    }
}
