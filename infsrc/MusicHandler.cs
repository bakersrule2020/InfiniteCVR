using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using RTG;
using System;
using System.Runtime.Remoting.Contexts;
using UnityEngine.Networking;
using CVRClient;
using Button = BTKUILib.UIObjects.Components.Button;
using System.Collections.Generic;
using System.Net;
using UnityEngine.Assertions.Must;
using System.Windows.Shapes;
using Path = System.IO.Path;
using System.Security.AccessControl;
using BTKUILib;
using Unity.Assertions;

public class MusicPlayer : MonoBehaviour
{
    public static AudioSource audioSource;
    private static AudioClip[] musicTracks;
    private static int currentTrackIndex = 0;
    private static bool IsInit = false;

    private static Text trackInfoText;

    public static void InitMusic()
    {
        if (!IsInit)
        {
            CreateMusicFolder();
            audioSource = GameObject.Find("QuickMenu").AddComponent<AudioSource>();
            audioSource.spatialBlend = 0f; // No spatial blending
            audioSource.bypassEffects = true; // Bypass any audio effects (e.g., reverb)
            audioSource.playOnAwake = false; // Do not play on awake
            audioSource.loop = false; // Do not loop by default
            audioSource.volume = 0.8f;
            if (audioSource.transform.parent.gameObject.name != "QuickMenu")
            {

                LoadMusicTracks();
                IsInit = true;
            }
            else
            {
                MelonLogger.Error("Shit's a bit less fucked but still fucked");
            }

        }
        {
            MelonLogger.Warning("---If you are not tocat, you can ignore this warning---\n[MusicPlayer.InitMusic()]: Tried to initialize while already initialized!");
            return;
        }


        // Create UI elements
        //CreateUI();
    }

    public static void CreateMusicFolder()
    {
        string gameRootPath = Application.dataPath;
        string musicFolderPath = Path.Combine(gameRootPath, "../InfiniteMusic");
        if (!Directory.Exists(musicFolderPath))
        {
            try
            {
                Directory.CreateDirectory(musicFolderPath);
            }
            catch(Exception ex) {
                File.WriteAllText(gameRootPath + "InfiniteErrorLog.log", @"==IF YOU ARE SEEING THIS FILE, AN ERROR OCCURED. REPORT IT TO TOCAT.==/n" + ex.Message);
            }
            
        }
    }
    static public string alreadyusednames = "";
    public static void RefreshMusic()
    {

        QuickMenuAPI.ShowAlertToast("Refreshing music, please wait...", 5);
        IsInit = false;

        CVRClient.CVRClient.muscat.ClearChildren();
        GameObject.Destroy(audioSource);
        InitMusic();
        
    }
    private static void LoadMusicTracks()
    {
        //MelonLogger.Log("Loading Music Tracks...");
        string musicFolderPath = Path.Combine(Application.dataPath, "../InfiniteMusic");
        string[] audioFiles;
        try
        {
            audioFiles = Directory.GetFiles(musicFolderPath, "*.mp3");
        }
        catch (Exception ex)
        {
            string gameRootPath = Application.dataPath;
            File.WriteAllText(gameRootPath + "InfiniteErrorLog.log", @"==IF YOU ARE SEEING THIS FILE, AN ERROR OCCURED. REPORT IT TO TOCAT.==/n" + ex.Message);
            audioFiles = new[] { "Something went wrong!" };
        }
        // Adjust file extension accordingly

        if (audioFiles.Length == 0)
        {
            //MelonLogger.Log("No music tracks found in the InfiniteMusic folder.");
            return;
        }

        musicTracks = new AudioClip[audioFiles.Length];
        //MelonLogger.Msg("Initialized audioclip!");
        for (int i = 0; i < audioFiles.Length; i++)
        {
          
            string filePath = "file://" + audioFiles[i];
            //if (alreadyusednames.Contains(filePath)) { continue; } 
            //MelonLogger.Msg("Initializing LoadAudioclip...");
            //MusicPlayer pleasejustwork = new MusicPlayer();
            //MelonLogger.Msg("Initializing LoadAudioclip... (2)");
            LoadAudioClip(filePath, i);
            
            //MelonLogger.Msg("Done Initializing.");
        }
        
        
    }

    private static void LoadAudioClip(string path, int index)
    {
        if (IsInit) { return; }
        

            WWW www = new WWW(path);
        //unityWebRequest.downloadHandler = www;
        //www.streamAudio = true;
        //unityWebRequest.SendWebRequest();
        AudioClip clip = www.GetAudioClip(false);
        while (!clip.isReadyToPlay) { 
            
        }
        {
            if (www.GetAudioClip(false))
            {
                if (www.error != null)
                {
                    MelonLogger.LogError($"Error loading audio file: {www.error}");
                }
                else
                {

                    void playmusic()
                    {
                        MelonLogger.Msg("Playing...");

                        audioSource.clip = www.GetAudioClip(false);
                        MelonLogger.Msg("Stage 2!");
                        audioSource.Play(0);
                        if (!audioSource.isPlaying)
                        {
                            audioSource.Play(0);
                        }
                        MelonLogger.Msg("Playing!");

                    }
                    musicTracks[index] = www.GetAudioClip(false);
                    // MelonLogger.Log($"Loaded audio file: {Path.GetFileName(path)}");
                    Button musbtn = CVRClient.CVRClient.muscat.AddButton($"{Path.GetFileName(path)}", "play", "Plays the labeled music file.");
                    musbtn.OnPress += playmusic;
                    //alreadyusednames += Path.GetFileName(path);

                }
            }
            else
            {
                MelonLogger.Error("[MusicPlayer]: SHIT'S FUCKED");
            }
        };
    }

    public static void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
       
    }
    public static void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }

    }
}
