using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject [] enemyPrefab;
    [SerializeField] Transform spawnPoint;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float randomNum = Random.Range(3f, 7f);
        int randomIndex = Random.Range(0, enemyPrefab.Length);

        yield return new WaitForSeconds(randomNum);
        
        Instantiate(enemyPrefab[randomIndex], spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(Spawn());
    }
}
