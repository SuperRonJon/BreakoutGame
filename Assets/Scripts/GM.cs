using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public Text scoreText;
    public GameObject pauseMenu;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;
    private int score;
    private bool paused = false;

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
	}
	
    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
        Debug.Log(Time.fixedDeltaTime);
    }

    void CheckGameOver()
    {
        if(bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            //Time.fixedDeltaTime = Time.timeScale / .02f;
            Invoke("Reset", resetDelay);
        }

        if(lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            //Time.fixedDeltaTime = Time.timeScale / .02f;

            Invoke("Reset", resetDelay);
        }
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        //Time.fixedDeltaTime = .02f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        score += 10;
        scoreText.text = "Score: " + score;
        CheckGameOver();
    }

    public void TogglePause()
    {
        if (paused)
        {
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
