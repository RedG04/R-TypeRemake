using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public int health = 5;
    [SerializeField] private Scene gameOver;


    public void TakeDamage(int damage)
    {
        health -= damage;

        // If health reaches 0, destroy the player

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);

        // Attendi 3 secondi prima di cambiare scena
        Invoke("LoadGameOverScene", 3f);
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(3);
    }

}
