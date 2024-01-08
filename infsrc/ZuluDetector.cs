using ABI_RC.Core;
using ABI_RC.Systems.ModNetwork;
using MelonLoader;
using System;
using UnityEngine;

internal class moddingnetwork
{
    private const string modid = "com.tocat.Infinite";
    private static readonly Guid ModGuid = new Guid(modid);

    public moddingnetwork()
    {
        //MelonLogger.Msg("Initializing modding network...");
        ModNetworkManager.Subscribe(ModGuid, OnModNetworkMessageReceived);
        //MelonLogger.Msg("Subscribed to mod network with ID: " + modid);
    }

    public void SendMessageToAll(string username)
    {
        //MelonLogger.Msg($"Preparing to send message to all: {username} with the mod installed has joined.");

        var modMsg = new ModNetworkMessage(ModGuid);
        modMsg.Write($"{username} with the mod installed has joined.");
        modMsg.Send();

        //MelonLogger.Msg("Message sent to all.");
    }

    private static void OnModNetworkMessageReceived(ModNetworkMessage msg)
    {
        //MelonLogger.Msg("Received a message on the mod network.");

        msg.Read(out bool isUsingMod);
        if (isUsingMod)
        {
            msg.Read(out string playerId);
            MelonLogger.Msg($"Player with ID {playerId} has the mod installed.");

            // Notify other components that a player with the mod has joined
            CVRClient.CVRClient.oninfdetect(playerId);
        }
        else
        {
            //MelonLogger.Msg("Received message is not a mod usage notification.");
        }
    }
}