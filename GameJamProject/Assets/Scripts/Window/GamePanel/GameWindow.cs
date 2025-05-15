using FairyGUI;
using GamePanel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameWindow : Window
{
    public static int nowScore = 0;

    private UI_GameWindow panel;

    protected override void OnInit()
    {
        base.OnInit();
        contentPane = UIManager.Instance.LoadComponent("GamePanel", "GameWindow");
        contentPane.MakeFullScreen();
        panel = contentPane as UI_GameWindow;

        //返回按钮逻辑(在PlayerObj类中有ESC同逻辑)
        panel.m_backBtn.onClick.Add(() =>
        {
            //暂停游戏时间流速
            Time.timeScale = 0;
            //显示提示界面
            UIManager.Instance.ShowWindow<QuitTipWindow>().ChangeInfo("TIP", "是否退出游戏");
        });
    }
}
