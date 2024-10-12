using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public static event Action OnLowHp;
    //public static event Action OnDead;
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            GetDamage(bullet.damage);
        }
    }

    private void GetDamage(int damage)
    {
        GameManager.Instance.Hp -= damage;
        GameManager.Instance.UpdateHP();
        if (GameManager.Instance.Hp <= 10)
        {
            OnLowHp?.Invoke(); 
        }
    }


}
