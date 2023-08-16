using PacientTriage.Contracts;
using PacientTriage.Entities;

namespace PacientTriage.Handlers
{
    public class HearthAttackHandler : ISymptomHandler
    {
        private readonly ISymptomHandler _nextSymptiom;

        public HearthAttackHandler(ISymptomHandler nextSymptom)
        {
            this._nextSymptiom = nextSymptom;
        }

        public void HandleSymptom(Pacient pacient)
        {
            if (pacient.Symptoms.Contains(Symptoms.ChestPain) &&
                pacient.Symptoms.Contains(Symptoms.NumbArm))
            {
                pacient.DefineBracelet(Bracelet.Red);
            }
            else
            {
                this._nextSymptiom.HandleSymptom(pacient);
            }
        }
    }
}