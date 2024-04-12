using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public SeedData seedData;
    private void OnMouseDrag() {
        transform.position = GetMousePos();
    }
    Vector3 GetMousePos(){
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
