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
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.linearVelocity = Vector2.up * velocity; // Mouse button ile kusu ziplatir 
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
        }
    }
}
