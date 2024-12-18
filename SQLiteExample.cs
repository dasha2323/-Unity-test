using System;
using System.Data;
using System.IO;
using System.Linq; 
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class SQLite2 : MonoBehaviour
{
    private string dbPath;
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_InputField passwordtwo; // New password confirmation field
    public TMP_Text feedbackText; 
    public bool registrationSuccessful = false; 

    void Start()
    {
        dbPath = "URI=file:" + Path.Combine(Application.dataPath, "Plugins/dbbb.db");
        CreateDatabase();
    }

    private void CreateDatabase()
    {
        if (!File.Exists(Path.Combine(Application.dataPath, "Plugins/dbbb.db")))
        {
            Debug.LogError("Database file does not exist!");
            return;
        }
    }

    public void Registr()
    {
        string logi = login.text;
        string pass = password.text;
        string passConfirm = passwordtwo.text; // Capture the confirmation password

        if (string.IsNullOrEmpty(logi) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(passConfirm))
        {
            feedbackText.text = "����� � ������ �� ����� ���� �������.";
            return;
        }

        if (logi.Length < 3 || pass.Length < 6)
        {
            feedbackText.text = "����� ������ ��������� ������� 3 �������, � ������ - ������� 6.";
            return;
        }

        if (pass != passConfirm) // Check if passwords match
        {
            feedbackText.text = "��������� ������ ������ �������. ��� ������ ���������.";
            return;
        }

        if (UserExists(logi))
        {
            feedbackText.text = "������������ � ����� ������� ��� ����������.";
            return;
        }

        if (IsPasswordAllSameCharacters(pass))
        {
            feedbackText.text = "������ �� ����� �������� �� ���������� ��������.";
            return;
        }

        if (!IsPasswordComplexEnough(pass))
        {
            feedbackText.text = "������ ������ ��������� ��� ������� ���� ��������� �����, ���� �������� ����� � ���� �����.";
            return;
        }

        InsertData(logi, pass);
        feedbackText.text = "����������� ������ �������!";
        registrationSuccessful = true; 

        SceneManager.LoadScene("demoScene_free");
    }

    private bool UserExists(string login)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM parol WHERE login = @login";
                command.Parameters.AddWithValue("@login", login);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
    }

    private void InsertData(string login, string password)
    {
        try
        {
            using (var connection = new SqliteConnection(dbPath))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO parol (login, parol) VALUES (@login, @parol)";
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@parol", password);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            feedbackText.text = "������ ��� �����������: " + ex.Message;
            Debug.LogError("Database error: " + ex.Message);
        }
    }

    private bool IsPasswordAllSameCharacters(string password)
    {
        return password.Length > 0 && password.All(c => c == password[0]);
    }

    private bool IsPasswordComplexEnough(string password)
    {
        bool hasUpperCase = false;
        bool hasLowerCase = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpperCase = true;
            if (char.IsLower(c)) hasLowerCase = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        return hasUpperCase && hasLowerCase && hasDigit;
    }
}