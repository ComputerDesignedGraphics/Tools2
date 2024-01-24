using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target; // Player (Transform)
    [SerializeField] private float smoothTime; // "0.125"
    private Vector3 _currentVelocity = Vector3.zero;

    // @ Event function
    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    // @ Event function
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(current: transform.position, target: targetPosition, ref _currentVelocity, smoothTime);
    }
}
