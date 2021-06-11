using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_RubberBandController_scr : MonoBehaviour
{
    [SerializeField] private Transform _endPoint01;
    [SerializeField] private Transform _endPoint02;
    [SerializeField] private LineRenderer _lineRenderer;

    void Update()
    {
        _lineRenderer.SetPosition(0, _endPoint01.position);
        _lineRenderer.SetPosition(1, _endPoint02.position);
    }
}
