using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// IPointerDownHandler インターフェースを実装する
public class EnemyClick : MonoBehaviour, IPointerDownHandler
{
    float lifeTime = 5f;
    bool soundPlayed = false;

    [SerializeField] int scoreValue = 100;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip textSound;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // マウス押下・タップ時に呼ばれる関数
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ScoreManager.instance != null && ScoreManager.instance.IsTimeUp)
        {
            return;
        }

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        // 効果音を1回だけ再生
        if (!soundPlayed)
        {
            //audioSource.PlayOneShot(textSound);
            AudioSource.PlayClipAtPoint(textSound, Camera.main.transform.position,1.0f);
            soundPlayed = true;
        }

        // ダメージ処理や消滅処理
        Destroy(gameObject);
    }
}