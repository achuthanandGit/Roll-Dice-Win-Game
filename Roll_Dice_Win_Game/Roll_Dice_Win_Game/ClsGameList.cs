namespace Roll_Dice_Win_Game
{
    class ClsGameList
    {
        private string gameHost;
        private int gameId;
        private string gameStatus;

        public string GameHost { get => gameHost; set => gameHost = value; }
        public int GameId { get => gameId; set => gameId = value; }
        public string GameStatus { get => gameStatus; set => gameStatus = value; }
    }
}
