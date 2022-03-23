using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _tamplate;

    private bool _isSpawned;
    private Shooter _shooter;
    private GameObject _ball;

    private void Start()
    {
        _ball = Instantiate(_tamplate, transform.position, Quaternion.identity);
        _shooter = _ball.GetComponent<Shooter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shooter.AllowToShoot();
            _ball = Instantiate(_tamplate, transform.position, Quaternion.identity);
            _shooter = _ball.GetComponent<Shooter>();
        }
    }
}
