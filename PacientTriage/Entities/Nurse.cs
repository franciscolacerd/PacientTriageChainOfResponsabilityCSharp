using PacientTriage.Chains;

namespace PacientTriage.Entities
{
    public class Nurse
    {
        private readonly EvaluationChainHandler _chain;

        public Nurse(EvaluationChainHandler chain)
        {
            this._chain = chain;
        }

        public void EvaluateSymptoms(Pacient pacient)
        {
            this._chain.EvaluateSymptoms(pacient);
        }
    }
}