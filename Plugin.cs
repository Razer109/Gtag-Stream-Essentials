using BepInEx;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace TyresStreamingEssentials
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public void OnGUI()
        {
            GUI.skin.box.fontSize = 35;
            GUI.skin.label.fontSize = 35;

            Player[] players = null;

            float boxHeight = 400f;

            if (PhotonNetwork.InRoom)
            {
                players = PhotonNetwork.PlayerList;
                boxHeight += Mathf.Min(players.Length, PhotonNetwork.CurrentRoom.MaxPlayers) * 40f;
            }

            GUI.Box(new Rect(1000f, -1f, 400, boxHeight), "Stream Essentials");

            if (PhotonNetwork.InRoom)
            {
                GUI.Label(new Rect(1000f, 40f, 400, 400), " ");

                float yOffset = 80f;

                foreach (Player player in players)
                {
                    GUI.contentColor = Color.white;

                    if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
                    {
                        GUI.contentColor = Color.yellow;
                    }

                    GUI.Label(new Rect(1000f, yOffset, 400, 400), player.NickName);

                    yOffset += 40f;
                }
            }
            else
            {
                GUI.Label(new Rect(1000f, 40f, 400, 400), "Not in a room");
            }
        }
    }
}
