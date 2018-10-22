using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnMouseUp : MonoBehaviour {
    private AudioSource aud;
    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        aud.Play();
    }
}
