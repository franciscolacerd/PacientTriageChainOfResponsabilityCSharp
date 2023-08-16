using FluentAssertions;
using PacientTriage.Chains;
using PacientTriage.Entities;

namespace UnitTests
{
    public class PacientTriageUnitTests
    {
        private Pacient _pacient;

        private BloodPressure _bloodPressure;

        private double _temperature;

        [SetUp]
        public void Setup()
        {
            this._pacient = new Pacient("francisco lacerda", 45);

            this._pacient.DoCheckin("123456789");

            this._bloodPressure = new BloodPressure(120, 80);

            this._temperature = 37.1;
        }

        [Test]
        public void Should_HandleHeartBurn_DefineBraceletYellow()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain
            };

            this._pacient.AddSymptoms(symptoms, this._bloodPressure, this._temperature);

            var nurse = new Nurse(new EvaluationChainHandler());

            // Act
            nurse.EvaluateSymptoms(this._pacient);

            //Assert
            this._pacient.Bracelet.Should().Be(Bracelet.Yellow);
        }

        [Test]
        public void Should_HandleHeartAttack_DefineBraceletRed()
        {
            // Arrange
            var symptoms = new List<string>
            {
                Symptoms.ChestPain,
                Symptoms.NumbnessInArm
            };

            this._pacient.AddSymptoms(symptoms, this._bloodPressure, this._temperature);

            var nurse = new Nurse(new EvaluationChainHandler());

            // Act
            nurse.EvaluateSymptoms(this._pacient);

            //Assert
            this._pacient.Bracelet.Should().Be(Bracelet.Red);
        }
    }
}