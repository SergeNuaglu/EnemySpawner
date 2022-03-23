using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _enamyTamplate;
    [SerializeField] private Vector3[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        bool isPlay = true;
        var waitForTwoSeconds = new WaitForSeconds(2f);

        for (int i = 0; isPlay; i++)
        {
            Instantiate(_enamyTamplate, _spawnPoints[i], Quaternion.identity);

            if (i == _spawnPoints.Length - 1)
            {
                i = 0;
            }

            yield return waitForTwoSeconds;
        }
    }
}
