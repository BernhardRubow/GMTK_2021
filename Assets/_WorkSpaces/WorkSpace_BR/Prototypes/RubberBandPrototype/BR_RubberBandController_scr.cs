using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_RubberBandController_scr : MonoBehaviour
{
    [SerializeField] private Transform _endPoint01;
    [SerializeField] private Transform _endPoint02;
    [SerializeField] private LineRenderer _lineRenderer;
    private bool bandBroken = false;
    [SerializeField] private float bandMax;
    private Color _lineColor = Color.white;
    void Update()
    {
        var bandLength = _endPoint01.position - _endPoint02.position;
        var bandMagnitude = bandLength.sqrMagnitude;
        var factor = 256 - (400 / bandMagnitude * 256);
        _lineColor.r = 256 - factor;
        _lineColor.b = factor;
        _lineColor.g = factor;

        _lineRenderer.material.SetColor("_Color", _lineColor);

        if (bandMagnitude > bandMax && !bandBroken)
        {
            bandBroken = true;
            _lineRenderer.enabled = false;
        }
        else if (bandMagnitude <= bandMax && bandBroken)
        {
            bandBroken = false;
            _lineRenderer.enabled = true;
        }

        if (!bandBroken)
        {
            _lineRenderer.SetPosition(0, _endPoint01.position);
            _lineRenderer.SetPosition(1, _endPoint02.position);
        }
    }
}
