using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpecs : MonoBehaviour {
    public Camera cam;
    private CameraController camc;
    public float dist = 5f;
    public float damp = 0.08f;
    public float height = 1f;

    // Use this for initialization
    void Start()
    {
        if (!cam)
        {
            cam = FindObjectOfType<Camera>();
        }

        camc = cam.GetComponent<CameraController>();
    }

    public void Setup(GameObject g)
    {
        camc.Setup(g);
    }

    public GameObject Target ()
    {
        return camc.target;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
