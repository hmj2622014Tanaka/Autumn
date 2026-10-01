using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// IPointerDownHandler インターフェースを実装する
public class EnemyClick : MonoBehaviour, IPointerDownHandler
{
    float lifeTime = 5f;

    [SerializeField] int scoreValue = 100;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // マウス押下・タップ時に呼ばれる関数
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        // ダメージ処理や消滅処理
        Destroy(gameObject);
    }
}