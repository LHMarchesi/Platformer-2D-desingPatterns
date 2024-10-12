using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : Bullet
{
    [SerializeField] string BulletName;
    [SerializeField] int Damage;
    [SerializeField] float Speed;
    [SerializeField] bool TogleDireccion;

    public override string bulletName { get { return BulletName; } set { value = BulletName; } }
    public override int damage { get { return Damage; } set { value = Damage; } }

    public override void Initialize()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (TogleDireccion)
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
