using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Text finalScore;
    [SerializeField] Text HighScoreTxt;

    public void Setup(int score)
    {
        HighScore(score);
        gameObject.SetActive(true);
        finalScore.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HighScore(int score)
    {
        PlayerData data = SaveSystem.LoadScore();
        int fnlScore;
        if (data == null)
        {
            fnlScore = 0;
        }
        else
        {
            fnlScore = data.score;
        }
        if(fnlScore < score)
        {
            fnlScore = score;
            SaveSystem.SaveScore();
        }
        HighScoreTxt.text = "HighScore: " + fnlScore.ToString() + " POINTS";
    }

}
