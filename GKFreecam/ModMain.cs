using Harmony;
using GKML;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using GKFreecam.Metadata;

namespace GKFreecam
{
    /* 
    spent about 2 days trying to work on this
    made by yours truly, nonparallel.
    */

    public class ModMain : Mod
    {
        // m,y dick

        public override void PostInit()
        {
            Console.WriteLine("nonparallel was here (yes, me. it was me all along!); GK Freecam has loaded.");

            if (!File.Exists(Globals.JSONLocation))
                File.WriteAllText(Globals.JSONLocation, JsonConvert.SerializeObject(new JSONConfig(), Formatting.Indented));

            Globals.Config = JsonConvert.DeserializeObject<JSONConfig>(File.ReadAllText(Globals.JSONLocation));
        }
    }
}
