using System;

namespace Projeto_4.Entities
{
    internal class HourContract
    {
        public DateTime Data { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set;}

        public HourContract() //construtor padrão
        {

        }

        public HourContract(DateTime data, double valuePerHour, int hours)  //construtor
        {
            Data = data;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}
