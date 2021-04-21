using System;
using System.Collections.Generic;
using RaspberryPiMonitor.PinController.Models.Enums;
using RaspberryPiMonitor.PinController.Models.Pin;

namespace RaspberryPiMonitor.PinController.Models.PinArray
{
    public class PinArrayModel : AbstractPinArray
    {
        private List<PinModel> _pinList;

        public PinArrayModel()
        {
            _pinList = new List<PinModel>();
        }

        private void CreatePinMap()
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

                    int pinNumber = int.Parse(pinInfo[1]);
                    string pinName = $"PIN {pinNumber}";
                    PinModel pinModel = new(pinNumber, "PIN " + pinNumber, pinType, DefaultPinIOType(pinType));
                    _pinList.Add(pinModel);
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
