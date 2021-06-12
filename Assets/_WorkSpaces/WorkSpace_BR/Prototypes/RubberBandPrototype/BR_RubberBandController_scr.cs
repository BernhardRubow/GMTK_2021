using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
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
        var factor = (bandMagnitude / 400);
        _lineColor.r = 1;
        _lineColor.b = 1 - factor;
        _lineColor.g = 1 - factor;

        _lineRenderer.material.SetColor("_Color", _lineColor);

        if (bandMagnitude > bandMax && !bandBroken)
        {
            bandBroken = true;
            _lineRenderer.enabled = false;
            EventManager.Invoke("OnRopeBroken", this, null);
            EventManager.Invoke("ScoreNetDestroy", this, null);
        }
        else if (bandMagnitude <= bandMax && bandBroken)
        {
            bandBroken = false;
            _lineRenderer.enabled = true;
            EventManager.Invoke("OnRopeFixed", this, null);
        }

        if (!bandBroken)
        {
            _lineRenderer.SetPosition(0, _endPoint01.position);
            _lineRenderer.SetPosition(1, _endPoint02.position);
        }
    }
}
