using System;
using System.Collections.ObjectModel;

namespace PluginTester.DataModel.Meters
{
    [Serializable]
    public class MeterCalibration
    {
        private string _serialNumber;
        private string _manufacturer;
        private string _model;
        private MeterType _meterType;
        private string _configuration;
        private string _firmwareVersion;
        private string _softwareVersion;
        private readonly Collection<MeterCalibrationEquation> _equations = new Collection<MeterCalibrationEquation>();

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public MeterType MeterType
        {
            get { return _meterType; }
            set { _meterType = value; }
        }

        public string Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }

        public string FirmwareVersion
        {
            get { return _firmwareVersion; }
            set { _firmwareVersion = value; }
        }

        public string SoftwareVersion
        {
            get { return _softwareVersion; }
            set { _softwareVersion = value; }
        }

        public Collection<MeterCalibrationEquation> Equations => _equations;
    }
}
