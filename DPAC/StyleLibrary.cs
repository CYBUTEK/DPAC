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

    using System;

    using UnityEngine;

    #endregion

    public static class StyleLibrary
    {
        #region Constructors

        static StyleLibrary()
        {
            SetStyles();
        }

        #endregion

        #region Properties

        public static GUIStyle Box { get; set; }

        public static GUIStyle Heading { get; set; }

        public static Texture Texture { get; set; }

        #endregion

        public static void SetStyles()
        {
            try
            {
                Heading = new GUIStyle
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

                Box = new GUIStyle
                {
                    fixedHeight = Screen.height * 0.75f,
                    alignment = TextAnchor.LowerCenter
                };

                Texture = GameDatabase.Instance.GetTexture(DrPepperConfig.TextureFile, false);
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex);
            }
        }
    }
}