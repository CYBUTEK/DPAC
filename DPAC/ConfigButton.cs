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
    using UnityEngine;

    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class ConfigButton : MonoBehaviour
    {
        private ApplicationLauncherButton button;
        private ConfigWindow window;

        public void OnDestroy()
        {
            if (button)
            {
                ApplicationLauncher.Instance.RemoveModApplication(button);
            }
            if (window)
            {
                Destroy(window);
            }
        }

        public void OnFalse()
        {
            if (window != null)
            {
                Destroy(window);
            }
        }

        public void OnTrue()
        {
            if (window == null)
            {
                window = gameObject.AddComponent<ConfigWindow>();
            }
        }

        public void Start()
        {
            button = ApplicationLauncher.Instance.AddModApplication(OnTrue, OnFalse, null, null, null, null, ApplicationLauncher.AppScenes.ALWAYS, StyleLibrary.DpTexture);
        }
    }
}