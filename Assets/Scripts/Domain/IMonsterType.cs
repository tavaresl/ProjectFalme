namespace Assets.Scripts.Domain
{
    public interface IMonsterType
    {
        int AddVulnerability(IMonsterType attackerType);
    }
}