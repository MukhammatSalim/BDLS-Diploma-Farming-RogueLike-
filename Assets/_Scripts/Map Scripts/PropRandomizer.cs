using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> PropsLocations;
    public List<GameObject> PropsPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    void SpawnProps(){
        foreach (GameObject location in PropsLocations){
            int RNG = Random.Range(0, PropsPrefabs.Count);
            GameObject prop = Instantiate(PropsPrefabs[RNG], location.transform.position, Quaternion.identity);
            prop.transform.parent = location.transform;
        }
    }
}
