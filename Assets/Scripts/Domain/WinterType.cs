namespace Assets.Scripts.Domain
{
    public class WinterType : IMonsterType
    {

        private const int ValueVulnerability = 3;
        private IMonsterType typeVulnerability = new FallType();

        public int addVulnerability(IMonsterType attackerType)
        {
            if(attackerType.Equals(typeVulnerability)){
                return ValueVulnerability;
            }else{
                return 1;
            }
            
        }
    }
}