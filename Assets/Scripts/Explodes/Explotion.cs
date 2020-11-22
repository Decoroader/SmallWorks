
using UnityEngine;

public class Explotion : MonoBehaviour
{
    [SerializeField] private GameObject explPref_plus;
    [SerializeField] private GameObject explPref_minus;
    [SerializeField] private GameObject explPref_flash;

    private GameObject explode_change;
    private GameObject explode_subEff;
    private GameObject prefExplode;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
            prefExplode = explPref_plus;
        if (Input.GetKeyUp(KeyCode.R))
            prefExplode = explPref_minus;
        explode_change = Instantiate(prefExplode, new Vector3(0, 3f, -5f), Quaternion.identity) as GameObject;

        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.R))
            explode_subEff = Instantiate(explPref_flash, new Vector3(0, 3f, -5f), Quaternion.identity) as GameObject;
        Destroy(explode_change, 3f);
        Destroy(explode_subEff, 1f);
    }
}
