using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField] WaveConfig WaveConfig;
    List<Transform> waypoints;
    float movingSpeed = 2f;
    int waypointIndex = 0;
	// Use this for initialization
	void Start () {
        waypoints = WaveConfig.GetWaypoints();
        movingSpeed = WaveConfig.GetMoveSpeed();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	public void SetWaveConfig(WaveConfig waveLink)
    {
        this.WaveConfig = waveLink;
    }
	// Update is called once per frame
	void Update ()
    {
        EnemyEnter();
    }

    private void EnemyEnter()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var moveThisFrame = movingSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                                (transform.position,
                                 targetPos, moveThisFrame);
            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
             Destroy(gameObject);
        }
    }
}
