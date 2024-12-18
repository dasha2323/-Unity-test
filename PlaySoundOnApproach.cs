using UnityEngine;

public class PlaySoundOnApproach : MonoBehaviour
{
    public AudioClip soundToPlay; // Звук, который нужно воспроизвести
    private AudioSource audioSource;

    public float triggerDistance = 0.5f; // Установлено на 0.5

    private bool isPlaying = false; // Флаг для отслеживания состояния звука

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < triggerDistance && !isPlaying)
            {
                audioSource.PlayOneShot(soundToPlay);
                isPlaying = true; // Звук начал воспроизводиться
            }
            else if (distance >= triggerDistance)
            {
                isPlaying = false; // Сбрасываем флаг, если игрок удалился
            }
        }
    }
}