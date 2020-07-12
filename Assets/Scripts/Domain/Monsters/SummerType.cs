namespace Assets.Scripts.Domain.Monsters
{
    public class SummerType : IMonsterType
    {

        private const int ValueVulnerability = 3;
        private IMonsterType typeVulnerability = new SpringType();

        public int AddVulnerability(IMonsterType attackerType)
        {
            if(attackerType.Equals(typeVulnerability)){
                return ValueVulnerability;
            }else{
                return 1;
            }
        }
    }
}

