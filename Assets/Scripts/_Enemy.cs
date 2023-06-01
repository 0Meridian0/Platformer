using UnityEngine;

public class _Enemy : _Entity
{
    [SerializeField] private int lives = 1;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject == _Player.Instance.gameObject)
        {
            _Player.Instance.GetDamage();
            lives--;
        }
        if(lives < 1){
            Die();
        }
    }
}
