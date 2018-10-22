using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : MonoBehaviour {
    public float mass = 1.0f;
    public float attraction = 1.0f;
    public float depth = -5.0f;

    private Rigidbody lureb;

	// Use this for initialization
	void Start () {
        lureb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!lureb.isKinematic)
        {

            if (transform.position.y < 0)
            {
                lureb.drag = 5;
                lureb.velocity += transform.TransformDirection(0, 0.07f, 0);

                print(lureb.transform.position.y);
                if (lureb.transform.position.y < depth)
                {
                    lureb.MovePosition(new Vector3(lureb.transform.position.x, depth, lureb.transform.position.z));
                }
            }
        }
        else
        {
            lureb.drag = 0;
        }
    }
}
