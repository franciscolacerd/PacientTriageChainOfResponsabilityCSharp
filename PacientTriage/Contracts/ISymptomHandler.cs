using PacientTriage.Entities;

namespace PacientTriage.Contracts
{
    public interface ISymptomHandler
    {
        void HandleSymptom(Pacient pacient);
    }
}