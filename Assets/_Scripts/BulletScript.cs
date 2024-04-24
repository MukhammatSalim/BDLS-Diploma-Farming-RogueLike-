using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletLifeTime;
    
    // Start is called before the first frame update
    private void Awake() {
        StartCoroutine(StartBulletLife());
    }

    // Update is called once per frame
    IEnumerator StartBulletLife(){
        yield return new WaitForSeconds(BulletLifeTime);
        Destroy(gameObject);
    }
}
