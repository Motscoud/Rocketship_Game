using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyMove : MonoBehaviour {

    public Transform[] Waypoint;
    public float speed;
  //  public float Cull_Delay;
    public int CurrentWaypoint;
    public bool Patrol = true;
    public Vector2 Target;
    public Vector2 MoveDir;
    public Vector2 Velocity;
    private int count;
    public GameObject ShotStop;





    void Start()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pShot")
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            AudioSource audio = GetComponent<AudioSource>();
            ShotStop.SetActive(false);
            audio.Play();
            rend.enabled = false;
            Destroy(gameObject, audio.clip.length);

        }
    }





    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        //Destroy(gameObject, Cull_Delay);
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
    }
}


