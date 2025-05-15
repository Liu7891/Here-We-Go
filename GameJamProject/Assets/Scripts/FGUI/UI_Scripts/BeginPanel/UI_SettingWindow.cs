/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace BeginPanel
{
    public partial class UI_SettingWindow : GComponent
    {
        public GComponent m_frame;
        public GSlider m_musicSlider;
        public GButton m_musicCb;
        public const string URL = "ui://c56cgkmjcxr94";

        public static UI_SettingWindow CreateInstance()
        {
            return (UI_SettingWindow)UIPackage.CreateObject("BeginPanel", "SettingWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_frame = (GComponent)GetChildAt(0);
            m_musicSlider = (GSlider)GetChildAt(1);
            m_musicCb = (GButton)GetChildAt(2);
        }
    }
}