using System;
using System.Collections.Generic;
using UnityEngine;

//Set our enemy on the path points we set 
//Once reaches the last point, destroys itslef
public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position; //changing the location of enemy ship from point to point
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            //distance moving each frame, how fast
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;//frame independant
            //to actually move the enemy
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            //when we reach certain to increment to new wave point
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            //once it reaches the end of the path
            Destroy(gameObject);
        }
    }
}
