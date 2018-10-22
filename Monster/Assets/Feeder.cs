using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour {
    public List<GameObject> prefabs;
    private GameObject last_prefab;
    public GameObject drop_loc;
    
    private float delta;

	// Use this for initialization
	void Start () {
        delta = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!last_prefab && ((Time.fixedTime - delta) > 1.5))
            BuildFood();
	}
    

    private void OnMouseUp()
    {
        if (last_prefab) Destroy(last_prefab);
        else delta = Time.fixedTime;
    }

    private void BuildFood()
    {
        delta = Time.fixedTime;

        last_prefab = Instantiate(prefabs[Random.Range(0, prefabs.Count)], drop_loc.transform);
        last_prefab.AddComponent<Rigidbody>();
        last_prefab.AddComponent<BoxCollider>();
        if (!last_prefab.GetComponent<Food>())
            last_prefab.AddComponent<Food>(); // generic food
    }
}
