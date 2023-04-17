using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject minions;

    public GameObject player;

    [SerializeField]
    public float spawnInterval = 3.5f;

    float currentTime;
    public float startingTime = 10f;

    private bool isZero;

    [SerializeField] Text countdownText;


    void Start()
    {
        if(player != null)
        {
        StartCoroutine(spawnEnemy(spawnInterval, minions));
        }

        currentTime = startingTime;
        isZero = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 3)
        {
            isZero = true;
        }
        
        if (currentTime <= 0)
        {
            currentTime = 0;
            
        }
    }



    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(player != null && isZero == false)
        {
        yield return new WaitForSeconds(interval);
        GameObject leftEnemy = Instantiate(enemy, new Vector3(Random.Range(-8f, -5f), -1.9f, 0), Quaternion.identity);
        GameObject rightEnemy = Instantiate(enemy, new Vector3(Random.Range(8f, 5f), -1.9f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
