﻿// 
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

#region Using Directives

using System;
using System.Collections;

using UnityEngine;

using Random = System.Random;

#endregion

namespace DPAC
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class DrPepperAlarm : MonoBehaviour
    {
        #region Fields

        private Texture2D canTexture;
        private GUIStyle canTextureStyle;
        private GUIStyle drinkLabelStyle;
        private bool hasCentred;
        private float nextShowTime;
        private Rect screenRect;
        private bool visible;
        private GUIStyle windowStyle;

        #endregion

        #region Methods: protected

        protected void Awake()
        {
            DontDestroyOnLoad(this);

            this.nextShowTime = Time.time + Config.FirstShowTime;

            this.windowStyle = new GUIStyle();

            this.drinkLabelStyle = new GUIStyle(HighLogic.Skin.label)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 50,
                alignment = TextAnchor.UpperCenter,
                stretchWidth = true
            };

            this.canTextureStyle = new GUIStyle
            {
                fixedHeight = Screen.height * 0.75f,
                fixedWidth = Screen.height * 0.75f * 0.54649947753396029258098223615465f
            };

            this.canTexture = GameDatabase.Instance.GetTexture("DPAC/Textures/DPCan", false);
        }

        protected void OnDestroy()
        {
            Config.Save();
        }

        protected void OnGUI()
        {
            if (!this.visible)
            {
                return;
            }

            this.screenRect = GUILayout.Window(this.GetInstanceID(), this.screenRect, this.Window, String.Empty, this.windowStyle);
            if (!this.hasCentred && this.screenRect.width > 0.0f && this.screenRect.height > 0.0f)
            {
                this.screenRect.center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                this.hasCentred = true;
            }
        }

        protected void Update()
        {
            if (Time.time >= this.nextShowTime)
            {
                this.nextShowTime = Time.time + new Random().Next(Config.MinShowTime, Config.MaxShowTime);
                this.StartCoroutine(this.Showing(Config.Flashes));
            }
        }

        #endregion

        #region Methods: private

        private IEnumerator Showing(int flashes)
        {
            for (var i = 0; i < flashes; i++)
            {
                if (i > 0)
                {
                    yield return new WaitForSeconds(Config.FlashDuration);
                }

                this.visible = true;
                yield return new WaitForSeconds(Config.ShowDuration);
                this.visible = false;
            }
        }

        private void Window(int windowId)
        {
            GUILayout.Label("DRINK!!!", this.drinkLabelStyle);
            GUILayout.Box(this.canTexture, this.canTextureStyle);
        }

        #endregion
    }
}