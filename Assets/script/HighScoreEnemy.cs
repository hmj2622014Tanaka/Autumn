using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// IPointerDownHandler インターフェースを実装する
public class HighScoreEnemyClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] float lifeTime = 5f;

    [SerializeField] int maxHP = 2;
    [SerializeField] int scoreValue = 500;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip textSound;

    int currentHP;
    bool soundPlayed = false;

    void Start()
    {
        currentHP = maxHP;

        Destroy(gameObject, lifeTime);
    }

    // マウス押下・タップ時に呼ばれる関数
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ScoreManager.instance != null && ScoreManager.instance.IsTimeUp)
        {
            return;
        }

        // 一回叩くごとにHPを減らす
        currentHP--;

        // HPが0になったら倒す
        if (currentHP < 0)
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // 効果音を1回だけ再生
            if (!soundPlayed)
            {
                //audioSource.PlayOneShot(textSound);
                AudioSource.PlayClipAtPoint(textSound, Camera.main.transform.position, 1.0f);
                soundPlayed = true;
            }

            // ダメージ処理や消滅処理
            Destroy(gameObject);
        }

    }
}
