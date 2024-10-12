using TMPro;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    [SerializeField] private GameObject OnLowHp_img;

    private void Awake()
    {
        OnLowHp_img.SetActive(false);
    }
    void Start()
    {
        PlayerActions.OnLowHp += LowHpSecuence;
    }

    void OnDisable()
    {
        PlayerActions.OnLowHp -= LowHpSecuence;
    }

    public void LowHpSecuence()
    {
        OnLowHp_img.SetActive(true);
    }
}

