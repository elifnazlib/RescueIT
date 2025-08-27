using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(Spawn());
    }
}
