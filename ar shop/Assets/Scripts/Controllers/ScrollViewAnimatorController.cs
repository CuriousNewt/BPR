using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewAnimatorController : MonoBehaviour
{
    [SerializeField] UIAction UIAction;

    private void Awake()
    {
        UIAction.onMenuHide += HideScrollView;
        UIAction.onScrollViewShow += ShowScrollView;
    }

    void ShowScrollView()
    {
        GetComponent<Animator>().SetTrigger("show");
    }

    void HideScrollView() {
        GetComponent<Animator>().SetTrigger("hide");
    }

    private void OnDestroy()
    {
        UIAction.onMenuHide -= HideScrollView;
        UIAction.onScrollViewShow -= ShowScrollView;
    }
}
