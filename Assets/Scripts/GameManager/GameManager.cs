using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int hp;

    private int score;
    public int Hp { get => hp; set => hp = value; }
    public int Score { get => score; set => score = value; }

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI hpTxt;

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

    public void AddOneCoin()
    {
        score++;
        scoreTxt.text = "Coin: " + score.ToString();
    }

    public void UpdateHP()
    {
        hpTxt.text = "Healt: " + hp.ToString();
    }
}
