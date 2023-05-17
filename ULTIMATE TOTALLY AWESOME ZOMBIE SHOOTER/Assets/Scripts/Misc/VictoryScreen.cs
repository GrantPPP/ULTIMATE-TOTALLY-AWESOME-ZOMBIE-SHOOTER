using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{

    public GameObject gameOverMenu;

    
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    private void OnEnable()
    {
        EnemySpawner.OnPlayerVictory += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        EnemySpawner.OnPlayerVictory -= EnableGameOverMenu;
    }

}
