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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            GetDamage(bullet.damage);
        }
    }
    private void GetDamage(int damage)
    {
        GameManager.Instance.Health -= damage;
        GameManager.Instance.UpdateTxt();
        if (GameManager.Instance.Health <= 3)
        {
            OnLowHp?.Invoke(); 
        }
    }
}
