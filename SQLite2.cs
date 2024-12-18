using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using TMPro;
using System.IO;

public class SQLiteExample2 : MonoBehaviour
{
    private string dbPath;
    public TMP_InputField login;
    public TMP_InputField password;
    public TextMeshProUGUI Vivod;
    private bool loginSuccessful = false;

    void Start()
    {
        dbPath = "URI=file:" + Path.Combine(Application.dataPath, "Plugins/dbbb.db");
        CreateDatabase();
    }

    private void CreateDatabase()
    {
        if (!File.Exists(Path.Combine(Application.dataPath, "Plugins/dbbb.db")))
        {
            Debug.LogError("Файл базы данных не существует!");
            return;
        }
    }

    public void Login()
    {
        string logi = login.text;
        string pass = password.text;
        if (CheckCredentials(logi, pass))
        {
            Vivod.text = "Вход успешен!";
            loginSuccessful = true; 
            FindObjectOfType<MenuController>().EnableStartButton(); 
        }
        else
        {
            Vivod.text = "Пользователь не найден. Пожалуйста, проверьте свои данные.";
            login.text = "";
            password.text = "";
            loginSuccessful = false; 
        }
    }

    private bool CheckCredentials(string login, string password)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM parol WHERE login = @login AND parol = @parol";
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@parol", password);

                int userCount = Convert.ToInt32(command.ExecuteScalar());
                return userCount > 0;
            }
        }
    }

   
    public bool IsLoginSuccessful()
    {
        return loginSuccessful;
    }
}