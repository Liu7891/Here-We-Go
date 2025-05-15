using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Begin : MonoBehaviour
{
    void Awake()
    {
        // 设置分辨率适配（这里按你的目标分辨率调整）
        GRoot.inst.SetContentScaleFactor(1136, 640, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);
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
        UIManager.Instance.ShowWindow<BeginWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
