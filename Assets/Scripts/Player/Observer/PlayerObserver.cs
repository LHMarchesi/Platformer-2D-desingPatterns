using TMPro;
using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    private void Awake()
    {
    }
    void Start()
    {
        PlayerActions.OnLowHp += LowHpSecuence;
        PlayerActions.OnDead += ReLoad;
    }

    void OnDisable()
    {
        PlayerActions.OnLowHp -= LowHpSecuence;
        PlayerActions.OnDead -= ReLoad;
    }

    private void LowHpSecuence()
    {
        UiManag.Instance.ShowLowHealthScreen(true);
    }

    private void ReLoad()
    {
        UiManag.Instance.ShowLowHealthScreen(false);
        GameManager.Instance.LoadSavedGame();
    }
}

