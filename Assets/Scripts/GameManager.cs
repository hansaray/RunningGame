using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameOverScreen gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.Setup(score);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
        Application.targetFrameRate = 60;
    }
}
