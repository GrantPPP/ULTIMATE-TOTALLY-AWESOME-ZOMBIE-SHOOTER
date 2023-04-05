using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject minions;

    public GameObject player;

    [SerializeField]
    public float spawnInterval = 3.5f;


    void Start()
    {
        if(player != null)
        {
        StartCoroutine(spawnEnemy(spawnInterval, minions));
        }
       
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(player != null)
        {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, -5f), -1.9f, 0), Quaternion.identity);
        GameObject newerEnemy = Instantiate(enemy, new Vector3(Random.Range(8f, 5f), -1.9f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
