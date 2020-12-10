using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicReader : MonoBehaviour
{
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private GameObject[] pages;

    private int imagesInPage;
    private int lastPageImageNumber = 0;
    private int currentPage = 0;
    private int lastTotalImageNumber = 0;

    //Will the game react to button press?
    private bool listening = true;

    private void Start() {
        imagesInPage = GetImagesInPage();
        Debug.Log(imagesInPage + "IMAGES IN PAGE");
        RevealNext();
        bool test = lastPageImageNumber < imagesInPage;
        /* Debug.Log( lastPageImageNumber + "number");
        Debug.Log(test + " bool"); */
    }

    private void Update() {
        if (listening == true && Input.GetKeyDown("space")) {
            if (lastPageImageNumber < imagesInPage) {
                    RevealNext();
            } else {
                if (lastPageImageNumber == imagesInPage) {
                    if (currentPage + 1 < pages.Length) { 
                        HidePage();
                        lastPageImageNumber = 0;
                        currentPage++;
                        imagesInPage = GetImagesInPage();
                    }
                    else {
                        ReturnToGameplay();
                    }
                }
            }
        }
    }
    //Joku PlayAnim funktio, joka hakee imagen animaattorin ja playaa "reveal" -animaation.
    //increments the the lastImageNumber and show the next picture
    private void RevealNext() {
        listening = false;
        images[lastTotalImageNumber++].SetActive(true);
        lastPageImageNumber++;
        listening = true;
        Debug.Log(lastPageImageNumber);
    }

    private void HidePage() {
        pages[currentPage].SetActive(false);
    }

    private int GetImagesInPage() {
        return pages[currentPage].transform.childCount;
    }

    private void ReturnToGameplay() {
        SceneFader.instance.LoadScene("Gameplay");
    }
}
