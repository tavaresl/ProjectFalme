namespace Assets.Scripts.Domain
{
    public class Battle
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }
        public Phase CurrentPhase { get;set; }   
    }

    // Devaneio do kevyn: monstro rebelde pode atacar diretamente o jogador inimigo, ação não disponível para o jogador sugerir
    // To think about: jogadores terão pontos de vida?
    public enum Phase
    {
        MonsterSort, // Ordenar os monstros de cada jogador pela sua velocidade 
        MonsterPick, // Escolher o próximo monstro mais rápido do jogador
        ActionSuggestion, // Jogador sugere uma ação para o monstro em batalha
        ActionPick, // Monstro decide qual ação tomar baseado no seu temperamento e na sugestão recebida
        DamageCount, // Contabilizar o dano causado por cada monstro no adversário e subtrair da vida de cada um deles
        MonsterDeathCheck, // Verifica se um dos monstros em batalha nos deixou
        BattleOverCheck, // Verifica se um dos jogadores não possui mais monstros disponíveis
        BattleOver, // Todos os monstros de um jogador nos deixaram
    }
}

