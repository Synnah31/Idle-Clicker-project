using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoolObservable : IObservable<bool>
{
    private List<IObserver<bool>> _observers;

    private bool _value;

    public BoolObservable(bool value)
    {
        _value = value;
        _observers = new List<IObserver<bool>>();
    }

    public bool GetValue()
    {
        return _value;
    }

    public void SetValue(bool newValue)
    {
        _value = newValue;
        foreach (IObserver<bool> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }

    public IDisposable Subscribe(IObserver<bool> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }
}
