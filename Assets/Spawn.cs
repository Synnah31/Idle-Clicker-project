using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _waypointsJoy;
    [SerializeField] private GameObject _waypointsSad;
    [SerializeField] private GameObject _waypointsFear;
    [SerializeField] private GameObject _waypointsDisgust;
    [SerializeField] private GameObject _waypointsAnger;

    public GameObject Client;
    private float posRandX;
    private float posRandY;
    Vector2 posSpawn;
    public float spawnRate = 2f;
    private float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            posRandX = Random.Range(-8, -6);             
            posRandY = Random.Range(0, 3);             
            posSpawn = new Vector2(posRandX, posRandY);
            GameObject client = Instantiate(Client, posSpawn, Quaternion.identity);
            client.GetComponent<ClientControl>().Init(_waypointsJoy,_waypointsSad, _waypointsFear, _waypointsDisgust, _waypointsAnger);
            
        }
    }
}
