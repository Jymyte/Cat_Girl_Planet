using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField]
    private GameObject ClubEntrance, BarEntrance;

    [SerializeField]
    private string[] comics;

    private void Awake() {
        MakeInstance();
    }

    private void OnEnable() {
        Player.gotCaught += PlayerGotCaught;
        Player.enteredBuilding += PlayerEnteredBuilding;
    }

    private void PlayerEnteredBuilding(string building, Vector3 spawn) {
        GameManager.instance.playerSpawnPoint = spawn;
        string temp = FilterForComic(building);
        PlayComic(temp);
    }

    private void PlayerGotCaught(string enemy, Vector3 spawn) {
        GameManager.instance.playerSpawnPoint = spawn;
        Debug.Log(GameManager.instance.playerSpawnPoint.x);
        GameManager.instance.hearts--;
        Debug.Log(GameManager.instance.hearts);
        
        string temp = FilterForComic(enemy);
        //PlayComic(temp);
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    private string FilterForComic(string name) {
        for (int i = 0; i < comics.Length; i++) {
            if(name.Contains(comics[i])) {
                return comics[i];
            }
        }
        
        return null;
    }

    public void PlayComic(string comicName) {
        GameManager.instance.comicToLoad = comicName;
        SceneFader.instance.LoadScene("Comic");
    }
}
