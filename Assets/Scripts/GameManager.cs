using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string comicToLoad, currentScene;
    public int hearts = 3;
    public Vector3 playerSpawnPoint;

    private void Awake() {
        MakeSingleton();
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
