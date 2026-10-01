using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI resultText;
    float timeRemaining = 60f;

    private int score = 0;

    void Awake() => instance = this;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        }
        else
        {
            if (timerText.text != "Time Up!")
            {
                timerText.text = "Time Up!";
                resultText.text = "Final Score: " + score;
                resultText.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(false);
                timerText.gameObject.SetActive(false);
            }
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }
    }

    public void AddScore(int amount)
    {
        if (timeRemaining <= 0) return;

        score += amount;
        scoreText.text = "Score: " + score;
    }
}