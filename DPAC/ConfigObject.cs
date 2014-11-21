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
    using System.IO;
    using System.Reflection;

    using UnityEngine;

    #endregion

    public class ConfigObject
    {
        #region Fields

        private string filePath;

        #endregion

        #region Constructors

        public ConfigObject() { }

        public ConfigObject(string filePath)
        {
            this.FilePath = filePath;
        }

        #endregion

        #region Properties

        public bool FileExists
        {
            get { return File.Exists(this.FilePath); }
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, value)); }
        }

        #endregion

        #region Loading

        public bool Load()
        {
            try
            {
                if (this.FileExists)
                {
                    ConfigNode.LoadObjectFromConfig(this, ConfigNode.Load(this.FilePath).GetNode(this.GetType().Name));
                    return true;
                }
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex);
            }

            return false;
        }

        #endregion

        #region Saving

        public bool Save()
        {
            try
            {
                new ConfigNode(this.GetType().Name).AddNode(ConfigNode.CreateConfigFromObject(this, new ConfigNode(this.GetType().Name))).Save(this.filePath);
                return true;
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex);
            }
            return false;
        }

        #endregion
    }
}