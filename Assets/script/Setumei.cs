using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Setumei : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // クリックしたときゲーム画面になる
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("GameScene");
        }


    }
}