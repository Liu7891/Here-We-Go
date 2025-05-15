using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTipWindow : TipWindow
{
    protected override void ConfirmClicked()
    {
        //退出游戏
        Application.Quit();
    }
}
