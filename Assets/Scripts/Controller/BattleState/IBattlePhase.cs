using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    public interface IBattlePhase
    {
        void Execute(BattleController battle);
        bool IsOver();
        IBattlePhase GoToNext();
    }
}