using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDCamera : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, 5f);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationalDamp = 10f;

    Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
    }

    private void LateUpdate()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.Lerp(myTransform.position, toPos, distanceDamp * Time.deltaTime);
        myTransform.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myTransform.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myTransform.rotation, toRot, rotationalDamp * Time.deltaTime);
        myTransform.rotation = curRot;
    }

}
