using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Controller_FlockingMovement_BR_scr : MonoBehaviour
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _home;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _moveForce;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _wanderFactor;
    [SerializeField] private float _stayFactor;

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
        _rb.AddForce(_moveVector * _moveForce, ForceMode.Force);
    }

    private void Stay()
    {
        var distanceVector = transform.position - _home;
        var distance = distanceVector.magnitude;
        Debug.Log(distance);

        if (distance > _maxDistance)
        {
            _moveVector -= distanceVector.normalized * _stayFactor;
        }
    }

    private void Wander()
    {
        var offset = (Random.insideUnitSphere * _wanderFactor);

        _moveVector += offset;

        Debug.Log(offset);
    }
}
