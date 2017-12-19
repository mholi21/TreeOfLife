using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{

    public Transform mainTarget;
    public Camera mainCam;

    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        mainCam.orthographicSize = (Screen.height / 100f) / 2f;

        if (mainTarget)
        {
            transform.position = Vector3.Lerp(transform.position, mainTarget.position, 0.5f) + new Vector3(0, 0, -10);
        }
    }
}
