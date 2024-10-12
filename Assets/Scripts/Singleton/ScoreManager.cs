using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score;
    public int Score { get => score; set => score = value; }

    [SerializeField]private TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddOne()
    {
        score++;
        scoreTxt.text = "Coin: " + score.ToString();
    }
}
