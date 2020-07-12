using System;

namespace Assets.Scripts.Domain.Monsters
{
    public interface IMonsterType
    {
        int AddVulnerability(MonsterType attackerType);

        MonsterType GetMonsterType();
    }
}