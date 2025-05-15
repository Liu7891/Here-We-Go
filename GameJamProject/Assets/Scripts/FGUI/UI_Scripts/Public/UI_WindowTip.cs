/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Public
{
    public partial class UI_WindowTip : GComponent
    {
        public GRichTextField m_title;
        public GRichTextField m_textInfo;
        public GGraph m_contentArea;
        public GButton m_confirmBtn;
        public GButton m_closeButton;
        public const string URL = "ui://cbwoi1b0iu3m1x";

        public static UI_WindowTip CreateInstance()
        {
            return (UI_WindowTip)UIPackage.CreateObject("Public", "WindowTip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GRichTextField)GetChildAt(2);
            m_textInfo = (GRichTextField)GetChildAt(3);
            m_contentArea = (GGraph)GetChildAt(4);
            m_confirmBtn = (GButton)GetChildAt(5);
            m_closeButton = (GButton)GetChildAt(6);
        }
    }
}