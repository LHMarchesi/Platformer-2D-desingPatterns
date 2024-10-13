using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShootOnTrigger : MonoBehaviour
{
    EnemyTurret turret;
    IShoot newShoot;

    private void Awake()
    {
        newShoot = GetComponentInParent<IShoot>();
        turret = GetComponentInParent<EnemyTurret>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            turret.SetShoot(newShoot);
        }
    }
}
