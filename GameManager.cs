using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;

    AudioSource audioS;
    public AudioClip[] gameMusics;

    int score = 0;
    int highScoreInt = 0;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        audioS = GetComponent<AudioSource>();
    }
    private void Start()
    {
        highScoreInt = PlayerPrefs.GetInt("HighScore");
        highScore.text = "Best Score : " + highScoreInt;

        
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);

        audioS.clip = gameMusics[1];
        audioS.Play();

        StartCoroutine("UpdateScore");
    }
    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator  UpdateScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }

    void SaveHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
