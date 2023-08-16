using PacientTriage.Contracts;
using PacientTriage.Entities;
using PacientTriage.Handlers;

namespace PacientTriage.Chains
{
    public class EvaluationChainHandler
    {
        private readonly ISymptomHandler _chain;

        public EvaluationChainHandler()
        {
            _chain = new HearthBurnHandler(new HearthAttackHandler(new DefaultHandler()));
        }

        public void EvaluateSymptoms(Pacient pacient)
        {
            _chain.HandleSymptom(pacient);
        }
    }
}
