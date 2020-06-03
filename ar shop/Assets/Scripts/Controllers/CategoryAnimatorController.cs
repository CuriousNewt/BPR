using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryAnimatorController : MonoBehaviour
{
    [SerializeField] UIAction UIAction;

    private void Awake()
    {
        UIAction.onMenuShow += ShowCategories;
        UIAction.onMenuHide += HideCategories;
    }

    void ShowCategories()
    {
        GetComponent<Animator>().SetTrigger("show");
    }

    void HideCategories()
    {
        GetComponent<Animator>().SetTrigger("hide");
    }

    private void OnDestroy()
    {
        UIAction.onMenuShow -= ShowCategories;
        UIAction.onMenuHide -= HideCategories;
    }
}
