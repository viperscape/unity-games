using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour {
    public GameObject prefab;
    private GameObject clone;
    public GameObject blood_empty;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        if (clone)
        {
            Destroy(clone);
            GetComponent<AudioSource>().Stop();
            return;
        }

        clone = Instantiate(prefab, blood_empty.transform);
        GetComponent<AudioSource>().Play();
    }
}
