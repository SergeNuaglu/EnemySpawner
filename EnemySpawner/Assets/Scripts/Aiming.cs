using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aiming : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float minXposition = -50f;
    private float maxXposition = 50f;
    private float minZposition = -50f;
    private float maxZposition = 50f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > minXposition)
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < maxXposition)
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && transform.position.z < maxZposition)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z > minZposition)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime * -1);
        }
    }
}
