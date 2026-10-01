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
    [SerializeField] TextMeshProUGUI ClearTitleText;

    float timeRemaining = 60f;
    private int score = 0;

    // タイムアップ後にクリックを無効化する設定
    [SerializeField] private float transitionDelay = 5.0f;
    private float timeUpTimer = 0f; // タイムアップ経過時間のカウント用

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
                ClearTitleText.text = "ススキの中、もういない";
                ClearTitleText.color = Color.red;
                resultText.gameObject.SetActive(true);
                ClearTitleText.gameObject.SetActive(true);
                scoreText.gameObject.SetActive(false);
                timerText.gameObject.SetActive(false);
            }

            // タイムアップ後の経過時間をカウント
            timeUpTimer += Time.deltaTime;

            if (timeUpTimer < transitionDelay) return;

            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("Kurayami");
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