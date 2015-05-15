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
    using System.Diagnostics;
    using UnityEngine;

    public class Config : ConfigObject
    {
        private static readonly Config instance = new Config();

        [Persistent]
        private bool enabled = true;

        [Persistent]
        private int firstShowTime = 20 * 60;

        [Persistent]
        private float flashDuration = 0.2f;

        [Persistent]
        private int flashes = 2;

        [Persistent]
        private string heading = "DRINK!!!";

        [Persistent]
        private int maxShowTime = 45 * 60;

        [Persistent]
        private int minShowTime = 20 * 60;

        [Persistent]
        private float showDuration = 0.5f;

        [Persistent]
        private string textureFile = "DPAC/Textures/DPCan";

        private Config() : base("DPAC.cfg")
        {
            Load();
            SetDebugValues();
            Save();
        }

        public static bool Enabled
        {
            get
            {
                return instance.enabled;
            }
            set
            {
                instance.enabled = value;

                if (value && !DrPepperAlarm.Instance)
                {
                    HighLogic.fetch.gameObject.AddComponent<DrPepperAlarm>();
                }
                else if (!value && DrPepperAlarm.Instance)
                {
                    Object.Destroy(DrPepperAlarm.Instance);
                }
            }
        }

        public static int FirstShowTime
        {
            get
            {
                return instance.firstShowTime;
            }
            set
            {
                instance.firstShowTime = value;
            }
        }

        public static float FlashDuration
        {
            get
            {
                return instance.flashDuration;
            }
            set
            {
                instance.flashDuration = value;
            }
        }

        public static int Flashes
        {
            get
            {
                return instance.flashes;
            }
            set
            {
                instance.flashes = value;
            }
        }

        public static string Heading
        {
            get
            {
                return instance.heading;
            }
            set
            {
                instance.heading = value;
            }
        }

        public static Config Instance
        {
            get
            {
                return instance;
            }
        }

        public static int MaxShowTime
        {
            get
            {
                return instance.maxShowTime;
            }
            set
            {
                instance.maxShowTime = value;
            }
        }

        public static int MinShowTime
        {
            get
            {
                return instance.minShowTime;
            }
            set
            {
                instance.minShowTime = value;
            }
        }

        public static float ShowDuration
        {
            get
            {
                return instance.showDuration;
            }
            set
            {
                instance.showDuration = value;
            }
        }

        public static string TextureFile
        {
            get
            {
                return instance.textureFile;
            }
            set
            {
                instance.textureFile = value;
            }
        }

        [Conditional("DEBUG")]
        private void SetDebugValues()
        {
            firstShowTime = 5;
            minShowTime = 5;
            maxShowTime = 10;
        }
    }
}