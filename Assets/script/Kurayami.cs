using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Kurayami : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    float timer;

    void Start()
    {
        // テキストの非表示
        text.gameObject.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 3秒経ったらテキスト表示
        if(timer >= 3f &&  timer < 5f)
        {
            text.gameObject.SetActive(true);
        }

        // 5秒でタイトルへ
        if(timer >= 5f)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}