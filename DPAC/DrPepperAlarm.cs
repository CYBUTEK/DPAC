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

    using System.Collections;

    using UnityEngine;

    using Random = System.Random;

    #endregion

    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class DrPepperAlarm : MonoBehaviour
    {
        #region Fields

        private bool hasCentred;
        private float nextShowTime;
        private Rect screenRect = new Rect(Screen.width, Screen.height, 0.0f, 0.0f);
        private bool visible;

        #endregion

        #region Properties

        public static DrPepperAlarm Instance { get; private set; }

        #endregion

        #region Methods: protected

        protected void Awake()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            this.nextShowTime = Time.time + DrPepperConfig.FirstShowTime;
        }

        protected void OnDestroy()
        {
            DrPepperConfig.Instance.Save();
        }

        protected void OnGUI()
        {
            if (!this.visible)
            {
                return;
            }

            this.screenRect = GUILayout.Window(this.GetInstanceID(), this.screenRect, this.Window, string.Empty, GUIStyle.none);
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
                this.nextShowTime = Time.time + new Random().Next(DrPepperConfig.MinShowTime, DrPepperConfig.MaxShowTime);
                this.StartCoroutine(this.Showing(DrPepperConfig.Flashes));
            }
        }

        #endregion

        #region Methods: private

        private IEnumerator Showing(int flashes)
        {
            for (int i = 0; i < flashes; i++)
            {
                if (i > 0)
                {
                    yield return new WaitForSeconds(DrPepperConfig.FlashDuration);
                }

                this.visible = true;
                yield return new WaitForSeconds(DrPepperConfig.ShowDuration);
                this.visible = false;
            }
        }

        private void Window(int windowId)
        {
            GUILayout.Label(DrPepperConfig.Heading, StyleLibrary.Heading);
            GUILayout.Box(StyleLibrary.Texture, StyleLibrary.Box);
        }

        #endregion
    }
}