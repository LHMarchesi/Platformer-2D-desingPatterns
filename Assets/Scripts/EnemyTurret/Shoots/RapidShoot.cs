using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShoot : MonoBehaviour, IShoot
{
    public float shootInterval = .5f;  // Tiempo entre disparo
    [SerializeField] private AbstractFactory bulletFactory;
    private float shootTimer = 0f;
    EnemyTurret turret;

    void Awake()
    {
        turret = GetComponentInParent<EnemyTurret>();
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;
        // Crear y disparar la bala
        if (shootTimer >= shootInterval)
        {
            Bullet bullet = bulletFactory.CreateBullet(turret.BulletSpawnPos.position);
            bullet.Initialize();
            shootTimer = 0f;
        }
    }
}
