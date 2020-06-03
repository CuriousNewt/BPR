using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameObjectAction", menuName = "Actions/GameObjectAction", order = 0)]
public class GameObjectAction : ScriptableObject
{
    public GameObject[] selectableObjectArray;
    public GameObject SelectedGameObject;

    public Action<GameObject> onSelectedChange;
    public Action onObjectChange;

    public void SelectedObjectChange(int index)
    {
        SelectedGameObject = selectableObjectArray[index];
        onSelectedChange?.Invoke(SelectedGameObject);
        onObjectChange?.Invoke();
    }
}
