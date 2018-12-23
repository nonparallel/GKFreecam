using Harmony;
using GKML;
using UnityEngine;
using System;
using GKFreecam.Classes;

namespace GKFreecam
{
    /// <summary>
    /// Used for replacing the old CameraBase with the new reimplementation of it.
    /// </summary>

    [HarmonyPatch(typeof(RcRace))]
    [HarmonyPatch("Start")]
    public class CameraBasePatch
    {
        static public void Postfix()
        {
            var cameraBase = Camera.main.GetComponent<CameraBase>();
            UnityEngine.Object.Destroy(cameraBase);
            Camera.main.gameObject.AddComponent<CameraBaseExtension>();
        }
    }

}
