using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using MelonLoader;

namespace ZuluClientCVR
{
    internal class RPCHelper
    {
        public static DiscordRpcClient discordRpcClient;
        public static void StartRPC()
        {
            discordRpcClient = new DiscordRpcClient("1168637066272313344");
            MelonLogger.Msg("Application ID: " + discordRpcClient.ApplicationID);
            MelonLogger.Msg("Starting Discord RPC...");
            discordRpcClient.Initialize();
            discordRpcClient.SetPresence(new RichPresence()
            {
                Details = "Infinite On Top (",
                Timestamps = new Timestamps()
                {
                    Start = DateTime.UtcNow
                },
                Buttons = new Button[]
                {
                      new Button() { Label = "Get Infinite", Url = "https://discord.gg/JR2FbASvjB" }
                },
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "inflogo",
                    LargeImageText = "Infinite Client 0.0.7",
                    SmallImageKey = "tocat",
                    SmallImageText = "Made by tocat",
                    
                    
                }

            });
            if(discordRpcClient.IsInitialized)
            {
                MelonLogger.Msg("Initialized Discord RPC!");
            }
            else
            {
                MelonLogger.Msg("Failed to start discord RPC.");
            }
            
        }
        public static string getusername() {
            if (discordRpcClient.IsInitialized)
            {
                return discordRpcClient.CurrentUser.DisplayName;
            }
            else
            {
                MelonLogger.Error("Attempt to fetch discord username pre-rpc init");
                return "Unable to fetch username.";
                    
            }

        
        }
        public static void StopRPC()
        {
            MelonLogger.Msg("Stopping Discord RPC...");
            if (discordRpcClient.IsInitialized)
            {
                MelonLogger.Msg("Application ID: " + discordRpcClient.ApplicationID);
                discordRpcClient.Deinitialize();
            }
            else
            {
                MelonLogger.Msg("Failed to stop discord RPC. (Already running?)");
            }

                MelonLogger.Msg("De-initialized Discord RPC!");
        }
    }
}
