namespace Diabetic_Diary.Models.Record_Data
{
    public class ConvertedData
    {
        public ConvertedData(InputedData inputedData)
        {
            Date = Convert.ToDateTime(inputedData.Date);
            Time = Convert.ToDateTime(inputedData.Time);
            SugarValue = Convert.ToDouble(inputedData.SugarValue);
            EatenBreadUnits = Convert.ToDouble(inputedData.EatenBreadUnits);
            DeliveredInsulinUnits = Convert.ToDouble(inputedData.DeliveredInsulinUnits);
        }

        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }
        public double SugarValue { get; private set; }
        public double EatenBreadUnits { get; private set; }
        public double DeliveredInsulinUnits { get; private set; }
    }
}
