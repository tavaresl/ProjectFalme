using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class ActionPickPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            throw new System.NotImplementedException();
        }

        public bool IsOver()
        {
            throw new System.NotImplementedException();
        }

        public IBattlePhase GoToNext()
        {
            return new DamageCountPhase();
        }
    }
}