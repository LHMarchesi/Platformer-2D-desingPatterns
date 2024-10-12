using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : AbstractFactory
{
    [SerializeField] Bullet bullet;

    public override Bullet Bullet { get ; set; }

    public override Bullet CreateBullet(Vector2 position)
    {
        return Instantiate(bullet, position, Quaternion.identity);
    }
}
