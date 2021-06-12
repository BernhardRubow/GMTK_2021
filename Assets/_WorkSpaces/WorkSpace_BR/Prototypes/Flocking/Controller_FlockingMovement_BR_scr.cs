using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Controller_FlockingMovement_BR_scr : MonoBehaviour
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _home;
    [SerializeField] private Rigidbody _rb;

    public float WanderFactor = 0.5f;
    public float StayFactor = 0.2f; 
    public float MaxDistance = 30;
    public float MoveForce = 10;

    public void Start()
    {
        _home = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        _moveVector = _moveVector.normalized;
        Wander();
        Stay();

        _moveVector.y = 0;
        _rb.AddForce(_moveVector * MoveForce, ForceMode.Force);
    }

    private void Stay()
    {
        var distanceVector = transform.position - _home;
        var distance = distanceVector.magnitude;
        Debug.Log(distance);

        if (distance > MaxDistance)
        {
            _moveVector -= distanceVector.normalized * StayFactor;
        }
    }

    private void Wander()
    {
        var offset = (Random.insideUnitSphere * WanderFactor);

        _moveVector += offset;

        Debug.Log(offset);
    }
}
