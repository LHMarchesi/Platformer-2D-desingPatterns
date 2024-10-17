using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Tooltip("Controlador de jugador")]

    [SerializeField] private PlayerController playerController;
    [SerializeField] private int health;

    [Tooltip("Textos UI")]

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI hpTxt;

    private PlayerData playerData;
    private int score;
    public int Health { get => health; set => health = value; }
    public int Score { get => score; set => score = value; }


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

    public void LoadGame()
    {
        UpdateTxt();
        if (playerData != null)
        {
            LoadPlayerData(playerData);
        }
    }

    public void SaveGame()
    {
        playerData = SavePlayerData();
    }

    private PlayerData SavePlayerData()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        return new PlayerData(Health, Score, playerController.transform.position);
    }

    private void LoadPlayerData(PlayerData playerData)
    {
        playerController = FindAnyObjectByType<PlayerController>();

        health = playerData.playerHealth;
        score = playerData.playerScore;
        playerController.ResetPosition(playerData.savedPosition);
    }

    public void AddOneCoin()
    {
        score++;
        scoreTxt.text = "Coin: " + score.ToString();
    }

    public void UpdateTxt()
    {
        hpTxt.text = $"Score:{health}";
        scoreTxt.text = $"Score:{score}";
    }
}
