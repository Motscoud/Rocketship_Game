using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary1
{
    public float xMin, xMax, yMin, yMax;
}

public class Spaceship_Move : MonoBehaviour {
    //Initialization of variables here.
    public float speed;
    public Boundary1 boundary;
    public Animator characterAnimator;
    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    private float nextFire;

    void Update()
    {
        PlayerFire();
    }

	void FixedUpdate () {

        PlayerMove();
        PlayerLock();
       
    }

    //Below are subroutines that control Player Movement, Location Lock and firing.
    //Programming this way makes debugging so much easier!

    void PlayerMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2D");
        float moveVertical = Input.GetAxis("Vertical2D");

        var movement = new Vector2(moveHorizontal, moveVertical);
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = movement * speed;
    }

    void PlayerLock()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.position = new Vector2(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax)
        );


    }

    void PlayerFire()
    {
        bool IsPlayerFiring = Input.GetButton("Jump");
        if (IsPlayerFiring)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + FireRate;
                Instantiate(Shot, ShotSpawn);
            }
        }
    }
}

//
//                               ,-""   `.
//                             ,'  _   e )`-._
//                           /  ,' `-._<.===-'    _____ Quack!
//                           /  /
//                          /  ;
//              _.--.__    /   ;
// (`._ _.-""       "--'    |
// <_  `-""                     \
//  <`-                          :
//   (__<__.                  ;
//     `-.   '-.__.      _.'    /
//        \      `-.__,-'    _,'
//         `._    ,    /__,-'
//            ""._\__,'< <____
//                | |  `----.`.
//                | |        \ `.
//                 ; |___      \-``
//                 \   --<
//                  `.`.<
//                    `-'