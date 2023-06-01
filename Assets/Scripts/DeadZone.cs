using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player player = Player.Initiate;
        if (other.gameObject == player.gameObject)
        {
            player.Die();
        }
    }
}
