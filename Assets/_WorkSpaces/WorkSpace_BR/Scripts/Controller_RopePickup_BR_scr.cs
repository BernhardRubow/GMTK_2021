using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_RopePickup_BR_scr : MonoBehaviour
{
    [SerializeField] private Transform _player01;
    [SerializeField] private Transform _player02;

    [SerializeField] private LayerMask _hitLayerMask;
    private int _pickupLayerMask;
    private int _movableLayerMask;




    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_player01.position, _player02.position - _player01.position, out hit, float.MaxValue, _hitLayerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == 7) Destroy(hit.collider.gameObject);

            if (hit.collider.gameObject.layer == 8)
            {
                hit.collider.gameObject.transform.position = (_player01.position - _player02.position) / 2 + _player02.position;
            }

        }

        
    }
}
