using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpawnPoint : MonoBehaviour
{
    private bool saved = false;
    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!saved && collision.CompareTag("Player"))
        {
            GameManager.Instance.SaveGame();
            sprite.color = Color.cyan;
            saved = true;
        }
    }
}
