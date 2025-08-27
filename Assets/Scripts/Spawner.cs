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
        float randomNum = Random.Range(3f, 7f);
        yield return new WaitForSeconds(randomNum);
        
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(Spawn());
    }
}
