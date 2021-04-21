using System.Device.Gpio;
using RaspberryPiMonitor.PinController.Models.Enums;

namespace RaspberryPiMonitor.PinController.Models.Pin
{
    /// <summary>
    /// GPIOPinModel class inherits the PinModel class and extends it with additional GPIO specific properties
    /// </summary>
    public class GPIOPinModel : PinModel
    {

        private EPinOutputState _pinState;
        private int _GPIOPinNumber;
        private PinMode _GPIOPinMode;

        /// <summary>
        /// Create a GPIO pin representation from a regular pin model
        /// </summary>
        /// <param name="pinModel">Regular pin definition of the GPIO pin</param>
        /// <param name="gpioPinNumber">GPIO number of the GPIO pin. It is different than the pin number!</param>
        /// <param name="pinMode">GPIO purpose (input||output) and binary representation style. For instance, it defines if the binary "1" is represented with high voltage(3.3V) at the pin</param>
        /// <param name="pinState">Binary state of the GPIO pin.</param>
        public GPIOPinModel(PinModel pinModel, int gpioPinNumber, PinMode pinMode, EPinOutputState pinState) : base(pinModel.PinNumber, pinModel.PinName, pinModel.PinType, pinModel.IOType)
        {
            _pinState = pinState;
            _GPIOPinNumber = gpioPinNumber;
            _GPIOPinMode = pinMode;
        }

        public GPIOPinModel(PinModel pinModel, int gpioPinNumber) : base(pinModel.PinNumber, pinModel.PinName, pinModel.PinType, pinModel.IOType)
        {
            _pinState = EPinOutputState.UNKNOWN;
            _GPIOPinNumber = gpioPinNumber;
            _GPIOPinMode = PinMode.Input;
        }
    }
}
