namespace Assets.Scripts.Domain
{
    public interface IMonsterType
    {
        public int AddVulnerability(IMonsterType attackerType);
    }
}