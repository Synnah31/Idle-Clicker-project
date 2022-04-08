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
        //IdleGModel.GetScore().Subscribe(ScoreView);
        _model = new IdleGModel();
        _model.GetMoney().Subscribe(_moneyView);
        _model.GetJoyPriceUpgrade().Subscribe(_joyUpgradePriceView);
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
}
