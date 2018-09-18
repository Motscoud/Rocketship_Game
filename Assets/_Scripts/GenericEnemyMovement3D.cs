using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyMovement3D : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float Rotationdamp = .5f;
    [SerializeField] float ObjectDetection = 15f;
    [SerializeField] float PlayerDetection = 30f;
    [SerializeField] float RaycastOffset = 1f;
    [SerializeField] GameObject Shot;
    [SerializeField] Transform ShotSpawn;
    [SerializeField] float FireRate;
    [SerializeField] int DestroyDelay;
    private bool IsPlayerNear;
    private bool PlayerNearPause;
    private float nextFire;
    Transform myTransform;
    [SerializeField] float Shot_Forward;

    void Start()
    {
        CullTimer();
        //Boolean Initialization
        IsPlayerNear = false;
        PlayerNearPause = false;

    }

    // Update is called once per frame
    void Update ()
	{
	    if (!FindTarget())
	    {
	        return;
	    }
        Pathfinder();
        PlayerDetect();
        Move();
	}

    void CullTimer()
    {
        Destroy(gameObject, DestroyDelay);
    }
    void Turn()
    {

            Vector3 Position = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Rotationdamp * Time.deltaTime);

    }

    void Move()
    {
        //Checks if movement is allowed.
        //If the PlayerNear flag is set to false. Movement is allowed.
        if (IsPlayerNear == false)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

        //If PlayerNearPause is triggered, it will not start the Coroutine
        //This flag is triggered 
        //This flag is triggered during the Coroutine.

        if (PlayerNearPause == false)
        {
            StartCoroutine(ReturnMove());
        }
 
    }

    void Pathfinder()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero; 

        Vector3 left = transform.position - transform.right * RaycastOffset;
        Vector3 right = transform.position + transform.right * RaycastOffset;
        Vector3 up = transform.position + transform.up * RaycastOffset;
        Vector3 down = transform.position - transform.up * RaycastOffset;

        //Show rays in Unity Editor for Debugging purposes
        Debug.DrawRay(left, transform.forward * ObjectDetection, Color.blue);
        Debug.DrawRay(right, transform.forward * ObjectDetection, Color.blue);
        Debug.DrawRay(up, transform.forward * ObjectDetection, Color.blue);
        Debug.DrawRay(down, transform.forward * ObjectDetection, Color.blue);

        //Uses Raycasting to detect objects that are in the way of Enemy movement, Preventing collision with obstacles.

        if (Physics.Raycast(left, transform.forward, out hit, ObjectDetection))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, ObjectDetection))
             
                 raycastOffset -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, ObjectDetection))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, ObjectDetection))
                
                    raycastOffset += Vector3.up;

        if (raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
                
    }

    void PlayerDetect()
    {
        RaycastHit hit;

        Vector3 left = transform.position - transform.right * RaycastOffset;
        Vector3 right = transform.position + transform.right * RaycastOffset;
        Vector3 up = transform.position + transform.up * RaycastOffset;
        Vector3 down = transform.position - transform.up * RaycastOffset;

        Debug.DrawRay(left, transform.right * -1 * PlayerDetection, Color.red);
        Debug.DrawRay(right, transform.right * PlayerDetection, Color.red);
        Debug.DrawRay(up, transform.forward * PlayerDetection, Color.red);
        Debug.DrawRay(down, transform.forward * -1 * PlayerDetection, Color.red);

        if (Physics.Raycast(up, transform.forward, out hit, ObjectDetection))
        {
            Debug.Log("Player Hit!");
            PlayerLook();
        }
        else if (Physics.Raycast(down, transform.forward * -1, out hit, ObjectDetection))
        {
            Debug.Log("Player Hit!");
            PlayerLook();
        }
        else if (Physics.Raycast(left, transform.right * -1, out hit, ObjectDetection))
        {
            Debug.Log("Player Hit!");
            PlayerLook();
        }
        else if (Physics.Raycast(right, transform.right, out hit, ObjectDetection))
        {
            Debug.Log("Player Hit!");
            PlayerLook();
        }

    }

    void PlayerLook()
    {
        IsPlayerNear = true;
        transform.LookAt(target);
        Fire();
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler =
                Instantiate(Shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation) as GameObject;
            Shot.GetComponent<Rigidbody>().AddForce(transform.forward * Shot_Forward);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Shot_Forward);
        }
    }

    IEnumerator ReturnMove()
    {
        PlayerNearPause = true;
        yield return new WaitForSeconds(10);
        Debug.Log("Unlocking Movement!");
        PlayerNearPause = false;
        IsPlayerNear = false;
    }

    bool FindTarget()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
            return false;

        return true;
    }
}
