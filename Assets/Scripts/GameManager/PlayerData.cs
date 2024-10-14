using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public int playerScore;
    public int playerHealth;
    public Vector2 savedPosition;

    public PlayerData(int health, int score, Vector2 position)
    {
        savedPosition = position;
        playerHealth = health;
        playerScore = score;
        
    }
}
