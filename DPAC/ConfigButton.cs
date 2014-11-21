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

    using UnityEngine;

    #endregion

    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class ConfigButton : MonoBehaviour
    {
        #region Fields

        private ApplicationLauncherButton button;
        private ConfigWindow window;

        #endregion

        public void OnDestroy()
        {
            if (this.button)
            {
                ApplicationLauncher.Instance.RemoveModApplication(this.button);
            }
            if (this.window)
            {
                Destroy(this.window);
            }
        }

        public void Start()
        {
            this.button = ApplicationLauncher.Instance.AddModApplication(this.OnTrue, this.OnFalse, null, null, null, null, ApplicationLauncher.AppScenes.ALWAYS, StyleLibrary.DpTexture);
        }

        #region Application Launcher

        public void OnFalse()
        {
            if (this.window != null)
            {
                Destroy(this.window);
            }
        }

        public void OnTrue()
        {
            if (this.window == null)
            {
                this.window = this.gameObject.AddComponent<ConfigWindow>();
            }
        }

        #endregion
    }
}