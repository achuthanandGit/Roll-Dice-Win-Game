using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Roll_Dice_Win_Game
{
    class ClsExtractData
    {
        // Manipulating the procedure result for checking username existance
        internal static string CheckUserNameExistance(string inputUsername)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            usernameParam.Value = inputUsername;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("CheckUserExistance(@username)", parameterList);
            if (dataset == null)
                return "Something went wrong. Clear the input and try again.";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Return list of players for admin operations
        internal static List<ClsScoreList> GetPalyerListForAdmin()
        {
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetPlayerListForAdmin()", null);
            if (dataset == null)
                return null;
            List<ClsScoreList> scoreList = new List<ClsScoreList>();
            DataRowCollection rowCollection = dataset.Tables[0].Rows;
            if (rowCollection.Count == 0)
                return scoreList;
            foreach (DataRow dataRow in rowCollection)
            {
                ClsScoreList scoreEntry = new ClsScoreList();
                scoreEntry.Username = dataRow.ItemArray[0].ToString();
                scoreEntry.HighScore = Convert.ToInt32(dataRow.ItemArray[1].ToString());
                scoreEntry.AccountStatus = dataRow.ItemArray[2].ToString();
                scoreList.Add(scoreEntry);
            }
            return scoreList;
        }

        // Returns the result when a dice is rolled
        internal static string GenerateDiceRollOutput(int gameId, string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GenerateDiceRollOutput(@gameId,@username)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again.";
            else
                return dataset.Tables[0].Rows[0]["rollresult"].ToString();
        }

        // Returns the game details when a player joined a game
        internal static DataRowCollection JoinGame(int gameId, string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("JoinGame(@gameId,@username)", parameterList);
            if (dataset == null)
                return null;
            else
                return dataset.Tables[0].Rows;
        }

        // Returns the updated user token position when a dice is rolled
        internal static DataRowCollection UpdateUserPosition(int gameId, int diceSide, string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            MySqlParameter diceSideParam = new MySqlParameter("@diceSide", MySqlDbType.Int32);
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            diceSideParam.Value = diceSide;
            parameterList.Add(diceSideParam);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("UpdatePlayerPosition(@gameId,@diceSide,@username)", parameterList);
            if (dataset == null)
                return null;
            else
                return dataset.Tables[0].Rows;
        }

        // Returns the result when the player inputs the login credentials
        internal static string CheckUserAuthentication(string username, string password)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            passwordParam.Value = password;
            parameterList.Add(usernameParam);
            parameterList.Add(passwordParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("CheckUserAuthentication(@username,@password)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Returns the score list of live game
        internal static List<ClsScoreList> GetGameRoomScoreList(int gameId)
        {
            List<ClsScoreList> scoreList = new List<ClsScoreList>();
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetGameRoomScoreList(@gameId)", parameterList);
            if (dataset == null)
                return scoreList;
            DataRowCollection rowCollection = dataset.Tables[0].Rows;
            if (rowCollection.Count == 0)
                return scoreList;
            foreach (DataRow dataRow in rowCollection)
            {
                ClsScoreList scoreEntry = new ClsScoreList();
                scoreEntry.Username = dataRow.ItemArray[0].ToString();
                scoreEntry.HighScore = Convert.ToInt32(dataRow.ItemArray[1].ToString());
                scoreEntry.UserTurn = dataRow.ItemArray[2].ToString();
                scoreList.Add(scoreEntry);
            }
            return scoreList;
        }

        // Returns the game details when a player start a new game
        internal static List<string> StartGame(string username)
        {
            List<String> resultList = new List<string>();
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("CreateNewGame(@username)", parameterList);
            if (dataset == null) {
                resultList.Add("Something went wrong. Please try again");
                return resultList;
            }
            resultList.Add(dataset.Tables[0].Rows[0][0].ToString());
            resultList.Add(dataset.Tables[0].Rows[0][1].ToString());
            resultList.Add(dataset.Tables[0].Rows[0][2].ToString());
            return resultList;
        }

        // Returns the status of game while playing a game. Used for the preriodic refresh of game room
        internal static string GetGameStatus(int gameId)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetGameStatus(@gameId)", parameterList);
            if (dataset == null)
                return "Something went wrong. Process will repeat once you click OK.";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Retruns the details of game board while playing a game. Used for the periodic refresh of game room
        internal static List<ClsGameBoard> GetGameBoardData(int gameId)
        {
            List<ClsGameBoard> gameBoardList = new List<ClsGameBoard>();
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetGameBoardDetails(@gameId)", parameterList);
            if (dataset == null)
                return gameBoardList;
            
            DataRowCollection rowCollection = dataset.Tables[0].Rows;
            if (rowCollection.Count == 0 ||
                rowCollection[0].Table.Columns.Contains("message"))
                return gameBoardList;

            foreach (DataRow dataRow in rowCollection)
            {
                ClsGameBoard boardEntry = new ClsGameBoard();
                boardEntry.PlayerPosition = Convert.ToInt32(dataRow.ItemArray[0].ToString());
                boardEntry.PlayerColor = dataRow.ItemArray[1].ToString();
                gameBoardList.Add(boardEntry);
            }
            return gameBoardList;
        }

        // Returns the result of reset password
        internal static string ResetPassword(string username, string password)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            passwordParam.Value = password;
            parameterList.Add(usernameParam);
            parameterList.Add(passwordParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("ResetPassword(@username,@password)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Returns the result when a player is removed by admin
        internal static string DeleteUser(string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("DeleteUser(@username)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Returns the result when a game is terminated by admin
        internal static string TerminateGame(int gameId)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("TerminateGame(@gameId)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Returns the result when a player exists a game
        internal static string ExitGame(int gameId, string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter gameIdParam = new MySqlParameter("@gameId", MySqlDbType.Int32);
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            gameIdParam.Value = gameId;
            parameterList.Add(gameIdParam);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("ExitGame(@gameId,@username)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again.";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Return the result when admin unlocks locked player
        internal static string UnlockUser(string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("UnLockUser(@username)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Return the result of Registering new user
        internal static string RegisterNewUser(string username, string password, string email)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter modeParam = new MySqlParameter("@mode", MySqlDbType.VarChar, 10);
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar, 50);
            MySqlParameter emailParam = new MySqlParameter("@email", MySqlDbType.VarChar, 50);
            modeParam.Value = "admin";
            usernameParam.Value = username;
            passwordParam.Value = password;
            emailParam.Value = email;
            parameterList.Add(modeParam);
            parameterList.Add(usernameParam);
            parameterList.Add(passwordParam);
            parameterList.Add(emailParam);
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure(
                "RegisterNewUser(@mode,@username,@password,@email)", parameterList);
            if (dataset == null)
                return "Something went wrong. Please try again";
            else
                return dataset.Tables[0].Rows[0]["message"].ToString();
        }

        // Returns the list of online players with their high score
        internal static List<ClsScoreList> GetOnlinePlayerList()
        {
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetOnlinePlayerList()", null);
            if (dataset == null)
                return null;
            List<ClsScoreList> scoreList = new List<ClsScoreList>();
            DataRowCollection rowCollection = dataset.Tables[0].Rows;
            if (rowCollection.Count == 0)
                return scoreList;
            foreach (DataRow dataRow in rowCollection)
            {
                ClsScoreList scoreEntry = new ClsScoreList();
                scoreEntry.Username = dataRow.ItemArray[0].ToString();
                scoreEntry.HighScore = Convert.ToInt32(dataRow.ItemArray[1].ToString());
                scoreList.Add(scoreEntry);
            }
            return scoreList;
        }

        // Session end of login user
        internal static void LogOutSession(string username)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 50);
            usernameParam.Value = username;
            parameterList.Add(usernameParam);
            ClsConnectDbGetData.ExecuteProcedure("LogOutSession(@username)", parameterList);
        }

        // Returns a list of game to load in the dashboard
        internal static List<ClsGameList> GetGameList()
        {
            DataSet dataset = ClsConnectDbGetData.ExecuteProcedure("GetGameList()", null);
            if (dataset == null)
                return null;
            List<ClsGameList> gameList = new List<ClsGameList>();
            DataRowCollection rowCollection = dataset.Tables[0].Rows;
            if (rowCollection.Count == 0)
                return gameList;
            foreach (DataRow dataRow in rowCollection)
            {
                ClsGameList gameEntry = new ClsGameList();
                gameEntry.GameHost = dataRow.ItemArray[0].ToString();
                gameEntry.GameId = Convert.ToInt32(dataRow.ItemArray[1].ToString());
                gameEntry.GameStatus = dataRow.ItemArray[2].ToString();
                gameList.Add(gameEntry);
            }
            return gameList;
        }
    }
}
