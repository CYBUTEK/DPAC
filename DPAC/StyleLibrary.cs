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
    using System;
    using UnityEngine;

    public static class StyleLibrary
    {
        static StyleLibrary()
        {
            SetStyles();
        }

        public static GUIStyle ConfigLabel { get; set; }

        public static GUIStyle ConfigText { get; set; }

        public static GUIStyle ConfigToggle { get; set; }

        public static GUIStyle DpBox { get; set; }

        public static GUIStyle DpHeading { get; set; }

        public static Texture DpTexture { get; set; }

        public static void SetStyles()
        {
            try
            {
                DpHeading = new GUIStyle
                {
                    normal =
                    {
                        textColor = Color.green
                    },
                    fontSize = 50,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.UpperCenter,
                    stretchWidth = true
                };

                DpBox = new GUIStyle
                {
                    fixedHeight = Screen.height * 0.75f,
                    alignment = TextAnchor.LowerCenter
                };

                DpTexture = GameDatabase.Instance.GetTexture(Config.TextureFile, false);

                ConfigLabel = new GUIStyle(HighLogic.Skin.label);

                ConfigText = new GUIStyle(HighLogic.Skin.textField);

                ConfigToggle = new GUIStyle(HighLogic.Skin.toggle);
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex);
            }
        }
    }
}