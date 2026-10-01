using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI ResultText;
    [SerializeField] TextMeshProUGUI ClearTitleText;

    float timeRemaining = 60f;
    private int Score = 0;

    // タイムアップ後にクリックを無効化する設定
    [SerializeField] private float transitionDelay = 3.0f;
    private float timeUpTimer = 0f; // タイムアップ経過時間のカウント用

    public bool IsTimeUp => timeRemaining <= 0;

    void Awake() => instance = this;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TimerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        }
        else
        {
            if (TimerText.text != "Time Up!")
            {
                ResultText.text = "Final Score: " + Score;
                ClearTitleText.text = "いなくなった！！";
                ClearTitleText.color = Color.red;
                ResultText.gameObject.SetActive(true);
                ClearTitleText.gameObject.SetActive(true);
                ScoreText.gameObject.SetActive(false);
                TimerText.gameObject.SetActive(false);
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

        Score += amount;
        ScoreText.text = "Score: " + Score;
    }
}