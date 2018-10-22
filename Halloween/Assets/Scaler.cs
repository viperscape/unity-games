using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {
    public float min = 1;
    public float max = 5;
    private float scale_speed;
    private Vector3 scale;

    private Vector3 position;

    public GameObject regrower; // trigger to regrow

    // Use this for initialization
    void Start () {
        scale = transform.localScale;
        position = transform.position;

        if (regrower) RestartObject();
    }
	
	// Update is called once per frame
	void Update () {
        bool isscaling = isScaling();
        if (isscaling)
        {
            if ((regrower && regrower.GetComponent<RainController>().isRaining()) || (!regrower))
                transform.localScale = Vector3.MoveTowards(transform.localScale, scale, ((scale_speed * Time.deltaTime) / 100));
        }
        else if (!isscaling)
        {
            transform.localScale = scale;
        }
	}

    public bool isScaling ()
    {
        return (Vector3.Distance(scale, transform.localScale) > 0.01);
    }

    public void RestartObject()
    {
        scale_speed = Random.Range(min, max);
        transform.position = position;
        transform.localScale = Vector3.zero;
    }

    public void ResetObject()
    {
        transform.position = position;
    }
}
