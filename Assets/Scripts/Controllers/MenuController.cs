using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame() {
      GameManager.instance.comicToLoad = "Intro";
      SceneFader.instance.LoadScene("Comic");
    }
}
