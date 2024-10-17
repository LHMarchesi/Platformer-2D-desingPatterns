using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiManag : MonoBehaviour
{
    public static UiManag Instance;
    
    [SerializeField] private GameObject OnLowHp_img;

    private TextMeshProUGUI coinsTxt;
    private TextMeshProUGUI hpTxt;

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
        coinsTxt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        hpTxt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();  
    }
    public void UpdateTxt()
    {
        coinsTxt.text = $"Coins: {GameManager.Instance.Coins}";
        hpTxt.text = $"Health: {GameManager.Instance.Health}";
    }

    public void ShowLowHealthScreen(bool value)
    {
        OnLowHp_img.SetActive(value);
    }
}
