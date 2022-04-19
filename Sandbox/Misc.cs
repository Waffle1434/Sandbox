using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Sandbox.Usermap;
using Sandbox.Data;
using System.Xml.Serialization;
using System.Xml;

namespace Sandbox
{
    /// <summary>
    /// Random functions that dont fit into any other class
    /// </summary>
    public static class Misc
    {
        /// <summary>
        /// Defines map ids for each map
        /// </summary>
        public enum MapID : int
        {
            zanzibar = 30,
            s3d_turf = 31,
            construct = 300,
            deadlock = 310,
            guardian = 320,
            isolation = 330,
            riverworld = 340,
            salvation = 350,
            snowbound = 360,
            chill = 380,
            cyberdyne = 390,
            shrine = 400,
            bunkerworld = 410,
            docks = 440,
            sidewinder = 470,
            warehouse = 480,
            descent = 490,
            spacecamp = 500,
            lockout = 520,
            armory = 580,
            ghosttown = 590,
            chillout = 600,
            s3d_edge = 703,
            s3d_waterfall = 706,
            midship = 720,
            sandbox = 730,
            fortress = 740,
        }
        /// <summary>
        /// Uses the map id to retrieve its plugin name.
        /// </summary>
        /// <param name="mapId">Id of map</param>
        /// <returns>Map Plugin Name</returns>
        public static string GetPluginName(int mapId)
        {
            switch (mapId)
            {
                case 30: return Application.StartupPath + "\\Plugins\\zanzibar.xml";
                case 31: return Application.StartupPath + "\\Plugins\\s3d_turf.xml";
                case 300: return Application.StartupPath + "\\Plugins\\construct.xml";
                case 310: return Application.StartupPath + "\\Plugins\\deadlock.xml";
                case 320: return Application.StartupPath + "\\Plugins\\guardian.xml";
                case 330: return Application.StartupPath + "\\Plugins\\isolation.xml";
                case 340: return Application.StartupPath + "\\Plugins\\riverworld.xml";
                case 350: return Application.StartupPath + "\\Plugins\\salvation.xml";
                case 360: return Application.StartupPath + "\\Plugins\\snowbound.xml";
                case 380: return Application.StartupPath + "\\Plugins\\chill.xml";
                case 390: return Application.StartupPath + "\\Plugins\\cyberdyne.xml";
                case 400: return Application.StartupPath + "\\Plugins\\shrine.xml";
                case 410: return Application.StartupPath + "\\Plugins\\bunkerworld.xml";
                case 440: return Application.StartupPath + "\\Plugins\\docks.xml";
                case 470: return Application.StartupPath + "\\Plugins\\sidewinder.xml";
                case 480: return Application.StartupPath + "\\Plugins\\warehouse.xml";
                case 490: return Application.StartupPath + "\\Plugins\\descent.xml";
                case 500: return Application.StartupPath + "\\Plugins\\spacecamp.xml";
                case 520: return Application.StartupPath + "\\Plugins\\lockout.xml";
                case 580: return Application.StartupPath + "\\Plugins\\armory.xml";
                case 590: return Application.StartupPath + "\\Plugins\\ghosttown.xml";
                case 600: return Application.StartupPath + "\\Plugins\\chillout.xml";
                case 703: return Application.StartupPath + "\\Plugins\\s3d_edge.xml";
                case 706: return Application.StartupPath + "\\Plugins\\s3d_waterfall.xml";
                case 720: return Application.StartupPath + "\\Plugins\\midship.xml";
                case 730: return Application.StartupPath + "\\Plugins\\sandbox.xml";
                case 740: return Application.StartupPath + "\\Plugins\\fortress.xml";
            }

            return null;
        }
        /// <summary>
        /// Retrieve a bitmap for a tag from the images folder
        ///  using the tags id
        /// </summary>
        /// <param name="id">Id of tah</param>
        /// <returns>Bitmap Image</returns>
        public static Bitmap GetImagesFromID(int id)
        {
            //Make sure ID is not null
            if (id != -1)
            {
                //Make the proper path string
                string path = Application.StartupPath + "\\Images\\" +
                    GlobalVariables.Plugin.GetTagNameFromID(id).Replace('\\', '_') + ".png";
                //Check if a file exist at that location
                if (File.Exists(path))
                    //If file exist return image
                    return new Bitmap(path);

            }
            //If Id was null or file didnt exist
            // return default bitmap.
            return new Bitmap(Application.StartupPath + "\\Images\\NoImage.png");
        }
    }
}
