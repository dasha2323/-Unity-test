using UnityEngine;
using TMPro; // Импортируем пространство имен для TMP

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ссылка на текст для таймера
    public GameObject endGamePanel; // Ссылка на панель с сообщением

    // Массив с возможными значениями времени (в секундах)
    private int[] possibleTimes = { 20 * 60, 30 * 60, 59 * 60 }; // 20, 30 и 59 минут
    private float timeRemaining; // Оставшееся время
    private bool timerIsRunning = false;

    void Start()
    {
        // Выбираем случайное время из массива
        timeRemaining = possibleTimes[Random.Range(0, possibleTimes.Length)];
        timerIsRunning = true; // Запускаем таймер
        endGamePanel.SetActive(false); // Скрываем панель
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Уменьшаем время
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame(); // Вызываем метод завершения игры
            }
        }
    }

    void UpdateTimerUI()
    {
        // Преобразуем оставшееся время в минуты и секунды
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Обновляем текст
    }

    void EndGame()
    {
        endGamePanel.SetActive(true); // Показываем панель с сообщением
        // Здесь можно добавить дополнительную логику для завершения игры
    }
}