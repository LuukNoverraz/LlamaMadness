using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 cameraPosition;
    void Update() => transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
}
