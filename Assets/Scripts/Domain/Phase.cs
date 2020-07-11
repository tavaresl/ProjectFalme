namespace Assets.Scripts.Domain
{
    public enum Phase
    {
        Draft,              // Jogador escolhe os monstros para colocar em batalha
        //--------- Loop Start --------//
        ActionSuggestion,   // Jogador sugere uma ação para o monstro em batalha
        ActionPick,         // Monstro decide qual ação tomar baseado no seu temperamento e na sugestão recebida
        MonsterSort,        // Ordenar os monstros em batalha para definir ordem de ataque 
        DamageCount,        // Contabilizar o dano causado por cada monstro no adversário e subtrair da vida de cada um deles
        MonsterDeathCheck,  // Verifica se um dos monstros em batalha pereceu
        BattleOverCheck,    // Verifica se um dos jogadores não possui mais monstros disponíveis
        //--------- Loop End --------//
        BattleOver,         // Todos os monstros de um jogador pereceram
    }
}