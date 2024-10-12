using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
    public abstract Bullet Bullet { get; set; }

    public string productName;
    //funcion de spawnear
    public abstract Bullet CreateBullet(Vector2 position);
}
