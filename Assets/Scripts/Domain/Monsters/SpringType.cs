namespace Assets.Scripts.Domain.Monsters
{
    public class SpringType : IMonsterType
    {

        private const int ValueVulnerability = 3;
        private IMonsterType typeVulnerability = new WinterType();

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