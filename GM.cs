using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int Lives = 3;
    public int Bricks = 30;
    public Text LivesText;
    public Text ScoreText;
    public Text WonScoreIs;
    public GameObject GameOver;
    public GameObject YouWon;
    public GameObject BricksPrefab;
    public GameObject BricksTwoHit;
    public GameObject Paddle;
    public GameObject DeathParticles;
    public static GM Instance = null;
    private GameObject ClonePaddle;
    public static int Score = 0;


    void Start() {

        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
        Setup();


    }

    public void Setup()
    {

        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(BricksPrefab, transform.position, Quaternion.identity);
        Instantiate(BricksTwoHit, new Vector3(-28.9f, -26.2f, 380.19f), Quaternion.identity);

    }

    void CheckGameOver()
    {

        if (Bricks < 1)
        {
            YouWon.SetActive(true);
            WonScoreIs.text = "Your Score Is: " + Score;
            WonScoreIs.transform.position = new Vector3(800, 200, 0);
            Time.timeScale = 0.25f;
            Invoke("Reset", 1);
        }

        if (Lives < 1)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", 1);
        }

    }

    private void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        Lives--;
        LivesText.text = "Lives " + Lives;
        Instantiate(DeathParticles, ClonePaddle.transform.position, Quaternion.identity);
        Destroy(ClonePaddle);
        Invoke("SetupPaddle", 1);
        CheckGameOver();
    }

    public void GainScore()
    {
        ScoreText.text = "Score " + Score;
    }

    void SetupPaddle()
    {
        ClonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        Bricks--;
        CheckGameOver();
    }

}
