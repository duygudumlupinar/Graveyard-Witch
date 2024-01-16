using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroStory : MonoBehaviour
{
    public Image nextImage;

    public void NextPage()
    {
        gameObject.SetActive(false);
        nextImage.gameObject.SetActive(true);
    }
}
