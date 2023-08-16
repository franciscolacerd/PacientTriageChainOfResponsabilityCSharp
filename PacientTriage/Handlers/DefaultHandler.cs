using PacientTriage.Contracts;
using PacientTriage.Entities;

namespace PacientTriage.Handlers
{
    public class DefaultHandler : ISymptomHandler
    {
        public void HandleSymptom(Pacient pacient)
        {
            pacient.DefineBracelet(Bracelet.Green);
        }
    }
}