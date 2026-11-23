using System;

namespace Launcher.Core
{
    internal static class SourceIcon
    {
        // Older TVs ship PNGs; newer monitor firmware supplies VD_ICONS SVGs.
        public static string Resolve(int sourceType, Func<string, bool> exists)
        {
            string suffix = sourceType >= 13 && sourceType <= 16 ? "hdmi" + (sourceType - 12)
                : sourceType == 33 ? "dpport" : "tv";
            const string root = "/usr/apps/com.samsung.tv.theme-resource/shared/res/";
            string png = root + "org.tizen.menu/Settings_Popup/device_icon/r_icon_device_s_" + suffix + ".png";
            if (exists(png)) return png;
            string svg = root + "VD_ICONS/i_icon_device_m_" + suffix + ".svg";
            return exists(svg) ? svg : null;
        }
    }
}
