using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

public class BG_Inst : MonoBehaviour
{
    [SerializeField] int side_BigPlato;
    [SerializeField] Vector3 zeroPosition;
    [SerializeField] Quaternion zeroRotation;

    public GameObject plane_LU;
    public GameObject plane_RU;
    public GameObject plane_LD;
    public GameObject plane_RD;
    public GameObject plane_All;

    //public GameObject[] A_simplePlanes;

    private int planeSide;

    private void Awake()
    {
        side_BigPlato = 1000;
        zeroPosition = new Vector3(0f, 5f, 0f);
        planeSide = 10;
        //A_simplePlanes = new GameObject[(int)side_BigPlato / planeSide * (int)side_BigPlato / planeSide * 4];
    }

    void Start()
    {
        int itemsCount = PlanesItemCount();
        OnePlaneSet(FirstItemPosition(itemsCount), itemsCount);
    }

    private Vector3 FirstItemPosition(int items)
    {
        float baseOfPosition = (-(float)items / 2 + 0.5f) * planeSide;
        
        return new Vector3(baseOfPosition + zeroPosition.x, zeroPosition.y, baseOfPosition + zeroPosition.z);
    }

    private int PlanesItemCount()
    {
        if (side_BigPlato > 0)
            return (int)Mathf.Ceil((float)side_BigPlato / planeSide);
        else
            return 1;
    }

    private void OnePlaneSet(Vector3 firstPosition, int itemsC)
    {
        for (int cols = 0; cols < itemsC; cols++)
        {
            for (int str = 0; str < itemsC; str++)
            {
                Vector3 currentPosition = new Vector3(firstPosition.x + cols * planeSide,
                        firstPosition.y, firstPosition.z + str * planeSide);
                int mirr;
                if (str == 0 || str % 2 == 0)
                    mirr = 1;
                else
                    mirr = -1;
                InstOnePlane(currentPosition, mirr);
            }
        }
    }
    private void InstOnePlane(Vector3 planePosition, float mirroring)
    {
        GameObject currentPlane = Instantiate(plane_All, new Vector3(planePosition.x, planePosition.y, planePosition.z),
            Quaternion.identity) as GameObject;
        currentPlane.transform.localScale = new Vector3(1f, 1f, mirroring);
    }
    //_________________________________________________________________________________________

    private void CoordinateOneBlockSet(Vector3 firstPosition, int itemsC)
    {
        for (int cols = 0; cols < itemsC; cols++)
        {
            for (int str = 0; str < itemsC; str++)
            {
                Vector3 currentPosition = new Vector3(firstPosition.x + cols * planeSide,
                    firstPosition.y, firstPosition.z + str * planeSide);
                InstOneBlockPlane(itemsC, currentPosition);
            }
        }
    }

    
    private void InstOneBlockPlane(int itemsC, Vector3 startPosition)
    {
        int currentItemC = 0;
        while (itemsC > currentItemC)
        {
            GameObject LU = Instantiate(plane_LU,
                new Vector3(startPosition.x - 5f, startPosition.y, startPosition.z + 5f), Quaternion.identity);
            //A_simplePlanes[itemsC] = LU;
            GameObject LD = Instantiate(plane_LD,
                new Vector3(startPosition.x - 5f, startPosition.y, startPosition.z - 5f), Quaternion.identity);
            //A_simplePlanes[itemsC+1] = LD;
            GameObject RU = Instantiate(plane_RU,
                new Vector3(startPosition.x + 5f, startPosition.y, startPosition.z + 5f), Quaternion.Euler(0, -90, 0));
            //A_simplePlanes[itemsC+2] = RU;
            GameObject RD = Instantiate(plane_RD,
                new Vector3(startPosition.x + 5f, startPosition.y, startPosition.z - 5f), Quaternion.Euler(0, -90, 0));
            //A_simplePlanes[itemsC+3] = RD;
            currentItemC++;
        }
    }
}
