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

    private void Awake() {
        MakeInstance();
    }

    private void OnEnable() {
        Player.gotCaught += PlayerGotCaught;
        Player.enteredBuilding += PlayerEnteredBuilding;
        SetTheTable();
    }

    private void SetTheTable() {
        DestroyUnwantedObjectsAndEnableRest();
        SpawnPlayer();
    }

    private void DestroyUnwantedObjectsAndEnableRest() {
        for (int i = 0; i < allObjects.Length; i++) {
            if (GameManager.instance.phase == 1) {
                if (CheckIfDisabled(allObjects[i].name) == false && allObjects[i].name.Contains("1st")) {
                    allObjects[i].SetActive(true);
                } else {
                    Debug.Log(allObjects[i].name.Contains("1st") + "   no mitä sanoo   " + allObjects[i].name);
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
        /* temp.y += ECM.Examples.CameraFollow.instance.distanceToTarget;
        mainCamera.transform.position = temp; */
        /* mainCamera.transform.position = new Vector3(temp.x, temp.y + ECM.Examples.CameraFollow.instance.distanceToTarget, temp.z); */
    }

    private bool CheckIfDisabled (string objectToCheck) {
        if (GameManager.instance.disabledEnemies.Contains(objectToCheck)) {
            Debug.Log("true");
            return true;
        }
        Debug.Log("false");
        return false;
    }

    private void PlayerEnteredBuilding(string building, Vector3 spawn) {
        GameManager.instance.phase++;
        GameManager.instance.playerSpawnPoint = spawn;
        string temp = FilterForComic(building);
        PlayComic(temp);
    }

    private void PlayerGotCaught(string enemy, Vector3 spawn) {
        GameManager.instance.disabledEnemies.Add(enemy);
        GameManager.instance.playerSpawnPoint = spawn;
        Debug.Log(GameManager.instance.playerSpawnPoint.x);
        GameManager.instance.hearts--;
        Debug.Log(GameManager.instance.hearts);
        
        string temp = FilterForComic(enemy);
        //PlayComic(temp);
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

    private void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }
}
