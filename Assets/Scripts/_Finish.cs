using UnityEngine;

public class _Finish : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _Player.Instance.gameObject)
        {
            // deactivate cur level
            // download next level if it posible
            // other open End game window
        }
    }
}
