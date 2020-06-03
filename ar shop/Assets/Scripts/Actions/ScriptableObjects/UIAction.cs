using UnityEngine;
using System;

[CreateAssetMenu(fileName = "UIAction", menuName = "Actions/UIAction", order = 0)]
public class UIAction : ScriptableObject
{
    public Action onMenuHide;
    public Action onMenuShow;
    public Action onScrollViewShow;
    public bool IsMenuShown;


    public void MenuHide() {
        IsMenuShown = false;
        onMenuHide?.Invoke();
    }

    public void MenuShow() {
        IsMenuShown = true;
        onMenuShow?.Invoke();
    }

    public void ScrollViewShow() {
        onScrollViewShow?.Invoke();
    }
}
