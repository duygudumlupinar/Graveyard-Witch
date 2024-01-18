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
        audioSource = GetComponent<AudioSource>();
    }

    public void CoffinFilled()
    {
        if (numberOfCoffins < 4)
        {
            numberOfCoffins++;
        }
        if (numberOfCoffins == 4)
        {
            // PLAYER LOSES
            // lose cutscene 
            //restartTheGame();
            print("Lost");
        }
    }

    public void EnemyDown()
    {
        //There must be at least four enemies to fill all the coffins.
        if (numberOfEnemies > 3)
        {
            numberOfEnemies--;
        }
        else
        {
            print("Won");
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
