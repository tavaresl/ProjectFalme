namespace Assets.Scripts.Domain.Monsters
{
    public class WinterType : IMonsterType
    {

        private const int ValueVulnerability = 3;
        private MonsterType typeVulnerability = MonsterType.Fall;

        public int AddVulnerability(MonsterType attackerType)
        {
            if(attackerType.Equals(typeVulnerability)){
                return ValueVulnerability;
            }else{
                return 1;
            }
            
        }
        public MonsterType GetMonsterType() { return MonsterType.Winter; }
    }
}