using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSelect : MonoBehaviour {
    public enum MonsterKind { None, Bat, Rabbit, Slime };
    public MonsterKind kind;
    public GameObject next_area;
    

    private void OnMouseUp()
    {
        if (kind == MonsterKind.None) return;
        if (Globals.MonsterKind != MonsterKind.None) return;

        Globals.MonsterKind = kind;
        next_area.GetComponent<MonsterTransport>().Transport();
        //GameObject main = GameObject.Find("Monster Select/Camera");
        //main.GetComponent<Camera>().enabled = false;
        //main.GetComponent<AudioListener>().enabled = false;
    }
}
