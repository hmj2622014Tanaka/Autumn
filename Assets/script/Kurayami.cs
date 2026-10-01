using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Kurayami : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] AudioSource audioSource; 
    [SerializeField] AudioClip textSound;

    float timer;
    bool soundPlayed = false;

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

            // 効果音を1回だけ再生
            if (!soundPlayed) 
            {
                audioSource.PlayOneShot(textSound); 
                soundPlayed = true; 
            }
        }

        // 5秒でタイトルへ
        if (timer >= 5f)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}