using System.Collections.Generic;

namespace Assets.Scripts.Domain
{
    public interface IHumour
    {
        Action GetAction(Suggestion suggestion, float currentHP);
        Monster GetTarget(Action action, Monster self, IList<Monster> PlayerMonsters, IList<Monster> EnemyMonsters);
        // Aggressive, // Tende a atacar
        // Pacific, // Tende a defender
        // Contrarian, // Tende a fazer a ação contrária da sugestão
        // Rebel, // Sugestão tem pouca influência, e pode fugir
        // Lazy, // Tende a não fazer nada
        // Obedient // Tende a seguir a sugestão
    }
}