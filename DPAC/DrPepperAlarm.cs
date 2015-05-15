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
    using System.Collections;
    using UnityEngine;
    using Random = System.Random;

    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class DrPepperAlarm : MonoBehaviour
    {
        private bool hasCentred;
        private float nextShowTime;
        private Rect screenRect = new Rect(Screen.width, Screen.height, 0.0f, 0.0f);
        private bool visible;

        public static DrPepperAlarm Instance { get; private set; }

        protected void Awake()
        {
            if (Instance || !Config.Enabled)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this);

            nextShowTime = Time.time + Config.FirstShowTime;
        }

        protected void OnDestroy()
        {
            Config.Instance.Save();
        }

        protected void OnGUI()
        {
            if (!visible)
            {
                return;
            }

            screenRect = GUILayout.Window(GetInstanceID(), screenRect, Window, string.Empty, GUIStyle.none);
            if (!hasCentred && screenRect.width > 0.0f && screenRect.height > 0.0f)
            {
                screenRect.center = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                hasCentred = true;
            }
        }

        protected void Update()
        {
            if (Time.time >= nextShowTime)
            {
                nextShowTime = Time.time + new Random().Next(Config.MinShowTime, Config.MaxShowTime);
                StartCoroutine(Showing(Config.Flashes));
            }
        }

        private IEnumerator Showing(int flashes)
        {
            for (int i = 0; i < flashes; i++)
            {
                if (i > 0)
                {
                    yield return new WaitForSeconds(Config.FlashDuration);
                }

                visible = true;
                yield return new WaitForSeconds(Config.ShowDuration);
                visible = false;
            }
        }

        private void Window(int windowId)
        {
            GUILayout.Label(Config.Heading, StyleLibrary.DpHeading);
            GUILayout.Box(StyleLibrary.DpTexture, StyleLibrary.DpBox);
        }
    }
}