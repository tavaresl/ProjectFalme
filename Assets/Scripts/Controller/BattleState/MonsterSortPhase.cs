using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class MonsterSortPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            battle.SortAttackers();
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
            return new ActionPickPhase();
        }
    }
}