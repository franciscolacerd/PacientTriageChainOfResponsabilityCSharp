using PacientTriage.Chains;

namespace PacientTriage.Entities
{
    public class Nurse
    {
        private readonly SymptomChainHandler _chain;

        public Nurse(SymptomChainHandler chain)
        {
            this._chain = chain;
        }

        public void EvaluateSymptoms(Pacient pacient)
        {
            this._chain.EvaluateSymptoms(pacient);
        }
    }
}
