using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Shooter _tamplate;
    [SerializeField] private Aiming _aim;

    private Shooter _ball;

    private void Start()
    {
        _ball = Instantiate(_tamplate, transform.position, Quaternion.identity);
        _ball.SetAim(_aim);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ball.AllowToShoot();
            _ball = Instantiate(_tamplate, transform.position, Quaternion.identity);
            _ball.SetAim(_aim);
        }
    }
}
