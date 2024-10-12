using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] List<AbstractFactory> BulletFactory;
    [SerializeField] Transform BulletSpawnPos;


    private void Start()
    {
        StartCoroutine(ShootEveryTwoSeconds());
    }

    private IEnumerator ShootEveryTwoSeconds()
    {
        while (true)
        {
            
            int random = Random.Range(0, BulletFactory.Count);
            Bullet bullet = BulletFactory[random].CreateBullet(BulletSpawnPos.position);
            bullet.Initialize();

            yield return new WaitForSeconds(1f); // Espera 1 segundos
        }
    }
}
