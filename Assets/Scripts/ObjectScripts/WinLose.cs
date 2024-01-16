using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public int numberOfEnemies;
    public int numberOfCoffins;

    private AudioSource audioSource;

    void Start()
    {
        numberOfCoffins = 0;
    }

    public void CoffinFilled()
    {
        if (numberOfCoffins < 4)
        {
            numberOfCoffins++;
        }
        else if (numberOfCoffins == 4)
        {
            // PLAYER LOSES
            // lose cutscene 
            //restartTheGame();
        }
    }

    public void EnemyDown()
    {
        print("enemy down");
        if (numberOfEnemies > 0)
        {
            numberOfEnemies--;
        }
        else if (numberOfEnemies == 0)
        {
            // PLAYER WINS
            // win cutscene
            audioSource.Play();
            //restartTheGame();
        }
    }

    void restartTheGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
