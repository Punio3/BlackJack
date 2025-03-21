using Microsoft.Data.Sqlite;
using System;
using System.IO;


namespace BlackJackLogic
{
    public class Database
    {
        private static string dbPath = "blackjack.db";

        public void Initialize()
        {
            if (!File.Exists(dbPath))
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    string tableCommand = @"
                     CREATE TABLE IF NOT EXISTS GameData (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Player1_Cards TEXT NOT NULL, -- Lista kart gracza 1
                    Player2_Cards TEXT NOT NULL, -- Lista kart gracza 2
                    BetAmount INTEGER NOT NULL,   -- Kwota postawiona
                    Player1_Points INTEGER NOT NULL,
                    Player2_Points INTEGER NOT NULL
                    );";

                    using (var command = new SqliteCommand(tableCommand, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void SaveGameData(string player1Cards, string player2Cards, int betAmount, int Player1Points, int Player2Points)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    // Zapytanie INSERT do zapisania danych w tabeli
                    string insertCommand = @"
                                        INSERT INTO GameData (Player1_Cards, Player2_Cards, BetAmount, Player1_Points, Player2_Points)
                                        VALUES (@Player1_Cards, @Player2_Cards, @BetAmount, @Player1_Points, @Player2_Points);";

                    using (var command = new SqliteCommand(insertCommand, connection))
                    {
                        // Parametry, które będą wstawiane do bazy
                        command.Parameters.AddWithValue("@Player1_Cards", player1Cards);
                        command.Parameters.AddWithValue("@Player2_Cards", player2Cards);
                        command.Parameters.AddWithValue("@BetAmount", betAmount);
                        command.Parameters.AddWithValue("@Player1_Points", Player1Points);
                        command.Parameters.AddWithValue("@Player2_Points", Player2Points);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Funkcja zwracająca całą tabelę jako listę obiektów
        public List<GameData> GetAllGameData()
        {
            List<GameData> gameDataList = new List<GameData>();

            try
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();

                    string selectCommand = "SELECT * FROM GameData ORDER BY Id DESC;";
                    using (var command = new SqliteCommand(selectCommand, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var gameData = new GameData
                                {
                                    Id = reader.GetInt32(0), // Id
                                    Player1Cards = reader.GetString(1), // Player1_Cards
                                    Player2Cards = reader.GetString(2), // Player2_Cards
                                    BetAmount = reader.GetInt32(3), // BetAmount
                                    Player1_Points= reader.GetInt32(4),
                                    Player2_Points= reader.GetInt32(5)
                                };
                                gameDataList.Add(gameData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            return gameDataList;
        }
    }
}