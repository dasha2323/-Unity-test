using UnityEngine;

public class Gift : MonoBehaviour
{
    public int presentNumber; // ���������� ����� �������, ��������, 1, 2, 3
    private SQLThird database;

    void Start()
    {
        database = FindObjectOfType<SQLThird>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� � ������ ��������� ���������� ��� "Player"
        {
            string presentName = gameObject.name; // ��� ������� (��������, "Gift_CubeMedium")
            database.AddPresent(presentName, presentNumber);
            Debug.Log($"{presentName} ������! �����: {presentNumber}");
            Destroy(gameObject); // ������� ������, ���� �����
        }
    }
}
