using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turn;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
     {
        float s = speed;
        if (transform.position.y < 0) { s /= 2; }
        transform.Rotate(0, Input.GetAxis("Horizontal") * turn * Time.deltaTime, 0);
        Vector3 vel = transform.forward * Input.GetAxis("Vertical") * s;
        
        controller.SimpleMove(vel);
     }

}