using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitTipWindow : TipWindow
{
    protected override void ConfirmClicked()
    {
        //返回开始场景
        SceneManager.LoadScene(0);
        //隐藏提示和游戏界面
        UIManager.Instance.HideWindow<QuitTipWindow>();
        UIManager.Instance.HideWindow<GameWindow>();
    }

    protected override void OnHide()
    {
        base.OnHide();
        //恢复时间流速
        Time.timeScale = 1;
    }
}
