using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlacableObjectController : MonoBehaviour
{
    [SerializeField] GameObjectAction goAction;
    [SerializeField] int index;

    public void ChangePlacableObject() {
        goAction.SelectedObjectChange(index);
    }
}
