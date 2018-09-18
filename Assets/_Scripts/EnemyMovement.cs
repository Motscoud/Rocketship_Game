using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//For SpinBlade Boss

public class EnemyMovement : MonoBehaviour {
	public Transform[] Waypoint;
	public float speed;
	public int CurrentWaypoint;
	public bool Patrol = true;
	public Vector2 Target;
	public Vector2 MoveDir;
	public Vector2 Velocity;



	void Start ()
	{

	}

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (CurrentWaypoint < Waypoint.Length)
        {
            Target = Waypoint[CurrentWaypoint].position;
            MoveDir = Target - (Vector2)transform.position;
            Velocity = GetComponent<Rigidbody2D>().velocity;

            if (MoveDir.magnitude < 1)
            {
                CurrentWaypoint++;
            }
            else
            {
                Velocity = MoveDir.normalized * speed;
            }
        }
        else
        {
            if (Patrol)
            {
                CurrentWaypoint = 0;
            }
            else
            {
                Velocity = Vector2.zero;
            }
        }
        GetComponent<Rigidbody2D>().velocity = Velocity;
        {
            transform.Rotate(new Vector3(0, 0, 200));
        }
    }

}

