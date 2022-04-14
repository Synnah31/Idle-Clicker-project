using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineView : MonoBehaviour, IObserver<bool>
{
    [SerializeField] SpriteRenderer _spriteMachine;
    [SerializeField] Animator _animator;

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(bool unlock)
    {
        if (unlock)
        {
            _animator.SetBool("Unlock", true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
