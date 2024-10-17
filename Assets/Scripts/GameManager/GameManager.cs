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

    private PlayerData playerData;
    private int coins;
    public int Health { get => health; set => health = value; }
    public int Coins { get => coins; set => coins = value; }


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

    public void LoadSavedGame()
    {
        UiManag.Instance.UpdateTxt();
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
        return new PlayerData(Health, Coins, playerController.transform.position);
    }

    private void LoadPlayerData(PlayerData playerData)
    {
        playerController = FindAnyObjectByType<PlayerController>();

        health = playerData.playerHealth;
        coins = playerData.playerScore;
        playerController.ResetPosition(playerData.savedPosition);
    }

    public void AddOneCoin()
    {
        coins++;
        UiManag.Instance.UpdateTxt();
    }
}
