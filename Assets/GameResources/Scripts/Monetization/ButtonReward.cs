using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;

public class ButtonReward : AbstractButton
{
    public override void OnButtonClick()
    {
        AdShower.ShowRewardAd();
    }
}
