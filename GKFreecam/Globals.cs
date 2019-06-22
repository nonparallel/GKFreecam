using Harmony;
using GKML;
using UnityEngine;
using System;
using GKFreecam.Classes;
using System.Collections.Generic;
using GKFreecam.FreecamStates;
using GKFreecam.Metadata;

namespace GKFreecam
{
    public static class Globals
    {
        public static CamStateFreecam Freecam = new CamStateFreecam();
        public static bool InFreecam = false;

        public static Vector3 LMOrigin = Vector3.zero;
        public static JSONConfig Config;

        public const string JSONLocation = "freecam.json";
    }
}
