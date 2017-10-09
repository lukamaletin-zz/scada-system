using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SCADACommon.Model
{
    [DataContract]
    public enum FunctionType
    {
        [EnumMember] Sine,
        [EnumMember] Cosine,
        [EnumMember] Ramp,
        [EnumMember] Triangle,
        [EnumMember] Rectangle,
        [EnumMember] Digital
    }

    [DataContract]
    public class SimulationDriver
    {
        private const double Amplitude = 100;

        [DataMember] private List<AddressValue> _addressValues;

        public SimulationDriver()
        {
            _addressValues = new List<AddressValue>();
        }

        public List<AddressValue> AddressValues
        {
            get { return _addressValues; }
            set { _addressValues = value; }
        }

        public static double Sine()
        {
            return Amplitude * Math.Sin((double) DateTime.Now.Second / 60 * Math.PI);
        }

        public static double Cosine()
        {
            return Amplitude * Math.Cos((double) DateTime.Now.Second / 60 * Math.PI);
        }

        public static double Ramp()
        {
            return Amplitude * DateTime.Now.Second / 60;
        }

        public static double Triangle()
        {
            return ((2 * Amplitude) / Math.PI) * Math.Asin(Math.Sin(2 * Math.PI * DateTime.Now.Second / 60.0));
        }

        public static double Rectangle()
        {
            return Amplitude * Math.Sign(Math.Sin((DateTime.Now.Second % 10) / 5.0));
        }

        public static double Digital()
        {
            var random = new Random();
            return random.Next(0, 2) == 0 ? 0 : 1;
        }
    }
}