using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 cameraPosition;
    void Update() => transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
}
