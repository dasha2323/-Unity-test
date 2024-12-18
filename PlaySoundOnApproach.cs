using UnityEngine;

public class PlaySoundOnApproach : MonoBehaviour
{
    public AudioClip soundToPlay; // ����, ������� ����� �������������
    private AudioSource audioSource;

    public float triggerDistance = 0.5f; // ����������� �� 0.5

    private bool isPlaying = false; // ���� ��� ������������ ��������� �����

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
                isPlaying = true; // ���� ����� ����������������
            }
            else if (distance >= triggerDistance)
            {
                isPlaying = false; // ���������� ����, ���� ����� ��������
            }
        }
    }
}