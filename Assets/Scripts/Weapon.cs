using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _attackRange;
    private int _damage;

    private Weapon[] weapons;
}

public class Sword : Weapon
{}

public class Bow : Weapon
{}

public class FireBall : Weapon
{}