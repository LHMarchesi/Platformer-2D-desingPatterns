using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] GameObject defaultShoot;
    IShoot currentShoot;

    public Transform BulletSpawnPos => bulletSpawnPos;

    private void Start()
    {
        currentShoot = defaultShoot.GetComponent<IShoot>();
    }

    private void Update()
    {
        if (currentShoot != null)
        {
            currentShoot.Shoot();
        }
    }
    public void SetShoot(IShoot Shoot)
    {
        currentShoot = Shoot;
        currentShoot.Shoot();
    }
}
