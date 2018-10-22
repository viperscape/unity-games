using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject kind;
    public float spawn_time = 10; // time in seconds
    private float time;

    public bool delay = true; // wait one interval for initial spawn?

    public int max_spawn = 2;
    private int n_spawned;

	// Use this for initialization
	void Start () {
        time = Time.fixedTime;
        if (!delay) StartSpawn();
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn_time < Time.fixedTime - time)
        {
            time = Time.fixedTime;
            StartSpawn();
        }
	}

    void StartSpawn ()
    {
        if (n_spawned < max_spawn)
        {
            n_spawned += 1;
            GameObject g = Instantiate(kind, transform);
            
            g.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }
}
