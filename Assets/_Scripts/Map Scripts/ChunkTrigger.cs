using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mpScript;
    public GameObject TargetMap;
    // Start is called before the first frame update
    void Start()
    {
        mpScript = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.CompareTag  ("Player")){
            mpScript.CurrentChunk = TargetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag  ("Player")){
            if (mpScript.CurrentChunk == TargetMap){
                mpScript.CurrentChunk = null;
            }
        }
    }
}
