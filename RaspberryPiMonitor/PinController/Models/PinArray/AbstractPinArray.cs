using System;
using RaspberryPiMonitor.PinController.Models.Enums;

namespace RaspberryPiMonitor.PinController.Models.PinArray
{
    public abstract class AbstractPinArray
    {
        public AbstractPinArray()
        {

        }

        //Protected method is only accessible by the inheriting class. Classes which use the inheriting class cannot reach this method. 
        //Read configuration file as a project resource. Configuration file provides the pin map of Raspberry Pi device. 
        protected string GetPinMapFromFile()
        {
            string PinMap = string.Empty;
            try
            {
                PinMap = System.IO.File.ReadAllText("PinMap");
            }
            catch (Exception e)
            {
                throw;
            }
            return PinMap;
        }

        //Protected method is only accessible by the inheriting class. Classes which use the inheriting class cannot reach this method. 
        //Parse pin type definition acquired from the configuration file into internal enum format.
        protected EPinType GetPinType(string pinType)
        {
            return pinType switch
            {
                "Power5V" => EPinType.Power5V,
                "Power3V3" => EPinType.Power3V3,
                "GND" => EPinType.GND,
                "GPIO" => EPinType.GPIO,
                "ID_SD" => EPinType.ID_SD,
                "ID_SC" => EPinType.ID_SC,
                _ => EPinType.None,
            };
        }

        protected EIOType DefaultPinIOType(EPinType pinType)
        {
            return pinType switch
            {
                EPinType.Power5V => EIOType.I,
                EPinType.Power3V3 => EIOType.O,
                EPinType.GND => EIOType.I,
                EPinType.GPIO => EIOType.I,
                EPinType.ID_SD => EIOType.X,
                EPinType.ID_SC => EIOType.X,
                _ => EIOType.X
            };
        }

    }
}
