using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 


public class EnemySpawner : MonoBehaviour
{
    public static event Action OnPlayerVictory; 
    [SerializeField]
    public GameObject minions;

    public GameObject player;

    [SerializeField]
    public float spawnInterval = 3.5f;

    float currentTime;
    float startingTime = 0f;

    private bool isZero;

    float spawnTime; 

    public int amountOfEnemies = 60;

    int aliveEnemies; 

    bool isVictory; 

    GameObject boss;

    bool stop; 

    //private int numberOfEnemiesIS;

    [SerializeField] Text countdownText;

    [SerializeField] Text remainingEnemies; 

    [SerializeField] Text enemiesAlive; 

    void Start()
    {
        isZero = true;

        isVictory = false; 
        //if(player != null)
       // {
       // StartCoroutine(spawnEnemy(spawnInterval, minions));
      //  }

        currentTime = startingTime;

        boss = GameObject.FindWithTag("Boss"); 
        
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //int numberOfEnemiesIS = GameObject.FindGameObjectWithTag("Enemy"); 
        int aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length - 1; 
        currentTime += Time.deltaTime;
        if(player != null && isVictory == false)
        {
            countdownText.text = currentTime.ToString("0");
        }
        
        remainingEnemies.text = amountOfEnemies.ToString("0");
        enemiesAlive.text = aliveEnemies.ToString("0");
        spawnTime += Time.deltaTime;
        
        Debug.Log(spawnTime);
        if(amountOfEnemies < 0)
        {
            amountOfEnemies = 0;
        }

        if(GameObject.FindGameObjectsWithTag("Enemy").Length >= 6)
        {
            isZero = false;
            spawnTime = 0;
        }else{
            
            isZero = true; 
            if(spawnTime <= .1f && spawnTime > 0)
            {
                StartCoroutine(spawnEnemy(spawnInterval, minions));
                spawnTime += 1; 
            }
        }

        if(aliveEnemies == 0 && amountOfEnemies == 0 && currentTime >= 5 && stop == false)
        {
            Invoke("TeleportBoss", 5f);
            stop = true; 
           
        }

        if(boss == null)
        {
            isVictory = true; 
            OnPlayerVictory?.Invoke();
        }
        
        //if(currentTime <= 3)
        //{
           // isZero = true;
        //}
        
        //if (currentTime <= 0)
        //{
            //currentTime = 0; if(GameObject.FindGameObjectsWithTag("Enemy").Length < 8)
            
        //}
    }

    private void TeleportBoss()
    {
        boss.transform.position = new Vector2(6f, -1.935414f); 
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(player != null && isZero == true && amountOfEnemies >= 3)
        {
        yield return new WaitForSeconds(interval);
        GameObject leftEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-6.433831f, -5f), -1.935414f, 0), Quaternion.identity);
        GameObject rightEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(6.439991f, 5f), -1.935414f, 0), Quaternion.identity);
        GameObject upperLeftEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-6.433831f, -5f), -0.8963752f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
        amountOfEnemies -= 3; 
        }
        
    }
}
