using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    private bool is_playing = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
        foreach (var cam in cameras)
        {
            if (is_playing) cam.GetComponent<AudioSource>().Stop();
            else cam.GetComponent<AudioSource>().Play();
        }

        if (is_playing) is_playing = false;
        else is_playing = true;
    }
}
