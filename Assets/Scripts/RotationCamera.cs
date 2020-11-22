using System.Collections;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    public Camera mainCamera;


    private Coroutine rotator;
    private Vector3 rotatorPosition;
    private Quaternion rotatorRotation;

    private void Awake()
    {
        rotatorPosition = gameObject.transform.position;
        rotatorRotation = gameObject.transform.rotation;
    }

    private void Start()
    {
        //StartCoroutine(CameraRotator());
    }

    //=================Coroutines=============================
    
    IEnumerator CameraRotator()
    {
        //mainCamera.transform.parent = transform;
        while (true)
        {
            gameObject.transform.Rotate(new Vector3(0f, 1f, 0f));
            yield return new WaitForFixedUpdate();
        }
    }
    //=================Coroutines=============================
}
