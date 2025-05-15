/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace BeginPanel
{
    public partial class UI_BeginWindow : GComponent
    {
        public GButton m_startBtn;
        public GButton m_settingBtn;
        public GButton m_quitBtn;
        public const string URL = "ui://c56cgkmjhi920";

        public static UI_BeginWindow CreateInstance()
        {
            return (UI_BeginWindow)UIPackage.CreateObject("BeginPanel", "BeginWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_startBtn = (GButton)GetChildAt(1);
            m_settingBtn = (GButton)GetChildAt(2);
            m_quitBtn = (GButton)GetChildAt(3);
        }
    }
}