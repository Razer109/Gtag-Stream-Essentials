using BepInEx;
using System;
using UnityEngine;
using Photon.Pun;

namespace TyresStreamingEssentials
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public void OnGUI()
        {
            // if(GUI.Button(new Rect(50f, 20f, 400f, 400f), "join random test")) { PhotonNetwork.JoinRandomOrCreateRoom(); }       
            GUI.skin.box.fontSize = 35;
            GUI.skin.label.fontSize = 35;
           
            
            // pain
            GUI.Box(new Rect(1000f, -1f, 400, 400), "Stream Essentials");
            if (PhotonNetwork.InRoom)
            {
                GUI.Label(new Rect(1000f, 40f, 400, 400), PhotonNetwork.CurrentRoom.Name + "\n" + PhotonNetwork.CurrentRoom.PlayerCount + "/" + PhotonNetwork.CurrentRoom.MaxPlayers);
            }
            else
            {
                GUI.Label(new Rect(1000f, 40f, 400, 400), "Not In Room Right Now!");
            }
        }
    }
}
