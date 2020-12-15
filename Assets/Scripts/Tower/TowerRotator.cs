using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private bool _androidTouch;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_androidTouch)
        {
            AndroidTouch();
        }
        else
        {
            HandleKey();
        }
    }

    private void AndroidTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                RotateTower(touch.deltaPosition.x);
            }
        }
    }

    private void HandleKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateTower(1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateTower(-1f);
        }
    }

    private void RotateTower(float x)
    {
        float torque = x * Time.deltaTime * _rotateSpeed;
        _rigidbody.AddTorque(Vector3.up * torque);
    }
}
