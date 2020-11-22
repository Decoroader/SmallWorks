using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    void OnTriggerEnter(Collider ev)
    {
        print("On the " + ev.gameObject.name + " entered.");
    }
    void OnTriggerExit(Collider ev)
    {
        print(ev.gameObject.name + " exit");
    }
    //void OnTriggerStay(Collider ev)
    //{
    //    print("     in contact OnTriggerStay");
    //}
}
