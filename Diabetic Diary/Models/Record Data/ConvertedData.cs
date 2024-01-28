namespace Diabetic_Diary.Models.Record_Data
{
    public class ConvertedData
    {
        public ConvertedData(InputedData inputedData)
        {
            Date = Convert.ToDateTime(inputedData.Date).ToShortDateString();
            Time = Convert.ToDateTime(inputedData.Time).ToShortTimeString();
            SugarValue = Convert.ToDouble(inputedData.SugarValue);
            EatenBreadUnits = Convert.ToDouble(inputedData.EatenBreadUnits);
            DeliveredInsulinUnits = Convert.ToDouble(inputedData.DeliveredInsulinUnits);
        }

        public string Date { get; private set; }
        public string Time { get; private set; }
        public double SugarValue { get; private set; }
        public double EatenBreadUnits { get; private set; }
        public double DeliveredInsulinUnits { get; private set; }
    }
}
