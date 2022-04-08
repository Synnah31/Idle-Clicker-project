using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGModel
{
    
    public int AutoClicksPerSecond;
    private IntObservable money;
    private IntObservable joyIncome;
    private IntObservable joyPriceUpgrade;
    private IntObservable sadIncome;
    private IntObservable sadPriceUpgrade;
    private IntObservable fearIncome;
    private IntObservable fearPriceUpgrade;
    private IntObservable angerIncome;
    private IntObservable angerPriceUpgrade;
    public IntObservable GetMoney()
    {
        return money;
    }

    public IntObservable GetJoyPriceUpgrade()
    {
        return joyPriceUpgrade;
    }

    public IdleGModel()
    {
        money = new IntObservable(0);
        joyIncome = new IntObservable(10);
        joyPriceUpgrade = new IntObservable(100);
    }

    internal void IncrementJoy()
    {
        joyIncome.Add((int)(joyIncome.GetValue() * 0.05));
        joyPriceUpgrade.Add((int)(joyPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementSad()
    {
        sadIncome.Add((int)(sadIncome.GetValue() * 0.1));
        sadPriceUpgrade.Add((int)(sadPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementFear()
    {
        fearIncome.Add((int)(fearIncome.GetValue() * 0.5));
        fearPriceUpgrade.Add((int)(fearPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementAnger()
    {
        angerIncome.Add((int)(angerIncome.GetValue() * 0.75));
        angerPriceUpgrade.Add((int)(angerPriceUpgrade.GetValue() * 0.2f));
    }
}



