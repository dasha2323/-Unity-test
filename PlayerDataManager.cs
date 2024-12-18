using System;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private string dbPath;

    void Start()
    {
        dbPath = "URI=file:" + Path.Combine(Application.dataPath, "Plugins/dbbb.db");
    }

    public void SavePlayerPosition(string login, Vector3 position)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE parol SET save = @save WHERE login = @login";
                command.Parameters.AddWithValue("@save", $"{position.x},{position.y},{position.z}");
                command.Parameters.AddWithValue("@login", login);
                command.ExecuteNonQuery();
            }
        }
    }

    public Vector3 LoadPlayerPosition(string login)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT save FROM parol WHERE login = @login";
                command.Parameters.AddWithValue("@login", login);
                string savedPosition = command.ExecuteScalar() as string;

                if (!string.IsNullOrEmpty(savedPosition))
                {
                    string[] position = savedPosition.Split(',');
                    return new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
                }
            }
        }
        return Vector3.zero; // ¬озвращаем нулевую позицию, если данных нет
    }
}
