using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void GotCaught(string enemy, Vector3 spawn);
    public static event GotCaught gotCaught;
    public delegate void EnteredBuilding(string building, Vector3 spawn);
    public static event EnteredBuilding enteredBuilding;

    void PlayerGotCaughtPlayComic(string enemy) {
        if(gotCaught != null) {
            gotCaught(enemy, gameObject.transform.position);
        }
    }

    void PlayerEnteredBuildingPlayComic(string building, Vector3 spawn) {
        if (enteredBuilding != null) {
            enteredBuilding(building, spawn);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "LOS") {
            PlayerGotCaughtPlayComic(target.transform.parent.name);
            Debug.Log(target.transform.parent.name + "miltä näyttää");
        }
    }

    private void OnTriggerEnter(Collider target) {
        if(target.tag == "LOS") {
            PlayerGotCaughtPlayComic(target.transform.root.name);
            Debug.Log(target.transform.root.name + "miltä näyttää");
        }
        if(target.tag == "Enemy") {
            PlayerGotCaughtPlayComic(target.name);
        }
        if(target.tag == "Entrance") {
            PlayerEnteredBuildingPlayComic(target.name, target.transform.position);
        }
    }
}
