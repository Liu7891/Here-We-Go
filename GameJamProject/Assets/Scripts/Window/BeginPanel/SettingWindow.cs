using BeginPanel;
using FairyGUI;
using FairyGUI.Utils;
using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindow : Window
{
    private string LangPath;

    protected override void OnInit()
    {
        base.OnInit();
        contentPane = UIManager.Instance.LoadComponent("BeginPanel", "SettingWindow");
        modal = true;
        contentPane.x = (GRoot.inst.width - contentPane.width) / 2;
        contentPane.y = (GRoot.inst.height - contentPane.height) / 2;
        UI_SettingWindow panel = contentPane as UI_SettingWindow;
        panel.MakeFullScreen();

        //音乐按钮处理逻辑
        panel.m_musicCb.onChanged.Add(() =>
        {
            //开关背景音乐
            BKMusic.Instance.ChangeOpen(panel.m_musicCb.selected);
        });

        //音乐拖动条处理逻辑
        panel.m_musicSlider.onChanged.Add(() =>
        {
            //改变音乐音量大小
            BKMusic.Instance.ChangeValue((float)panel.m_musicSlider.value);
        });


        //确认按钮处理逻辑
        UI_WindowTip tipPanel = panel.m_frame as UI_WindowTip;
        tipPanel.m_confirmBtn.onClick.Add(() =>
        {
                //销毁原有的UI和包
                UIManager.Instance.ClearWindow(true);
                UIManager.Instance.ShowWindow<BeginWindow>();
            //隐藏窗口
            UIManager.Instance.HideWindow<SettingWindow>();
        });
    }
}
