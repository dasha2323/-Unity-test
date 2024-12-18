using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button registration;
    public Button start;
    public SQLiteExample2 sqliteExample; 

    void Start()
    {
        if (registration != null)
        {
            registration.onClick.AddListener(OnRegistrationButtonClicked);
        }
        else
        {
            Debug.LogError("Registration button is not assigned!");
        }

        if (start != null)
        {
            start.onClick.AddListener(OnStartButtonClicked);
            start.interactable = false; 
        }
        else
        {
            Debug.LogError("Start button is not assigned!");
        }
    }

    void OnRegistrationButtonClicked()
    {
        SceneManager.LoadScene("fff");
    }

    void OnStartButtonClicked()
    {
        if (sqliteExample.IsLoginSuccessful()) 
        {
            SceneManager.LoadScene("demoScene_free");
        }
        else
        {
            Debug.Log("¬ход не был успешным, кнопка недоступна.");
        }
    }

    public void EnableStartButton()
    {
        if (sqliteExample.IsLoginSuccessful())
        {
            start.interactable = true; 
        }
    }
}