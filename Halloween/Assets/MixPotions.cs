using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.PyroParticles;

public class MixPotions : MonoBehaviour {
    public enum Potions { Mushroom, Pumpkin, Skeleton };
    public List<GameObject> prefabs; // prefab order must match Potions enum order (Unity cannot show KV in editor)
    public float wait = 3f;
    private float last_time = 0;
    
	// Use this for initialization
	void Start () {
        last_time = Time.fixedTime - wait; //enable immediate use
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MixPotion(Potions p)
    {
        if (Time.fixedTime - last_time < wait) return;

        Instantiate(prefabs[(int)p],transform);
        last_time = Time.fixedTime;
    }
}
