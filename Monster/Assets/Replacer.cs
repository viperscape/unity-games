using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour {
    private float delta = 0;
    private Vector3 position;
    private Quaternion rotation;
    private string old_name;
    public float replace_time = 10f;

	// Use this for initialization
	void Start () {
        position = transform.position;
        rotation = transform.rotation;
        old_name = name;
    }
	
	// Update is called once per frame
	void Update () {
        if (delta > 0)
        {
            if ((Time.fixedTime - delta) > replace_time)
            {
                GameObject new_obj = Instantiate(gameObject, position, rotation);
                new_obj.name = old_name; // prevent renaming with "clone" name
                Destroy(gameObject);
                delta = 0;
            }
        }
        else // mark for replacement
        {
            if (Vector3.Distance(transform.position, position) > 0.1)
                delta = Time.fixedTime;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.fixedTime > 0) // wait after start of game
        {
            AudioSource aud = GetComponent<AudioSource>();
            aud.Play();
        }
    }
}
