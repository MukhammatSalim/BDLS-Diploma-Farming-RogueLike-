using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FieldScript SelectedField;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ShowFieldData()
    {
        if (SelectedField)
        {
            Debug.Log("Selected field is " + SelectedField.name);
            if (SelectedField.seedData == null) Debug.Log("Selected Field does not has any seeds");
            else Debug.Log("Selected Field seed: " + SelectedField.seedData.name);
        }
        else
        {
            Debug.Log("No Selected field");
        }
    }
    private void OnMouseDown()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            // whatever tag you are looking for on your game object
            if (hit.collider.tag == "FieldCell")
            {
                Debug.Log("---> Hit: ");
            }
            else
            {
                Debug.Log("Miss");
            }
        }
    }
}
