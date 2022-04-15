using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClientControl : MonoBehaviour
{
    /*private IdleGModel _model;
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

    

    private void Move()     //TEST
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

            if (_model.isSadMachineUp == false && _model.isFearMachineUp == false && _model.isDisgustMachineUp == false && _model.isAngerMachineUp == false)
            {
                //PathingJoy
            }

            if (_model.isFearMachineUp == false && _model.isDisgustMachineUp == false && _model.isAngerMachineUp == false)
            {
                //randomise PathingJoy + PathingSad
            }

            if (_model.isDisgustMachineUp == false && _model.isAngerMachineUp == false)
            {
                //randomise PathingJoy + PathingSad + PathingFear
            }

            if (_model.isAngerMachineUp == false)
            {
                //randomise PathingJoy + PathingSad + PathingFear + PathingDisgust
            }

            else
            {
                //randomise PathingJoy + PathingSad + PathingFear + PathingDisgust + PathingAnger
            }


        }

        //Retour au départ
        /*if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }*/
    private List<GameObject> _waypointsList;
    int currentWaypointsList = 0;
    public float moveSpeed;
    float WPradius = 1;                     // ?
    int randomList;
    bool stop;
    [SerializeField] private Animator _animator;
    private EMOTION _currentEmotion;
    private void Move()
    {
        if (!stop)
        {

            transform.position = Vector3.MoveTowards(transform.position,
                                                     _waypointsList[randomList].transform.GetChild(currentWaypointsList).transform.position,
                                                     moveSpeed * Time.deltaTime);
            if (Vector3.Distance(_waypointsList[randomList].transform.GetChild(currentWaypointsList).transform.position,
                                transform.position) < WPradius)
            {
                currentWaypointsList++;
                if ( currentWaypointsList >= _waypointsList[randomList].transform.childCount)
                {
                    stop = true;
                }

            }
        }
    }

    internal void Init(GameObject waypointsJoy, GameObject waypointsSad, GameObject waypointsFear, GameObject waypointsDisgust, GameObject waypointsAnger)
    {
        _waypointsList = new List<GameObject>();
        _waypointsList.Add(waypointsJoy);
        _waypointsList.Add(waypointsSad);
        _waypointsList.Add(waypointsFear);
        _waypointsList.Add(waypointsDisgust);
        _waypointsList.Add(waypointsAnger);
        //A finir
    }

    private void Start()
    {
        randomList = Random.Range(0,5);
    }

    private void Update()
    {
        Move();
    }

    internal void TransformToJoy()
    {
        _animator.SetBool("IsJoy", true);
        if (_currentEmotion == EMOTION.JOY)
        {
            _animator.SetBool("IsJoyx2", true);

        }
    }

    internal void TransformToSad()
    {
        _animator.SetBool("IsSad", true);
    }

    internal void TransformToFear()
    {
        _animator.SetBool("IsFear", true);
    }

    internal void TransformToDisgust()
    {
        _animator.SetBool("IsDisgust", true);
    }
    internal void TransformToAnger()
    {
        _animator.SetBool("IsAngry", true);
        if (_currentEmotion == EMOTION.ANGER)
        {
            _animator.SetBool("IsAngryx2", true);

        }
    }

    internal void ChooseRandomEmotion()
    {
        Array values = Enum.GetValues(typeof(EMOTION));
        System.Random random = new System.Random();
        EMOTION RandomEmotion = (EMOTION)values.GetValue(random.Next(values.Length));
        _currentEmotion = RandomEmotion;
        switch (RandomEmotion)
        {
            case EMOTION.JOY:
                _animator.SetBool("IsJoy", true);
                break;
            case EMOTION.SAD:
                _animator.SetBool("IsSad", true);
                break;
            case EMOTION.FEAR:
                _animator.SetBool("IsFear", true);
                break;
            case EMOTION.DISGUST:
                _animator.SetBool("IsDisgust", true);
                break;
            case EMOTION.ANGER:
                _animator.SetBool("IsAngry", true);
                break;

        }
    }
}

