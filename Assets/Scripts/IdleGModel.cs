using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGModel
{
    
    public int AutoClicksPerSecond;
    private IntObservable money;
    private IntObservable moneyIncome;          //Idle à créer
    private IntObservable joyIncome;
    private IntObservable joyPriceUpgrade;
    private IntObservable sadIncome;
    private IntObservable sadPriceUpgrade;
    private IntObservable fearIncome;
    private IntObservable fearPriceUpgrade;
    private IntObservable angerIncome;
    private IntObservable angerPriceUpgrade;
    private IntObservable disgustIncome;          
    private IntObservable disgustPriceUpgrade;
    private IntObservable idleSpawnUpgrade;

    public BoolObservable isSadMachineUnlock;
    public BoolObservable isIdleSpawnerUnlock;
    public bool isFearMachineUp;
    public bool isAngerMachineUp;
    public bool isDisgustMachineUp;               

    //private int joyUpgradeCounter;
    public IntObservable GetMoney()
    {
        return money;
    }

    public void AddMoney(int deltaMoney)
    {
        money.Add(deltaMoney);
    }

    //GetPriceUpgrade
    public IntObservable GetJoyPriceUpgrade()
    {
        return joyPriceUpgrade;
    }

    internal BoolObservable GetIsIdleSpawnerUnlock()
    {
        return isIdleSpawnerUnlock;
    }

    internal IntObservable GetIdleSpawnUpgrade()
    {
        return idleSpawnUpgrade;
    }

    internal IntObservable GetJoyIncome()           
    {
        return joyIncome;
    }
    internal IntObservable GetSadIncome()           
    {
        return sadIncome;
    }
    internal IntObservable GetFearIncome()           
    {
        return fearIncome;
    }
    internal IntObservable GetDisgustIncome()           
    {
        return disgustIncome;
    }
    internal IntObservable GetAngerIncome()           
    {
        return angerIncome;
    }
    public IntObservable GetSadPriceUpgrade()
    {
        return sadPriceUpgrade;
    }
    public IntObservable GetFearPriceUpgrade()
    {
        return fearPriceUpgrade;
    }
    public IntObservable GetDisgustPriceUpgrade()
    {
        return disgustPriceUpgrade;
    }
        public IntObservable GetAngerPriceUpgrade()
    {
        return angerPriceUpgrade;
    }
    public BoolObservable GetSadUnlock()
    {
        return isSadMachineUnlock;
    }
    public IdleGModel()
    {
        money = new IntObservable(0);
        joyIncome = new IntObservable(10);
        joyPriceUpgrade = new IntObservable(100);
        sadIncome = new IntObservable(100);
        sadPriceUpgrade = new IntObservable(1500);
        fearIncome = new IntObservable(400);
        fearPriceUpgrade = new IntObservable(20000);
        disgustIncome = new IntObservable(1000);
        disgustPriceUpgrade = new IntObservable(100000);
        angerIncome = new IntObservable(3500);
        angerPriceUpgrade = new IntObservable(500000);
        idleSpawnUpgrade = new IntObservable(10000);
        isSadMachineUnlock = new BoolObservable(false);
        isIdleSpawnerUnlock = new BoolObservable(false);
    }

    public void UnlockSadMachine()
    {
        isSadMachineUnlock.SetValue(true);
    }
    internal void IncrementJoy()
    {
        Debug.Log(joyIncome.GetValue());
        AddMoney(-joyPriceUpgrade.GetValue());
        joyIncome.Add((int)(joyIncome.GetValue() * 0.1));
        joyPriceUpgrade.Add((int)(joyPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementSad()
    {
        AddMoney(-sadPriceUpgrade.GetValue());
        sadIncome.Add((int)(sadIncome.GetValue() * 0.1));
        sadPriceUpgrade.Add((int)(sadPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementFear()
    {
        AddMoney(-fearPriceUpgrade.GetValue());
        fearIncome.Add((int)(fearIncome.GetValue() * 0.5));
        fearPriceUpgrade.Add((int)(fearPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementDisgust()
    {
        Debug.Log(disgustIncome.GetValue());
        AddMoney(-disgustPriceUpgrade.GetValue());
        disgustIncome.Add((int)(disgustIncome.GetValue() * 0.75));
        disgustPriceUpgrade.Add((int)(disgustPriceUpgrade.GetValue() * 0.2f));
    }

    internal void IncrementAnger()
    {
        AddMoney(-angerPriceUpgrade.GetValue());
        angerIncome.Add((int)(angerIncome.GetValue() * 0.75));
        angerPriceUpgrade.Add((int)(angerPriceUpgrade.GetValue() * 0.2f));
    }
}



