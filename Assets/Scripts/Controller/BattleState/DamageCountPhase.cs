using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class DamageCountPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            foreach (GameObject monsterGameObject in battle.PlayerCharacter.Monsters)
            {
                monsterGameObject.GetComponent<MonsterController>().SetHealth();
            }

            foreach (GameObject monsterGameObject in battle.EnemyCharacter.Monsters)
            {
                monsterGameObject.GetComponent<MonsterController>().SetHealth();
            }
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return true;
        }

        public IBattlePhase GoToNext()
        {
            return new MonsterDeathCheckPhase();
        }
    }
}