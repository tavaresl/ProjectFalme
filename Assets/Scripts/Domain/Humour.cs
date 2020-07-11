namespace Assets.Scripts.Domain
{
    public interface IHumour
    {
        public Action GetAction(Suggestion suggestion);
        // Aggressive, // Tende a atacar
        // Pacific, // Tende a defender
        // Contrarian, // Tende a fazer a ação contrária da sugestão
        // Rebel, // Sugestão tem pouca influência, e pode fugir
        // Lazy, // Tende a não fazer nada
        // Obedient // Tende a seguir a sugestão
    }
}