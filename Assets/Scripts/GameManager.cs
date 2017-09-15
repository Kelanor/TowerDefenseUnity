using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool IsGameOver;

    void Start()
    {
        IsGameOver = false;        
    }

    void Update()
    {
        if (IsGameOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        IsGameOver = true;
        gameOverUI.SetActive(true);
    }
}
