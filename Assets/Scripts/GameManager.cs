using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject platformSpawner;
    public bool gameStarted;

    public float scoreUpdatingTime = 0.5f;
    public GameObject UIScoreGameObject;
    public GameObject UIMenuGameObject;

    public TMP_Text highScoreText;
    public TMP_Text scoreText;

    int score = 0;
    int highScore;

    AudioSource audioSource;

    public AudioClip gameStartClip;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "Highest Score : " + highScore;
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

        audioSource.clip = gameStartClip;
        audioSource.Play();

        platformSpawner.SetActive(true);
        UIScoreGameObject.SetActive(true);
        UIMenuGameObject.SetActive(false);

        StartCoroutine("UpdateScore");
    }


    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreUpdatingTime);
            score++;
            scoreText.text = score.ToString();
        }
    }


    void SaveHighScore()
    {
        //already have a highscore
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        //playing for the first time
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }


    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
}
