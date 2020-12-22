using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    [SerializeField]
    private GameObject[] allObjects;
    //private GameObject ClubEntrance, BarEntrance, Barricade1, Barricade2;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private string[] comics;
    [SerializeField]
    private GameObject[] heartsOnUI;

    private void Awake() {
        MakeInstance();
    }

    private void OnEnable() {
        Player.gotCaught += PlayerGotCaught;
        Player.enteredBuilding += PlayerEnteredBuilding;
        SetTheTable();
    }

    private void OnDisable() {
        Player.gotCaught -= PlayerGotCaught;
        Player.enteredBuilding -= PlayerEnteredBuilding;
    }

    private void SetTheTable() {
        if (GameManager.instance.hearts <= 0) {
            GameOver();
        }
        ShowHearts();

        DestroyUnwantedObjectsAndEnableRest();
        SpawnPlayer();

        if (MusicController.instance.audioSource.clip.name != "Gameplay") MusicController.instance.PlayTrack("Gameplay");
    }

    private void DestroyUnwantedObjectsAndEnableRest() {
        for (int i = 0; i < allObjects.Length; i++) {
            if (GameManager.instance.phase == 1) {
                if (CheckIfDisabled(allObjects[i].name) == false && allObjects[i].name.Contains("1st")) {
                    allObjects[i].SetActive(true);
                } else {
                    allObjects[i].SetActive(false);
                }
            }
            if (GameManager.instance.phase == 2) {
                if (CheckIfDisabled(allObjects[i].name) == false && allObjects[i].name.Contains("2nd")) {
                    allObjects[i].SetActive(true);
                } else {
                    allObjects[i].SetActive(false);
                }
            }
        }
    }

    private void SpawnPlayer() {
        Vector3 temp = GameManager.instance.playerSpawnPoint;
        player.transform.position = temp;
    }

    private bool CheckIfDisabled (string objectToCheck) {
        if (GameManager.instance.disabledEnemies.Contains(objectToCheck)) {
            return true;
        }
        return false;
    }

    private void PlayerEnteredBuilding(string building, Vector3 spawn) {
        Player.gotCaught -= PlayerGotCaught;
        Player.enteredBuilding -= PlayerEnteredBuilding;
        GameManager.instance.phase++;
        GameManager.instance.playerSpawnPoint = spawn;
        string temp = FilterForComic(building);
        PlayComic(temp);
    }

    private void PlayerGotCaught(string enemy, Vector3 spawn) {
        Player.gotCaught -= PlayerGotCaught;
        Player.enteredBuilding -= PlayerEnteredBuilding;
        GameManager.instance.disabledEnemies.Add(enemy);Debug.Log(GameManager.instance.disabledEnemies + "  Disabled enemies");
        GameManager.instance.playerSpawnPoint = spawn;
        GameManager.instance.hearts--;
        
        string temp = FilterForComic(enemy);
        PlayComic(temp);
    }

    private string FilterForComic(string name) {
        for (int i = 0; i < comics.Length; i++) {
            if(name.Contains(comics[i])) {
                return comics[i];
            }
        }
        return null;
    }

    private void GameOver() {
        GameManager.instance.GameOver();
        SceneFader.instance.LoadScene("Gameplay");
    }

    private void ShowHearts() {
        for (int i = 0; i < GameManager.instance.hearts; i++) {
            heartsOnUI[i].SetActive(true);
        }
    }

    public void PlayComic(string comicName) {
        GameManager.instance.comicToLoad = comicName;
        SceneFader.instance.LoadScene("Comic");
    }

    public void MusicOnOff () {
         if (MusicController.instance.audioSource.isPlaying == true) {
            MusicController.instance.PlayMusic(false);
        } else {
            MusicController.instance.PlayMusic(true);
        }
    }

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }
}
