using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    public SeedData seedData;
    public bool IsSelected;


    public void ShowFieldData()
    {
        if (seedData == null)
        {
            Debug.Log("The field is empty, ready to get seed");
        }
        else
        {
            Debug.Log("The field contains " + seedData.SeedName);
        }
    }
    private void OnMouseDown()
    {
        if (IsSelected)
        {
            IsSelected = false;
            GetComponent<SpriteRenderer>().color = Color.white;
            GameManager.Instance.SelectedField = null;
        }
        else
        {
            IsSelected = true;
            GetComponent<SpriteRenderer>().color = Color.gray;
            GameManager.Instance.SelectedField = this;
        }

    }
}
