using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Birdy : MonoBehaviour
{
    public bool ÝsDead;
    public float velocity = 1f;
    public Rigidbody2D rb2D;
    public GameManager managergame;
    public GameObject DeathScreen;
    public AudioSource audioSource; // Eklenen satýr
    public AudioClip[] audioClips; // Ses dosyalarýný saklamak için dizi
    public AudioClip deathSound; // "DeathArea" çarpýþmasý için özel ses
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
            ÝsDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            audioSource.PlayOneShot(deathSound);
        }
    }
    private void PlayNextSoundInstantly()
    {
        if (audioClips.Length == 0) return;

        // Mevcut ses dosyasýný çal
        audioSource.PlayOneShot(audioClips[currentClipIndex]);

        // Sonraki ses dosyasýna geç
        currentClipIndex++;

        // Eðer son dosya çalýndýysa, baþa dön
        if (currentClipIndex >= audioClips.Length)
        {
            currentClipIndex = 0;
        }
    }
}
