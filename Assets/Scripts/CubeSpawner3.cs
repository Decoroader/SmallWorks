using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner3 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectList; // Будет хранить все кубики
    public float scalingFactor = 0.95f;
    public int numCubes = 0; // Общее количество кубиков
    
    void Start()
    {
        gameObjectList = new List<GameObject>();
    }

    void Update()
    {
        numCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefabVar, Random.insideUnitSphere * 3, Quaternion.identity); // b
        
        gObj.name = "Cube " + numCubes;
        
        while (true)
        {
            float r = Random.value;
            float g = Random.value;
            float b = Random.value;
            if((r + g + b) > 1.5f)
            {
                Color randomColor = new Color(r, g, b); // d
                gObj.GetComponent<Renderer>().material.color = randomColor;
                break;
            }
        }
        
        gameObjectList.Add(gObj); // Добавить gObj в список кубиков
        GameObject destroyObj = null;
        foreach (GameObject goTemp in gameObjectList)
        {
            goTemp.transform.localScale = Vector3.one * goTemp.transform.localScale.x * scalingFactor;
            if (goTemp.transform.localScale.x <= 0.1f)
                destroyObj = goTemp;
        }
        gameObjectList.Remove(destroyObj);
        Destroy(destroyObj);
    }
}