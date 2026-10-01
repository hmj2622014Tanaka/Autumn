using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// IPointerDownHandler インターフェースを実装する
public class HighScoreEnemyClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] float lifeTime = 5f;

    [SerializeField] int maxHP = 3;
    [SerializeField] int scoreValue = 500;

    int currentHP;

    void Start()
    {
        currentHP = maxHP;

        Destroy(gameObject, lifeTime);
    }

    // マウス押下・タップ時に呼ばれる関数
    public void OnPointerDown(PointerEventData eventData)
    {
        // 一回叩くごとにHPを減らす
        currentHP--;

        // HPが0になったら倒す
        if (currentHP < 0)
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // ダメージ処理や消滅処理
            Destroy(gameObject);
        }

    }
}
