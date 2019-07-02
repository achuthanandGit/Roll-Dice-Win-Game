using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Roll_Dice_Win_Game
{
    class ClsConnectDbGetData
    {
        // Connection string required to establish the connection with DB
        static String connectionString = "Server=localhost;Port=3306;Database=rolldiceandwin;Uid=root;password=AppuMallus&123;";
        static MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

        // ExecuteProcedure execute the required procedure and return the DataSet
        public static DataSet ExecuteProcedure(String procedureName, List<MySqlParameter> parameterList)
        {
            try
            {
                if (parameterList != null)
                    return MySqlHelper.ExecuteDataset(mySqlConnection, procedureName, parameterList.ToArray());
                else
                    return MySqlHelper.ExecuteDataset(mySqlConnection, procedureName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                return null;
            }
        }
    }
}        
