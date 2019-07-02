namespace Roll_Dice_Win_Game
{
    class ClsScoreList
    {
        private string username;
        private int highScore;
        private string accountStatus;
        private string userTurn;

        public string Username { get => username; set => username = value; }
        public int HighScore { get => highScore; set => highScore = value; }
        public string AccountStatus { get => accountStatus; set => accountStatus = value; }
        public string UserTurn { get => userTurn; set => userTurn = value; }
    }
}
