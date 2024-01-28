namespace Diabetic_Diary.Models.Record_Data
{
    public class InputedData
    {
        public InputedData(string date, string time, string sugarValue, string eatenBreadUnits, string deliveredInsulinUnits)
        {
            Date = date;
            Time = time;
            SugarValue = sugarValue;
            EatenBreadUnits = eatenBreadUnits;
            DeliveredInsulinUnits = deliveredInsulinUnits;

            IsCorrect = CheckCorrectness();
        }

        public string Date { get; private set; }
        public string Time { get; private set; }
        public string SugarValue { get; private set; }
        public string EatenBreadUnits { get; private set; }
        public string DeliveredInsulinUnits { get; private set; }

        public bool IsCorrect { get; init; }

        private bool CheckCorrectness()
        {
            return (

                 double.TryParse(DeliveredInsulinUnits, out _)

                 && double.TryParse(SugarValue, out _)

                 && double.TryParse(EatenBreadUnits, out _)

                 && DateTime.TryParse(Date, out _)

                 && DateTime.TryParse(Time, out _)
            );
        }
    }
}
