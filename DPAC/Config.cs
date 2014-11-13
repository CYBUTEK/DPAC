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

#region Using Directives

using System;
using System.IO;
using System.Reflection;

#endregion

namespace DPAC
{
    public class Config
    {
        #region Fields

        private static readonly string filePath = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "cfg");
        private static readonly Config instance = new Config();

        private float firstShowTime = 45.0f * 60.0f;
        private float flashDuration = 0.2f;
        private int flashes = 2;
        private int maxShowTime = 45 * 60;
        private int minShowTime = 20 * 60;
        private float showDuration = 0.5f;

        #endregion

        #region Constructors

        static Config()
        {
            Load();
        }

        #endregion

        #region Properties

        public static float FirstShowTime
        {
            get { return instance.firstShowTime; }
            set { instance.firstShowTime = value; }
        }

        public static float FlashDuration
        {
            get { return instance.flashDuration; }
            set { instance.flashDuration = value; }
        }

        public static int Flashes
        {
            get { return instance.flashes; }
            set { instance.flashes = value; }
        }

        public static int MaxShowTime
        {
            get { return instance.maxShowTime; }
            set { instance.maxShowTime = value; }
        }

        public static int MinShowTime
        {
            get { return instance.minShowTime; }
            set { instance.minShowTime = value; }
        }

        public static float ShowDuration
        {
            get { return instance.showDuration; }
            set { instance.showDuration = value; }
        }

        #endregion

        #region Methods: public

        public static void Load()
        {
            var node = ConfigNode.Load(filePath);
            if (node == null)
            {
                return;
            }

            if (node.HasValue("showDuration"))
            {
                instance.showDuration = Single.Parse(node.GetValue("showDuration"));
            }
            if (node.HasValue("flashDuration"))
            {
                instance.flashDuration = Single.Parse(node.GetValue("flashDuration"));
            }
            if (node.HasValue("firstShowTime"))
            {
                instance.firstShowTime = Single.Parse(node.GetValue("firstShowTime"));
            }
            if (node.HasValue("minShowTime"))
            {
                instance.minShowTime = Int32.Parse(node.GetValue("minShowTime"));
            }
            if (node.HasValue("maxShowTime"))
            {
                instance.maxShowTime = Int32.Parse(node.GetValue("maxShowTime"));
            }
            if (node.HasValue("flashes"))
            {
                instance.flashes = Int32.Parse(node.GetValue("flashes"));
            }
        }

        public static void Save()
        {
            var node = new ConfigNode();

            node.AddValue("showDuration", instance.showDuration);
            node.AddValue("flashDuration", instance.flashDuration);
            node.AddValue("firstShowTime", instance.firstShowTime);
            node.AddValue("minShowTime", instance.minShowTime);
            node.AddValue("maxShowTime", instance.maxShowTime);
            node.AddValue("flashes", instance.flashes);

            node.Save(filePath);
        }

        #endregion
    }
}