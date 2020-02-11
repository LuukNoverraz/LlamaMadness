using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform[] playerTransforms;
    private Vector3 cameraPosition;
    private float playerDistance;

    void Update()
    {
        playerDistance = ((playerTransforms[0].position.z + playerTransforms[1].position.z) / 2) - 4;
        transform.position = new Vector3(0, 2.7f, playerDistance);
    }
}
