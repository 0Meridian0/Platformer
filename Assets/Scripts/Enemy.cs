using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private int lives = 1;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.GetDamage();
            lives--;
        }
        if(lives < 1){
            Die();
        }
    }
}
