
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player & UI")]
    public PlayerColor player;          
    public TMP_Text scoreText;          
    public TMP_Text gameOverText;       

    public static GameManager instance;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        if (!isGameOver)
        {
            score += amount;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (gameOverText != null && !gameOverText.gameObject.activeSelf)
            gameOverText.gameObject.SetActive(true);

        Debug.Log("Game Over!");

        if (player != null)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;
        }

        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
