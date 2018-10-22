using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasterController : MonoBehaviour {
    
    public GameObject lure;
    private Rigidbody lureb;
    private float cast_time;

    private GameObject cam_target;

	void Start () {
        lureb = lure.GetComponent<Rigidbody>();
        lureb.isKinematic = true;
    }
	

	void Update () {
        if (lureb.isKinematic)
        {
            lure.transform.position = transform.position;
            lure.transform.rotation = transform.rotation;

            if (Input.GetKeyUp(KeyCode.Space) && (transform.position.y > -1) && (Time.fixedTime - cast_time > 1.0f)) // not under water
            {
                lureb.isKinematic = false;
                lureb.velocity = transform.TransformDirection(0, 2, 10);

                CameraSpecs cams = lure.GetComponent<CameraSpecs>();
                cam_target = cams.Target(); // save last target
                cams.Setup(lure);

                cast_time = Time.fixedTime;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float up = 0.0f;
            if (gameObject.transform.position.y > lure.transform.position.y) up = 0.5f;

            lure.transform.LookAt(transform);
            lureb.velocity = lure.transform.TransformDirection(0, up, 7);
        }
        else if (Vector3.Distance(lure.transform.position, transform.position) < 2)
        {
            if (Time.fixedTime - cast_time > 1.0f)
            {
                lureb.isKinematic = true;
                cast_time = Time.fixedTime;

                CameraSpecs cams = lure.GetComponent<CameraSpecs>();
                cams.Setup(cam_target);
            }
        }
    }
}
