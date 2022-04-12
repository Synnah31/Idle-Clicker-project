using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientControl : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] List<GameObject> PathingJoy;
    [SerializeField] List<GameObject> PathingSad;
    [SerializeField] List<GameObject> PathingFear;
    [SerializeField] List<GameObject> PathingAnger;
    [SerializeField] List<GameObject> PathingDisgust;
    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints [waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move ();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                    waypoints[waypointIndex].transform.position,
                                                    moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    /*private void Move()     //TEST
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                    waypoints[waypointIndex].transform.position,
                                                    moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            do 
            {
                waypointIndex += 1;
            } while (waypointIndex == 2);


            
        }

        //Retour au départ
        /*if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }*/
}
