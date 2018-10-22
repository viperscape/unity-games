using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {
    public GameObject prefab;
    private GameObject clone;
    public GameObject cloud_empty;

    public float wait;
    public float duration;
    private float last_time;

	// Use this for initialization
	void Start () {
        last_time = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
        if ((clone) && (Time.fixedTime - last_time > duration))
        {
            Destroy(clone);
            cloud_empty.GetComponent<AudioSource>().Stop();
        }

    }

    private void OnMouseUp()
    {
        if (Time.fixedTime - last_time < wait) return;
        if (clone) return;

        clone = Instantiate(prefab, cloud_empty.transform);
        last_time = Time.fixedTime;

        cloud_empty.GetComponent<AudioSource>().Play();
    }

    public bool isRaining()
    {
        return (clone != null);
    }
}
