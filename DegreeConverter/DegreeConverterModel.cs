using System;

namespace DegreeConverter
{
    public class DegreeConverterModel : IDegreeConverterModel
    {
        public double ToFarenheit(double Celcius)
        {
            return (Celcius * 9 / 5);
        }

        public double ToCelcius(double Farenheit)
        {
            return (32 * Farenheit - 32) * 5 / 9;
        }
    }
}
