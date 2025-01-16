using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Birdy : MonoBehaviour
{
    public bool �sDead;
    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public GameManager managergame;
    public GameObject DeathScreen;
    public AudioSource audioSource; // Eklenen sat�r
    public AudioClip[] audioClips; // Ses dosyalar�n� saklamak i�in dizi
    public AudioClip deathSound; // "DeathArea" �arp��mas� i�in �zel ses
    private int currentClipIndex = 0;
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.linearVelocity = Vector2.up * velocity; // Mouse button ile kusu ziplatir 
            PlayNextSoundInstantly();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            managergame.UpdateScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            �sDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            audioSource.PlayOneShot(deathSound);
        }
    }
    private void PlayNextSoundInstantly()
    {
        if (audioClips.Length == 0) return;

        // Mevcut ses dosyas�n� �al
        audioSource.PlayOneShot(audioClips[currentClipIndex]);

        // Sonraki ses dosyas�na ge�
        currentClipIndex++;

        // E�er son dosya �al�nd�ysa, ba�a d�n
        if (currentClipIndex >= audioClips.Length)
        {
            currentClipIndex = 0;
        }
    }
}
