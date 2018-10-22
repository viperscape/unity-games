using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour {
    private Animator anim;
    private AudioSource aud;
    private Vector3 position;
    private Quaternion rotation;

    private bool playing = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        position = transform.position;
        rotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.IsInTransition(0))
        {
            transform.position = position;
            transform.rotation = rotation;
            aud.Stop();
            playing = false;
        }
	}

    private void OnMouseUp()
    {
        if (playing) return;

        if (Random.Range(0,2) < 1)
            anim.Play("PSY Gangnam Style");
        else
            anim.Play("PSY Daddy");

        aud.Play();
        playing = true;
    }
}
