using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour, IObserver<bool>
{
    private IdleGModel _model;
    [SerializeField] private GameObject _waypointsJoy;
    [SerializeField] private GameObject _waypointsSad;
    [SerializeField] private GameObject _waypointsFear;
    [SerializeField] private GameObject _waypointsDisgust;
    [SerializeField] private GameObject _waypointsAnger;

    [SerializeField] public GameObject Client;
    // Dans la fonction
    private float posRandX;
    private float posRandY;
    Vector2 posSpawn;

    public float spawnDeltaTime = 2f;
    public float nextSpawn = 0.0f;
    /*public float spawnRate = 2f;
    private float nextSpawn = 0.0f;*/
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
       /* _model.AddMoney(2);*/
       nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActive)
        {
            IdleEmotionSpawn();
        }
        /*if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;*/
            /*posRandX = Random.Range(-8, -6);             
            posRandY = Random.Range(0, 3);             
            posSpawn = new Vector2(posRandX, posRandY);
            GameObject client = Instantiate(Client, posSpawn, Quaternion.identity);
            client.GetComponent<ClientControl>().Init(_waypointsJoy,_waypointsSad, _waypointsFear, _waypointsDisgust, _waypointsAnger);*/
            
    }
    private void IdleEmotionSpawn()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnDeltaTime;
            posRandX = UnityEngine.Random.Range(-8, -6);
            posRandY = UnityEngine.Random.Range(0, 3);
            posSpawn = new Vector2(posRandX, posRandY);
            GameObject client = Instantiate(Client, posSpawn, Quaternion.identity);
            client.GetComponent<ClientControl>().Init(_waypointsJoy, _waypointsSad, _waypointsFear, _waypointsDisgust, _waypointsAnger);
        }
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(bool isIdleActive)
    {
        _isActive = isIdleActive;
    }
}

