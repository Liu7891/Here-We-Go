using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

public class TipWindow : Window
{
    protected override void OnInit()
    {
        base.OnInit();
        contentPane = UIManager.Instance.LoadComponent("Public", "TipWindow");
        contentPane.x = (GRoot.inst.width - contentPane.width) / 2;
        contentPane.y = (GRoot.inst.height - contentPane.height) / 2;
        UI_TipWindow panel = contentPane as UI_TipWindow;
        modal = true;
        panel.MakeFullScreen();
        // 窗口居中设置

        //确定按钮按下定义
        panel.m_frame.m_confirmBtn.onClick.Add(ConfirmClicked);
    }

    /// <summary>
    /// 更改窗口顶部标题内容和提示内容
    /// </summary>
    public void ChangeInfo(string titleInfo, string contentInfo)
    {
        (contentPane as UI_TipWindow).m_frame.m_title.text = titleInfo;
        (contentPane as UI_TipWindow).m_frame.m_textInfo.text = contentInfo;
    }

    //定义确定按钮逻辑为虚方法
    protected virtual void ConfirmClicked() { }
}
