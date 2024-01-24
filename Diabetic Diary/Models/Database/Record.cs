using Diabetic_Diary.Models.Record_Data;

namespace Diabetic_Diary.Models.Database
{
    public class Record
    {
        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public double SugarValue { get; set; }
        public double EatenBreadUnits { get; set; }
        public double DeliveredInsulinUnits { get; set; }

        public void SetValues(ConvertedData convertedData)
        {
            Date = convertedData.Date;
            Time = convertedData.Time;
            SugarValue = convertedData.SugarValue;
            EatenBreadUnits = convertedData.EatenBreadUnits;
            DeliveredInsulinUnits = convertedData.DeliveredInsulinUnits;
        }
    }
}