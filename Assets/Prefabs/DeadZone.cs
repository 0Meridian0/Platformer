using UnityEngine;

public class DeadZone : Entity
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            Player.Instance.Die();
        }
    }
}
