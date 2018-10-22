using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private CameraSpecs cams;

    void Start()
    {
        transform.rotation = target.transform.rotation;
        transform.position = target.transform.position;
        transform.LookAt(target.transform);

        Setup(target);
    }

    public void Setup(GameObject g)
    {
        target = g;
        cams = target.GetComponent<CameraSpecs>();
    }

    void LateUpdate()
    {

        Vector3 velocity = Vector3.zero;
        Vector3 forward = target.transform.forward * cams.dist;
        Vector3 positiond = target.transform.position - forward;
        positiond.y += cams.height;

        transform.position = Vector3.SmoothDamp(transform.position, positiond, ref velocity, cams.damp);
        transform.rotation = target.transform.rotation;

        transform.LookAt(target.transform);
    }
}