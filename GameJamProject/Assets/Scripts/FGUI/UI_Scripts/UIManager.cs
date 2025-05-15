using FairyGUI;
using BeginPanel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using GamePanel;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance => instance;
    //用于存储已经显示的UI面板
    public Dictionary<string, GComponent> panelDic = new Dictionary<string, GComponent>();
    //用于存储已经显示的窗口
    public Dictionary<string, Window> windowDic = new Dictionary<string, Window>();
    private UIManager()
    {
        //此处进行全局设置
        //默认字体
        UIConfig.defaultFont = "Font/FZYTK";
        //默认TIPS
        UIConfig.tooltipsWin = "ui://Public/ToolTip";
        //默认音效
/*        UIPackage.AddPackage("UI/Public");
        UIConfig.buttonSound = (NAudioClip)UIPackage.GetItemAssetByURL("ui://Public/BottonSound");
        UIConfig.buttonSoundVolumeScale = 0.1f;//无效
        Debug.Log(UIConfig.buttonSoundVolumeScale);*/
        //默认垂直滚动条
        UIConfig.verticalScrollBar = "ui://Public/ScrollBar1";
        //适配相关的设置
        GRoot.inst.SetContentScaleFactor(1920, 1080, UIContentScaler.ScreenMatchMode.MatchHeight);
        //设置半透明模态
        UIConfig.modalLayerColor = new Color(0, 0, 0, 0.5f);
        //注册
        BeginPanelBinder.BindAll();
        PublicBinder.BindAll();
        GamePanelBinder.BindAll();
    }

    public T ShowPanel<T>(string packageName) where T : GComponent
    {
        Type panelType = typeof(T);
        string panelName = panelType.Name;
        //如果字典中有该面板的名字，则证明已经创建过了，直接返回即可
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].visible = true;
            return panelDic[panelName] as T;
        } 
        //加载包和依赖包
        UIPackage package = UIPackage.AddPackage("UI/" + packageName);
        foreach (var item in package.dependencies)
        {
            UIPackage.AddPackage("UI/" + item["name"]);
        }
        //创建组建面板
        GComponent panel = UIPackage.CreateObject(packageName, panelName).asCom;
        //把组件的尺寸设置的和逻辑分辨率一致
        panel.MakeFullScreen();
        GRoot.inst.AddChild(panel);
        //和父对象建立宽高关联
        panel.AddRelation(GRoot.inst, RelationType.Size);
        //DC自动优化开启
        panel.fairyBatching = true;
        //把当前显示的面板存起来，用于之后的隐藏
        panelDic.Add(panelName, panel);
        return panel as T;
    }

    public T ShowWindow<T>() where T : Window, new() 
    {
        Type WindowType = typeof(T);
        string WindowName = WindowType.Name;

        //判断字典中是否有面板
        if (windowDic.ContainsKey(WindowName))
        {
            windowDic[WindowName].Show();
            return windowDic[WindowName] as T;
        }
        //创建面板
        T win = new T();
        //将面板组件和容器进行宽高关联
        win.AddRelation(GRoot.inst, RelationType.Size);
        //记录进字典
        windowDic.Add(WindowName, win);
        win.Show();
        return win as T;
    }

    /// <typeparam name="T">类名</typeparam>
    /// <param name="isDispose">是否移除面板</param>
    public void HidePanel<T>(bool isDispose = false)
    {
        Type panelType = typeof(T);
        string panelName = panelType.Name;
        if (panelDic.ContainsKey(panelName))
        {
            if (!isDispose)
            {
                //使面板失活
                panelDic[panelName].visible = false;
            }
            else
            {
                //移除面板
                panelDic[panelName].Dispose();
                panelDic.Remove(panelName);
            }
        }
    }

    public void HideWindow<T>()
    {
        Type WindowType = typeof(T);
        string WindowName = WindowType.Name;
        if (windowDic.ContainsKey(WindowName))
        {
            windowDic[WindowName].Hide();
        }
    }

    public T GetPanel<T> () where T : GComponent
    {
        Type type = typeof(T);
        string panelName = type.Name;
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        return null;
    }

    public T GetWindow<T>() where T : Window
    {
        Type type = typeof(T);
        string windowName = type.Name;
        if (windowDic.ContainsKey(windowName))
        {
            return windowDic[windowName] as T;
        }
        return null;
    }

    public void ClearPanel(bool isGC = false)
    {
        foreach (var item in panelDic.Values)
        {
            item.Dispose();
        }
        panelDic.Clear();

        if (isGC)
        {
            UIPackage.RemoveAllPackages();
            GC.Collect();
        } 
    }
    public void ClearWindow(bool isGC = false)
    {
        foreach (var item in windowDic.Values)
        {
            item.Dispose();
        }
        windowDic.Clear();

        if (isGC)
        {
            UIPackage.RemoveAllPackages();
            GC.Collect();
        }
    }

    /// <summary>
    /// 加载组件
    /// </summary>
    /// <param name="packageName">包名</param>
    /// <param name="componentName">被加载的组件名</param>
    public GComponent LoadComponent(string packageName, string componentName)
    {
        UIPackage package = UIPackage.AddPackage("UI/"+ packageName);
        foreach (var item in package.dependencies)
        {
            UIPackage.AddPackage("UI/" + item["name"]);
        }
        //关联对应组件
        GComponent conponent = (GComponent)UIPackage.CreateObject(packageName, componentName);
        conponent.fairyBatching = true;
        return conponent;
    }
}
