using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class WinLose : MonoBehaviour
{
    public PlayableDirector winCutsceneDirector;
    public PlayableDirector loseCutsceneDirector;
    public AudioSource bgMusic;
    public GameObject enemyParent;

    public int numberOfEnemies;
    public int numberOfCoffins;

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
        if (numberOfCoffins == 1)
        {
            // PLAYER LOSES
            enemyParent.SetActive(false);
            bgMusic.Stop();
            StartCoroutine(playEndingCutscene(loseCutsceneDirector)); 
            StartCoroutine(restartTheGame(((float)loseCutsceneDirector.duration)));
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
            enemyParent.SetActive(false);
            bgMusic.Stop();
            StartCoroutine(playEndingCutscene(winCutsceneDirector));
            StartCoroutine(restartTheGame(((float)winCutsceneDirector.duration)));
        }
    }

    IEnumerator playEndingCutscene(PlayableDirector playableDirector)
    {
        yield return new WaitForSeconds(2);
        playableDirector.Play();
    }

    IEnumerator restartTheGame(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("SampleScene");
    }
}
