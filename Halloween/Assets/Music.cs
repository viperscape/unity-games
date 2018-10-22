using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    public List<AudioClip> music;
    public float interval = 120.0f; // max interval between songs, in seconds

    private int current = 0;
    private float t;

	// Use this for initialization
	void Start () {
        PlayMusic();
	}
	
	// Update is called once per frame
	void Update () {
        float max = interval - music[current].length;
        if (interval < music[current].length) interval = music[current].length;

        if (Time.fixedTime - t > max)
        {
            t = Time.fixedTime;
            PlayMusic();
        }
	}

    private void PlayMusic()
    {
        current = (int)Random.Range(0f, (float)music.Count);

        AudioSource a = GetComponentInParent<AudioSource>();
        a.clip = music[current];
        a.Play();
    }
}
