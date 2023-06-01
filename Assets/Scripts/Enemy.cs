using UnityEngine;

public class Enemy : Entity
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = Player.Initiate;
        if (other.gameObject == player.gameObject)
        {
            player.GetDamage();
            GetDamage();
        }
    }
}