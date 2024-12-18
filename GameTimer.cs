using UnityEngine;
using TMPro; // ����������� ������������ ���� ��� TMP

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // ������ �� ����� ��� �������
    public GameObject endGamePanel; // ������ �� ������ � ����������

    // ������ � ���������� ���������� ������� (� ��������)
    private int[] possibleTimes = { 20 * 60, 30 * 60, 59 * 60 }; // 20, 30 � 59 �����
    private float timeRemaining; // ���������� �����
    private bool timerIsRunning = false;

    void Start()
    {
        // �������� ��������� ����� �� �������
        timeRemaining = possibleTimes[Random.Range(0, possibleTimes.Length)];
        timerIsRunning = true; // ��������� ������
        endGamePanel.SetActive(false); // �������� ������
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // ��������� �����
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame(); // �������� ����� ���������� ����
            }
        }
    }

    void UpdateTimerUI()
    {
        // ����������� ���������� ����� � ������ � �������
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // ��������� �����
    }

    void EndGame()
    {
        endGamePanel.SetActive(true); // ���������� ������ � ����������
        // ����� ����� �������� �������������� ������ ��� ���������� ����
    }
}