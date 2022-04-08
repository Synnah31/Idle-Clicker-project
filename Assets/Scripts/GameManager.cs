using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ClicksTotalText;
    private IdleGModel _model;
    [SerializeField] IntView _moneyView;
    [SerializeField] IntView _joyUpgradePriceView;
    [SerializeField] IntView _sadUpgradePriceView;
    [SerializeField] IntView _fearUpgradePriceView;
    [SerializeField] IntView _angerUpgradePriceView;
    float TotalClicks;
    bool HasUpgrade = false;

    public int AutoClicksPerSecond;
    public int MinimumClicksToUnlockUpgrade;
    public void AddMoney()
    {
        _model.GetMoney().Add(1);

    }

    public void AutoClickUpgrade()
    {
        if (!HasUpgrade && TotalClicks >= MinimumClicksToUnlockUpgrade)
        {
            TotalClicks -= MinimumClicksToUnlockUpgrade;
            HasUpgrade = true;

        }
    }
    private void Start()
    {
        _model = new IdleGModel();
        _model.GetMoney().Subscribe(_moneyView);
        _model.GetJoyPriceUpgrade().Subscribe(_joyUpgradePriceView);
        _model.GetSadPriceUpgrade().Subscribe(_sadUpgradePriceView);
        _model.GetFearPriceUpgrade().Subscribe(_fearUpgradePriceView);
        _model.GetAngerPriceUpgrade().Subscribe(_angerUpgradePriceView);
    }

    private void Update()
    {
        if(HasUpgrade)
        {
            TotalClicks += AutoClicksPerSecond * Time.deltaTime;
            ClicksTotalText.text = TotalClicks.ToString("0");

        }
    }

    public void OnClickUpgradeJoy()
    {
        _model.IncrementJoy();
    }
    public void OnClickUpgradeSad()
    {
        _model.IncrementSad();
    }
    public void OnClickUpgradeFear()
    {
        _model.IncrementFear();
    }
    public void OnClickUpgradeAnger()
    {
        _model.IncrementAnger();
    }
}
