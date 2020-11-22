using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public GameObject capsul;
    public GameObject sphere;
    public GameObject cube;
    public GameObject cylinder;
    [SerializeField]
    public Camera mainCamera;

    private Vector3 initPosition;


    void Start()
    {
        capsul.GetComponent<Renderer>().material.color =   Color.blue;
        initPosition = capsul.transform.position;
        sphere.GetComponent<Renderer>().material.color =   Color.green;
        cube.GetComponent<Renderer>().material.color =     Color.red;
        cylinder.GetComponent<Renderer>().material.color = Color.cyan;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //capsul.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            capsul.transform.position = new Vector3(initPosition.x, initPosition.y, initPosition.z + 0.05f);
            initPosition = capsul.transform.position;
        }

        if (Input.GetKey(KeyCode.B))
        {
            capsul.transform.position = new Vector3(initPosition.x, initPosition.y, initPosition.z - 0.05f);
            initPosition = capsul.transform.position;
        }
        if (Input.GetKey(KeyCode.U))
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 
                initPosition.y + 7f, mainCamera.transform.position.z);
        if (Input.GetKey(KeyCode.D))
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 
                mainCamera.transform.position.y - 7f, mainCamera.transform.position.z);
    }
}
