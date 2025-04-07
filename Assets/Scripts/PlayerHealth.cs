using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives = 1;

    public float invicibleTime = 1.0f;
    public bool isInvincible = false;

    private void Start()
    {
        currentLives = maxLives;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            currentLives--;
            Destroy(other.gameObject);

            Debug.Log(currentLives);
            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
