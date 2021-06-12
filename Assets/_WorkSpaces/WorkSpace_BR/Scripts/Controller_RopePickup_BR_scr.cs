using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
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
            if (hit.collider.gameObject.layer == 7) // ist Butterfly
            {
                Destroy(hit.collider.gameObject);
                EventManager.Invoke("ScoreButterflyCollect", this, 200);
            } ;

            if (hit.collider.gameObject.layer == 8) // ist Movable
            {
                hit.collider.gameObject.transform.position = (_player01.position - _player02.position) / 2 + _player02.position;
            }

            if (hit.collider.gameObject.layer == 11)
            {
                Debug.Log("hit laver");
            }

        }

        
    }
}
