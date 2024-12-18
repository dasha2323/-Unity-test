using UnityEngine;

public class Gift : MonoBehaviour
{
    public int presentNumber; // Уникальный номер подарка, например, 1, 2, 3
    private SQLThird database;

    void Start()
    {
        database = FindObjectOfType<SQLThird>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что у вашего персонажа установлен тег "Player"
        {
            string presentName = gameObject.name; // Имя объекта (например, "Gift_CubeMedium")
            database.AddPresent(presentName, presentNumber);
            Debug.Log($"{presentName} собран! Номер: {presentNumber}");
            Destroy(gameObject); // Удалить объект, если нужно
        }
    }
}
