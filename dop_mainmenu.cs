using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dop_mainmenu : MonoBehaviour
{
    public Button Nexter;
    public Button exit;
    public Text feedbackText;
    public SQLite2 sqlite; 

    void Start()
    {
        if (Nexter != null)
        {
            Nexter.onClick.AddListener(OnNexterButtonClicked);
        }
        else
        {
            Debug.LogError("Nexter button is not assigned!");
        }

        if (exit != null)
        {
            exit.onClick.AddListener(OnExitButtonClicked);
        }
        else
        {
            Debug.LogError("Exit button is not assigned!");
        }
    }

    void OnNexterButtonClicked()
    {
        if (sqlite != null && sqlite.registrationSuccessful)
        {
            SceneManager.LoadScene("demoScene_free");
        }
        else
        {
            Debug.Log("Регистрация не завершена успешно. Пожалуйста, завершите регистрацию.");
        }
    }

    void OnExitButtonClicked()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "";
        }
        SceneManager.LoadScene("start_game");
    }
}