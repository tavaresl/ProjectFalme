using System;

namespace Assets.Scripts.Domain.Monsters
{
    public interface IMonsterType
    {
        int AddVulnerability(IMonsterType attackerType);
    }
}