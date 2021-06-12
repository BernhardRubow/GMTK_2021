using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_ButterflySpawner_BR_scr : MonoBehaviour
{
    [SerializeField] private GameObject _butterflyPrefab;
    [SerializeField] private float _coolDownTime = 5f;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _coolDownTime)
        {
            _timer -= _coolDownTime;
            SpawnButterfly();
        }
        Debug.Log(_timer);
    }

    private void SpawnButterfly()
    {
        var butterfly = Instantiate(_butterflyPrefab, transform.position, Quaternion.identity);
        var controller = butterfly.GetComponent<Controller_FlockingMovement_BR_scr>();
        controller.MaxDistance = Random.Range(25f, 45f);
        controller.MoveForce = Random.Range(8f, 12f);
        controller.WanderFactor = Random.Range(0.3f, 0.6f);
        controller.StayFactor = Random.Range(0.2f, 0.3f);
    }
}
