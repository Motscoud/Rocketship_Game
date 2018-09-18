using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    public float speed;
    public float DestroyDelay;
    // Use this for initialization
    void Start()
    {
        var RigidBody2D = GetComponent<Rigidbody2D>();

        RigidBody2D.velocity = new Vector2(0.0f, speed);

    }
	// Update is called once per frame
	void Update () {
	    Destroy(gameObject, DestroyDelay);
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
