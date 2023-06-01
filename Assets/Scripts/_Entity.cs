using UnityEngine;

public class _Entity : MonoBehaviour
{
    public virtual void GetDamage(){}

    public virtual void Die(){
        gameObject.SetActive(false);
    }
}
