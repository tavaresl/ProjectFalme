using UnityEngine;

namespace Assets.Scripts.Domain.Monsters
{
    public class SummerType : IMonsterType
    {

        private const int ValueVulnerability = 3;
        private MonsterType typeVulnerability = MonsterType.Spring;

        public int AddVulnerability(MonsterType attackerType)
        {
            if(attackerType.Equals(typeVulnerability)){
                return ValueVulnerability;
            }else{
                return 1;
            }
        }
        public MonsterType GetMonsterType() { return MonsterType.Summer; }

        public Color GetColor()
        {
            return new Color(0.8862f, 0.7058f, 0.1372f);
        }
    }
}

