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
    public bool _enabled = true;

    private void OnEnable()
    {
        EventManager.AddEventListener("OnRopeBroken", OnRopeBroken);
        EventManager.AddEventListener("OnRopeFixed", OnRopeFixed);
    }

    private void OnDisable()
    {
        EventManager.RemoveEventListener("OnRopeBroken", OnRopeBroken);
        EventManager.RemoveEventListener("OnRopeFixed", OnRopeFixed);
    }

    private void OnRopeFixed(object sender, object eventargs)
    {
        enabled = true;
    }

    private void OnRopeBroken(object sender, object eventargs)
    {
        enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_player01.position, _player02.position - _player01.position, out hit, (_player02.position - _player01.position).magnitude, _hitLayerMask) && _enabled == true)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == 7) // ist Butterfly
            {
                var scoreController = hit.collider.GetComponent<ScoreButterfly_DV_scr>();
                Destroy(hit.collider.gameObject);
                EventManager.Invoke("ScoreButterflyCollect", this, scoreController.Score);
                EventManager.Invoke("OnCollecting", this, null);
            } ;

            if (hit.collider.gameObject.layer == 8) // ist Movable
            {
                hit.collider.gameObject.transform.position = (_player01.position + _player02.position) / 2;
            }

            if (hit.collider.gameObject.layer == 11)
            {
                // Debug.Log("hit laver");
                var controller = hit.collider.GetComponent<Controller_Laver_DV_scr>();
                controller.InvokeEvent();
            }

        }

        
    }


}