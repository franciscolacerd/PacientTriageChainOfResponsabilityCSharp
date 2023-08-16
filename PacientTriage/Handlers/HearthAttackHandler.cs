using PacientTriage.Contracts;
using PacientTriage.Entities;

namespace PacientTriage.Handlers
{
    public class HearthAttackHandler : ISymptomHandler
    {
        private readonly ISymptomHandler _nextHandler;

        public HearthAttackHandler(ISymptomHandler nextHandler)
        {
            this._nextHandler = nextHandler;
        }

        public void HandleSymptom(Pacient pacient)
        {
            if (pacient.Symptoms.Contains(Symptoms.ChestPain) &&
                pacient.Symptoms.Contains(Symptoms.NumbnessInArm))
            {
                pacient.DefineBracelet(Bracelet.Red);
            }
            else
            {
                this._nextHandler.HandleSymptom(pacient);
            }
        }
    }
}