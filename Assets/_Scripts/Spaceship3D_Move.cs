using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class Spaceship3D_Move : MonoBehaviour
{
    public Boundary2 boundary3D;
    public float Speed = 50f;
    public float turnSpeed = 60f;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    private float nextFire;
    Transform myTransform;
    public float Shot_Forward;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Thrust();
        Turn();
        PlayerFire();
    }

    void FixedUpdate()
    {
        //Player_Limit();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");

        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myTransform.Rotate(pitch, yaw, roll);
    }

    void PlayerFire()
    {
        bool IsPlayerFiring = Input.GetButton("Jump");
        if (IsPlayerFiring)
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
    }

    private void Player_Limit()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary3D.xMin, boundary3D.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary3D.yMin, boundary3D.yMax),
            Mathf.Clamp(rigidbody.position.z,boundary3D.zMin, boundary3D.zMax)
        );


    }

    private void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            myTransform.position -= myTransform.forward * Speed * Time.deltaTime * Input.GetAxis("Vertical");
        }
    }
}