using PacientTriage.Contracts;
using PacientTriage.Entities;

namespace PacientTriage.Handlers
{
    public class HearthBurnHandler : ISymptomHandler
    {
        private readonly ISymptomHandler _nextHandler;

        public HearthBurnHandler(ISymptomHandler nextHandler)
        {
            _nextHandler = nextHandler;
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
                this._nextHandler.HandleSymptom(pacient);
            }
        }
    }
}