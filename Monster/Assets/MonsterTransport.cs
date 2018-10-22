using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTransport : MonoBehaviour {
    public GameObject next_area;

    void Start()
    {
        // disable all but main camera
        GameObject mycam = GameObject.Find(gameObject.name + "/Camera");
        if (mycam)
        {
            mycam.GetComponent<Camera>().enabled = false;
            mycam.GetComponent<AudioListener>().enabled = false;
        }

        // enable initial cam
        GameObject main = GameObject.Find("Monster Select/Camera");
        main.GetComponent<Camera>().enabled = true;
        main.GetComponent<AudioListener>().enabled = true;
        Globals.Cam = main.GetComponent<Camera>();
    }

    public void Transport()
    {
        GameObject monster = Globals.GetMonster();
        
        monster.transform.position = GetLocation(Globals.MonsterKind).transform.position;

        GameObject mycam = GameObject.Find(gameObject.name + "/Camera");
        if (mycam)
        {
            mycam.GetComponent<Camera>().enabled = true;
            mycam.GetComponent<AudioListener>().enabled = true;
        }

        // reset last cam
        Globals.Cam.enabled = false;
        Globals.Cam.GetComponent<AudioListener>().enabled = false;
        Globals.Cam = mycam.GetComponent<Camera>();
    }

    private void OnMouseUp()
    {
        if (next_area)
        {
            //Globals.Cam.enabled = false;


            next_area.GetComponent<MonsterTransport>().Transport();

            if (next_area.name == "Monster Select") Globals.MonsterKind = MonsterSelect.MonsterKind.None;
        }
    }

    public GameObject GetLocation(MonsterSelect.MonsterKind kind)
    {
        GameObject loc = null;

        if (kind == MonsterSelect.MonsterKind.Bat)
        {
            loc = GameObject.Find(gameObject.name + "/Bat Location");
        }
        else if (kind == MonsterSelect.MonsterKind.Slime)
        {
            loc = GameObject.Find(gameObject.name + "/Slime Location");
        }
        else if (kind == MonsterSelect.MonsterKind.Rabbit)
        {
            loc = GameObject.Find(gameObject.name + "/Rabbit Location");
        }

        if (!loc)
        {
            loc = GameObject.Find(gameObject.name + "/Monster Location");
        }

        return loc;
    }
}
