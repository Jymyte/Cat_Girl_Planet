using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake() {
        MakeInstance();
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public void plaal() {
        GameManager.instance.comicToLoad = "Esimerkki";
        SceneFader.instance.LoadScene("Comic");
    }
}
