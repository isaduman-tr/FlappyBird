using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text ScoreText;
    public GameObject playGameButton;
    public GameObject PlayGameText;// Play Game butonunu burada referans alýn
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
        Time.timeScale = 0;
    }
   
    
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        
    }
    // Oyuna baþlatma metodu
    public void StartGame()
    {
        
        PlayGameText.SetActive(false);// Play Game butonunu gizle
        Time.timeScale = 1;
       
    }
}
