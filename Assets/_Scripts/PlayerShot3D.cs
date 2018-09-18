using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot3D : MonoBehaviour {
   // public float speed;
    public float DestroyDelay;
    
    // Use this for initialization
    void Start()
    {
       // var RigidBody = GetComponent<Rigidbody>();

     //   TransformDirection

    }
	// Update is called once per frame
	void Update ()
	{


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
