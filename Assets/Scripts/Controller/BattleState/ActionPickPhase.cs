using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class ActionPickPhase  : IBattlePhase 
    {
        private bool _isOver = false;

        public void Execute(BattleController battle)
        {
            PlayerController player = battle.PlayerCharacter;
            EnemyController enemy = battle.EnemyCharacter;

            foreach (var monster in battle.AttackOrder)
            {
                bool isEnemyMonster = enemy.Enemy.MonstersInCombat.Contains(monster.Monster);
                Action action = monster.PickAction(player.Suggestion);
                Debug.Log($"Player Suggested: {player.Suggestion} Monster {monster.name} did: {action.ToString()}");
                monster.Do(
                    action,
                    !isEnemyMonster ? player.Player.MonstersInCombat : enemy.Enemy.MonstersInCombat,
                    isEnemyMonster ? player.Player.MonstersInCombat : enemy.Enemy.MonstersInCombat
                );
            }

            _isOver = true;
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return _isOver;
        }

        public IBattlePhase GoToNext()
        {
            return new DamageCountPhase();
        }
    }
}