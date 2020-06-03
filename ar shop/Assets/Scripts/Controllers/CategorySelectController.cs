using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CategorySelectController : MonoBehaviour
{
    [SerializeField] UIAction UIAction;
    [SerializeField] string categoryName;
    [SerializeField] int categoryID;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = categoryName;
    }

    public void SelectCategory() {
        UIAction.ScrollViewShow();
    }
}
