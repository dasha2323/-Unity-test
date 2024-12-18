using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(); // Начало воспроизведения
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f); // Устанавливаем громкость
    }

    public float GetVolume()
    {
        return audioSource.volume; // Возвращаем текущую громкость
    }
}