using Harmony;
using UnityEngine;

using System;
using System.Collections;

using GKFreecam.FreecamStates;

namespace GKFreecam
{
    /*
    [HarmonyPatch(typeof(StartGameState))]
    [HarmonyPatch("Enter")]
    public class CameraBasePatch
    {
        static public void Postfix()
        {
            UnityEngine.Object.Destroy(Camera.main.GetComponent<CameraBase>());

            var _cBExt = Camera.main.gameObject.AddComponent<CameraBaseExtension>();
            _cBExt.SwitchCamera(ECamState.Follow, ECamState.TransCut);
        }
    } 
    */

    [HarmonyPatch(typeof(CameraBase), "FixedUpdate")]
    public class FreecamSwitcher
    {
        public static Transform PTransform;

        public static void InputCheck()
        {
            if (Input.GetKeyDown(Globals.Config.ActivatorKey))
            {
                if (!Globals.InFreecam)
                {
                    Globals.Freecam.Enter(PTransform, null);
                    Globals.InFreecam = true;
                } else
                {
                    Globals.Freecam.States[Globals.Freecam.CamState].OnExit();
                    Globals.Freecam.CamState++;

                    if (Globals.Freecam.CamState > Globals.Freecam.States.Count - 1)
                    {
                        Globals.Freecam.CamState = 0;
                        Globals.InFreecam = false;
                    }

                    Globals.Freecam.States[Globals.Freecam.CamState].OnEnter();
                }
            }

            if (Input.GetKeyDown(Globals.Config.HideCamKey))
            {
                UICamera.currentCamera.enabled = !UICamera.currentCamera.enabled;
            }
        }

        public static void Postfix(ref Transform ___m_pTransform)
        {
            PTransform = ___m_pTransform;
        }
    }

    [HarmonyPatch(typeof(CameraBase), "GetCurrentStateClass")]
    public class FreecamHelper
    {
        public static void Postfix(ref CamState __result)
        {
            __result = Globals.InFreecam ? Globals.Freecam : __result;
        }
    }

    [HarmonyPatch(typeof(CameraBase), "Start")]
    public class FreecamSetup
    {
        public static void Postfix(CameraBase __instance)
        {
            Globals.Freecam.AddState<MouseState>();
            Globals.Freecam.AddState<KeyboardState>();
            Globals.Freecam.AddState<ControllerState>();
            Globals.Freecam.AddState<FPSState>();

            __instance.gameObject.AddComponent<InputCheckUpdater>();
        }
    }

    public class InputCheckUpdater : MonoBehaviour
    {
        public void Update()
        {
            FreecamSwitcher.InputCheck();
            if (Input.GetMouseButtonDown(0))
                Globals.LMOrigin = Input.mousePosition;
        }
    }
}
