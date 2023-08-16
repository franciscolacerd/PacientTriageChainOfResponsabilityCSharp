using PacientTriage.Contracts;
using PacientTriage.Entities;

namespace PacientTriage.Handlers
{
    public class HearthBurnHandler : ISymptomHandler
    {
        private readonly ISymptomHandler _nextSymptom;

        public HearthBurnHandler(ISymptomHandler nextSymptom)
        {
            _nextSymptom = nextSymptom;
        }

        public void HandleSymptom(Pacient pacient)
        {
            if (pacient.Symptoms.Count == 1 &&
                pacient.Symptoms.Contains(Symptoms.ChestPain))
            {
                pacient.DefineBracelet(Bracelet.Yellow);
            }
            else
            {
                this._nextSymptom.HandleSymptom(pacient);
            }
        }
    }
}