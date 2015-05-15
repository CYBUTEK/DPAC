// 
//     Copyright (C) 2015 CYBUTEK
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

namespace DPAC
{
    using System.Globalization;
    using UnityEngine;

    public class ConfigWindow : MonoBehaviour
    {
        private bool centred;
        private Rect screenRect = new Rect(0.0f, 0.0f, 300.0f, 0.0f);

        public void OnGUI()
        {
            screenRect = GUILayout.Window(GetInstanceID(), screenRect, OnWindow, "DPAC Configuration", HighLogic.Skin.window);
        }

        public void OnWindow(int windowId)
        {
            Config.Enabled = GUILayout.Toggle(Config.Enabled, "Enabled", StyleLibrary.ConfigToggle);

            GUILayout.Space(8.0f);

            GUILayout.Label("Heading", StyleLibrary.ConfigLabel);
            Config.Heading = GUILayout.TextField(Config.Heading, StyleLibrary.ConfigText);

            GUILayout.Space(8.0f);

            int firstShowTime;
            GUILayout.Label("First Show Time", StyleLibrary.ConfigLabel);
            if (int.TryParse(GUILayout.TextField(Config.FirstShowTime.ToString(CultureInfo.InvariantCulture), StyleLibrary.ConfigText), out firstShowTime))
            {
                Config.FirstShowTime = firstShowTime;
            }

            GUILayout.Space(8.0f);

            int minShowTime;
            GUILayout.Label("Min Show Time", StyleLibrary.ConfigLabel);
            if (int.TryParse(GUILayout.TextField(Config.MinShowTime.ToString(CultureInfo.InvariantCulture), StyleLibrary.ConfigText), out minShowTime))
            {
                Config.MinShowTime = minShowTime;
            }

            GUILayout.Space(8.0f);

            int maxShowTime;
            GUILayout.Label("Max Show Time", StyleLibrary.ConfigLabel);
            if (int.TryParse(GUILayout.TextField(Config.MaxShowTime.ToString(CultureInfo.InvariantCulture), StyleLibrary.ConfigText), out maxShowTime))
            {
                Config.MaxShowTime = maxShowTime;
            }

            GUI.DragWindow();
        }
    }
}