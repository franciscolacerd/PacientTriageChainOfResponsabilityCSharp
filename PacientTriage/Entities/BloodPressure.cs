namespace PacientTriage.Entities
{
    public class BloodPressure
    {
        public double Systolic { get; set; }
        public double Diastolic { get; set; }

        public BloodPressure(double systolic, double diastolic)
        {
            this.Systolic = systolic;
            this.Diastolic = diastolic;
        }
    }
}