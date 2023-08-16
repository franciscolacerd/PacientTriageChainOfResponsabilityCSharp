namespace PacientTriage.Entities
{
    public class Pacient
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string HealthUserNumber { get; private set; }

        public List<string> Symptoms { get; private set; }

        public BloodPressure BloodPressure { get; private set; }

        public double Temperature { get; private set; }
        public bool RequiresHospitalization { get; private set; }

        public Bracelet Bracelet { get; private set; }

        public Pacient(string name, int age)
        {
            Name = name;

            Age = age;
        }

        public void DoCheckin(string healthUserNumber)
        {
            this.HealthUserNumber = healthUserNumber;
        }

        public void AddSymptoms(List<string> symptoms, BloodPressure bloodPressure, double temperature)
        {
            this.Symptoms = symptoms;
            this.BloodPressure = bloodPressure;
            this.Temperature = temperature;
        }

        public void MustRequiresHospitalization(bool requiresHospitalization)
        {
            this.RequiresHospitalization = requiresHospitalization;
        }

        public void DefineBracelet(Bracelet bracelet)
        {
            this.Bracelet = bracelet;
        }
    }
}