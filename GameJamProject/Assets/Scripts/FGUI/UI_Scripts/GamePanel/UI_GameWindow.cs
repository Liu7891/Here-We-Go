/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GamePanel
{
    public partial class UI_GameWindow : GComponent
    {
        public GButton m_backBtn;
        public const string URL = "ui://jf73608bazlf6";

        public static UI_GameWindow CreateInstance()
        {
            return (UI_GameWindow)UIPackage.CreateObject("GamePanel", "GameWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_backBtn = (GButton)GetChildAt(1);
        }
    }
}