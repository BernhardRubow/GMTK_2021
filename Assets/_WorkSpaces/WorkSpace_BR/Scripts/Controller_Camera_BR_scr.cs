using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Camera_BR_scr : MonoBehaviour
{
    [SerializeField] private Transform _player01;
    [SerializeField] private Transform _player02;

    
    public Vector3 _targetPosition;

    void Start()
    {
        _targetPosition.y = transform.position.y;
        _player01 = GameObject.Find("Player 1").transform;
        _player02 = GameObject.Find("Player 2").transform;

        StartCoroutine(CalcNewPosition());
    }

    IEnumerator CalcNewPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float y = _targetPosition.y;
            _targetPosition = (_player01.position - _player02.position) / 2 + _player02.position;
            _targetPosition.y = y;

        }
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}
