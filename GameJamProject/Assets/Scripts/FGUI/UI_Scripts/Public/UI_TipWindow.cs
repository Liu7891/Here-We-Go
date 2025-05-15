/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Public
{
    public partial class UI_TipWindow : GComponent
    {
        public UI_WindowTip m_frame;
        public const string URL = "ui://cbwoi1b0iu3m1y";

        public static UI_TipWindow CreateInstance()
        {
            return (UI_TipWindow)UIPackage.CreateObject("Public", "TipWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_frame = (UI_WindowTip)GetChildAt(0);
        }
    }
}