using BeginPanel;
using FairyGUI;
using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class BeginWindow : Window
{
    protected override void OnInit()
    {
        base.OnInit();
        contentPane = UIManager.Instance.LoadComponent("BeginPanel", "BeginWindow");
        contentPane.MakeFullScreen();
        //获取组件拓展类对象
        UI_BeginWindow panel = contentPane as UI_BeginWindow;

        //start按钮按下定义
        panel.m_startBtn.onClick.Add(() =>
        {
            //隐藏开始界面
            UIManager.Instance.HideWindow <BeginWindow>();
            // 获取 UI 相机
            Camera uiCamera = StageCamera.main.gameObject.GetComponent<Camera>();

            // 1. 设置为 Overlay 类型（URP 专属）
            var uiCameraData = uiCamera.GetUniversalAdditionalCameraData();
            if (uiCameraData != null)
            {
                uiCameraData.renderType = CameraRenderType.Overlay;
            }
            Camera mainCamera = Camera.main;
            var mainCamData = mainCamera.GetUniversalAdditionalCameraData();

            if (mainCamData != null)
            {
                // 确保 UI 相机不重复添加
                if (!mainCamData.cameraStack.Contains(uiCamera))
                {
                    mainCamData.cameraStack.Add(uiCamera);
                }
            }
            //进入游戏界面
            UIManager.Instance.ShowWindow<GameWindow>();
            SceneManager.LoadScene(1,LoadSceneMode.Additive);
        });

        //setting按钮按下定义
        panel.m_settingBtn.onClick.Add(() =>
        {
            //打开设置弹窗
            UI_WindowTip panel = UIManager.Instance.ShowWindow<SettingWindow>().frame as UI_WindowTip;
            panel.m_title.text = "设置";
            //按下确认按钮，存储设置信息
        });

        //quit按钮按下定义
        panel.m_quitBtn.onClick.Add(() =>
        {
            //弹出确认是否退出游戏弹窗
            UIManager.Instance.ShowWindow<EndTipWindow>().ChangeInfo("TIP", "是否退出游戏");
        });
    }

}
