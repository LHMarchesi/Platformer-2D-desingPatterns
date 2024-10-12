using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet : Bullet
{
    [SerializeField] string BulletName;
    [SerializeField] int Damage;
    [SerializeField] float Speed;

    public override string bulletName { get { return BulletName; } set { value = BulletName; } }
    public override int damage { get { return Damage; } set { value = Damage; } }

    public override void Initialize()
    {
        Debug.Log("Instancia SmallBullet");
        Destroy(this, 5f);

    }

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
