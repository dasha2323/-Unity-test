using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button exits;

    void Start()
    {
        if (exits != null)
        {
            exits.onClick.AddListener(OnExitButtonClicked);
        }
        else
        {
            Debug.LogError("Exit button is not assigned!");
        }
    }

    void OnExitButtonClicked()
    {
        // Переход на сцену start_game
        SceneManager.LoadScene("start_game");
    }
}