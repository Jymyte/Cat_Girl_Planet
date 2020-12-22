using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allComics;
    private GameObject comicToLoad;
    private string comicToLoadName;
    // Start is called before the first frame update
    void Start()
    {
        comicToLoadName = GameManager.instance.comicToLoad;
        for(int i = 0; i < allComics.Length; i++) {
            if (allComics[i].name == comicToLoadName) {
                comicToLoad = allComics[i];
                break;
            } else {
                if (allComics.Length - i == 1 ) {
                    Debug.Log("Comic was not found");
                }
            }
        }
        GameObject obj = Instantiate(comicToLoad, new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
        obj.transform.SetParent(GameObject.Find("Comic Canvas").transform, false);
    }
}
