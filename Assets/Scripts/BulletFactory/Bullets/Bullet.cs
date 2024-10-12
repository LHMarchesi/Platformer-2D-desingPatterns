using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public abstract string bulletName { get; set; }

    public abstract int damage { get; set; }

    public abstract void Initialize();
}

