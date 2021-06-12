using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Seeker_DV : MonoBehaviour
{
    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private Vector3 _home;
    [SerializeField] private Rigidbody _rb;

    [SerializeField]
    private Transform _playerTransform;


    private Rigidbody rbPlayer1;
    private Rigidbody rbPlayer2;

    public float WanderFactor = 0.5f;
    public float StayFactor = 0.2f;
    public float SeekFactor = 0.8f;
    public float MaxDistance = 30;
    public float MoveForce = 10;
    public float SeekDistance = 5;

    public LayerMask _playerLayerMask;

    public void Start()
    {
        _home = transform.position;
        _rb = GetComponent<Rigidbody>();

        
    }

    public void Update()
    {
        if (_playerTransform == null)
        {
            // nach Player suchen
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, SeekDistance, _playerLayerMask);
            if (hitColliders.Length > 0)
            {
                _playerTransform = hitColliders[Random.Range(0, hitColliders.Length)].transform;
            }
        }
        else
        {
            // if distance > seek distance _playerTransform = null;
        }
    }

    public void FixedUpdate()
    {
        _moveVector = _moveVector.normalized;
        Wander();
        Stay();

        if (_playerTransform != null)
        {
            Seek();
        }
        

        _moveVector.y = 0;
        _rb.AddForce(_moveVector * MoveForce, ForceMode.Force);
    }

    private void Seek()
    {
        //Player 1 in Reichweite
        var distanceVector = transform.position - _playerTransform.position; // irgendwas mit player
        
        //Debug.Log(distance);
        _moveVector -= distanceVector.normalized * SeekFactor;


    }

    private void Stay()
    {
        var distanceVector = transform.position - _home;
        var distance = distanceVector.magnitude;
        //Debug.Log(distance);

        if (distance > MaxDistance)
        {
            _moveVector -= distanceVector.normalized * StayFactor;
        }
    }

    private void Wander()
    {
        var offset = (Random.insideUnitSphere * WanderFactor);

        _moveVector += offset;

        //Debug.Log(offset);
    }
}