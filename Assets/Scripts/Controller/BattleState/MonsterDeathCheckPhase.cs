using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class MonsterDeathCheckPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            throw new System.NotImplementedException();
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            throw new System.NotImplementedException();
        }

        public IBattlePhase GoToNext()
        {
            return new BattleOverCheckPhase();
        }
    }
}