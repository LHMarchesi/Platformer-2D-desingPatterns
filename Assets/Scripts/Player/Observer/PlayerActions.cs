using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public static event Action OnLowHp;
    public static event Action OnDead;

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
        GameManager.Instance.Health -= damage; // void setHealth ?
        UiManag.Instance.UpdateTxt();

        if (GameManager.Instance.Health <= 3)
        {
            OnLowHp?.Invoke();
        }
        if (GameManager.Instance.Health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
