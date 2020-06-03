using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButtonController : MonoBehaviour
{
    [SerializeField] UIAction UIAction;
    
    public void Toggle() {
        if (UIAction.IsMenuShown)
        {
            UIAction.MenuHide();
        }
        else {
            UIAction.MenuShow();
        }
    }
}
