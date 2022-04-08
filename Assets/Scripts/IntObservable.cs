using System;
using System.Collections;
using System.Collections.Generic;


public class IntObservable : IObservable<int>
{
    private List<IObserver<int>> _observers;

    private int _value;

    public IntObservable(int value)
    {
        _value = value;
        _observers = new List<IObserver<int>>();
    }

    public void Add(int deltaValue)
    {
        _value += deltaValue;
        foreach (IObserver<int> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }
    //Faire les Get et Set dans le IntObservable puis gérer le model en prenant en compte les IntObservable
    public int GetValue()
    {
        return _value;
    }

    public void SetValue(int newValue)
    {
        _value = newValue;
    }

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if(!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }
}
