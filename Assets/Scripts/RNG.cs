namespace Assets.Scripts.Helpers
{
    public static class RNG
    {
        private static System.Random Rand = new System.Random();
        public static System.Random GetRandom() { return Rand; }
    }
}
