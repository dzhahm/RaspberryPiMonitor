using System;
using System.Collections.Generic;
using RaspberryPiMonitor.PinController.Models.Enums;
using RaspberryPiMonitor.PinController.Models.Pin;

namespace RaspberryPiMonitor.PinController.Models.PinArray
{
    public class GPIOPinArrayModel : AbstractPinArray
    {
        private List<GPIOPinModel> _gpioPinList;

        public GPIOPinArrayModel()
        {
            _gpioPinList = new List<GPIOPinModel>();
            GenerateGPIOPinMap();
        }

        private void GenerateGPIOPinMap()
        {
            try
            {
                //Configuration file provides the definition of all (40) pins of the Raspberry Pi device.
                //Each row represents a pin
                string[] PinMapArray = GetPinMapFromFile().Split('\n');
                foreach (string pin in PinMapArray)
                {
                    //Each column in a row gives information about the pin. GPIO pins have 4 columns and non-GPIO pins have 3 columns
                    //Third column reveals that if the pin is a GPIO or non-GPIO pin. 
                    string[] pinInfo = pin.Split(' ');
                    EPinType pinType = GetPinType(pinInfo[2]);
                    if(pinType == EPinType.GPIO)
                    {
                        int pinNumber = int.Parse(pinInfo[1]);
                        string pinName = $"PIN {pinNumber}";
                        int gpioNumber = int.Parse(pinInfo[3]);
                        PinModel pinModel = new PinModel(pinNumber, "PIN " + pinNumber, pinType, DefaultPinIOType(pinType));
                        _gpioPinList.Add(new GPIOPinModel(pinModel, gpioNumber));
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
