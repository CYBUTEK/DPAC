// 
//     Copyright (C) 2014 CYBUTEK
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
    #region Using Directives

    using System.Globalization;

    using UnityEngine;

    #endregion

    public class ConfigWindow : MonoBehaviour
    {
        #region Fields

        private bool centred;
        private Rect screenRect = new Rect(Screen.width, Screen.height, 300.0f, 0.0f);

        #endregion

        public void OnGUI()
        {
            this.screenRect = GUILayout.Window(this.GetInstanceID(), this.screenRect, this.OnWindow, "DPAC Configuration", HighLogic.Skin.window);
            if (!this.centred && this.screenRect.width > 0.0f && this.screenRect.height > 0.0f)
            {
                this.centred = true;
                this.screenRect.center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            }
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