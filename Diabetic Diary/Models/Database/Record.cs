namespace Diabetic_Diary.Models.Database
{
    public class Record
    {
        public Record() { }
        public Record(string date, string time, double sugarValue, double eatenBreadUnits, double deliveredInsulinUnits)
        {
            Date = date;
            Time = time;
            SugarValue = sugarValue;
            EatenBreadUnits = eatenBreadUnits;
            DeliveredInsulinUnits = deliveredInsulinUnits;
        }
        public uint Id { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public double SugarValue { get; set; }
        public double EatenBreadUnits { get; set; }
        public double DeliveredInsulinUnits { get; set; }
    }
}
