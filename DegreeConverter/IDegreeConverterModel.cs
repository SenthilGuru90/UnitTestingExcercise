namespace DegreeConverter
{
    public interface IDegreeConverterModel
    {
        double ToCelcius(double Farenheit);
        double ToFarenheit(double Celcius);
    }
}