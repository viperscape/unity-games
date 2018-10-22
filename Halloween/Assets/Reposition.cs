using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour {
    private Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetPosition()
    {
        transform.position = position;
    }
}
