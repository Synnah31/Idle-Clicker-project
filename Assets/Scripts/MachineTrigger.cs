using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineTrigger : MonoBehaviour
{

    private UnityEvent<ClientControl> _onTriggerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Subscribe(UnityAction<ClientControl> listener)
    {
        Debug.Log("Entrer Subscribe");
        if (_onTriggerEnter == null)
        {
            Debug.Log("Entrer If Subscribe");
            _onTriggerEnter = new UnityEvent<ClientControl>();
        }
        _onTriggerEnter.AddListener(listener);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        _onTriggerEnter.Invoke(other.GetComponent<ClientControl>());
    }
}
