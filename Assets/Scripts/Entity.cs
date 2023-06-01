using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int lives = 0;

    public void GetDamage()
    {
        lives--;
        if (lives < 1)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
