using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;

public class ButtonMark : AbstractButton
{
    public override void OnButtonClick()
    {
        AdShower.ShowAd();
    }
}
