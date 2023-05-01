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

    //private int numberOfEnemiesIS;

    [SerializeField] Text countdownText;


    void Start()
    {
        if(player != null)
        {
        StartCoroutine(spawnEnemy(spawnInterval, minions));
        }

        currentTime = startingTime;
        isZero = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int numberOfEnemiesIS = GameObject.FindGameObjectWithTag("Enemy"); 

        currentTime += Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(GameObject.FindGameObjectsWithTag("Enemy").Length >= 8)
        {
            isZero = false;
        }else if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 8)
        {
            isZero = true; 
            StartCoroutine(spawnEnemy(spawnInterval, minions));
        }

        //if(currentTime <= 3)
        //{
           // isZero = true;
        //}
        
        //if (currentTime <= 0)
        //{
            //currentTime = 0;
            
        //}
    }



    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(player != null && isZero == true)
        {
        yield return new WaitForSeconds(interval);
        GameObject leftEnemy = Instantiate(enemy, new Vector3(Random.Range(-6.433831f, -5f), -1.935414f, 0), Quaternion.identity);
        GameObject rightEnemy = Instantiate(enemy, new Vector3(Random.Range(6.439991f, 5f), -1.935414f, 0), Quaternion.identity);
        GameObject upperLeftEnemy = Instantiate(enemy, new Vector3(Random.Range(-6.433831f, -5f), -0.8963752f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
