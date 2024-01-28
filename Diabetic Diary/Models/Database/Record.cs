using Diabetic_Diary.Models.Record_Data;

namespace Diabetic_Diary.Models.Database
{
    public class Record
    {
        public uint Id { get; private set; }
        public string Date { get; private set; }
        public string Time { get; private set; }
        public double SugarValue { get; private set; }
        public double EatenBreadUnits { get; private set; }
        public double DeliveredInsulinUnits { get; private set; }

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