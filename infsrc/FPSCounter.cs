using UnityEngine;
using MelonLoader;
namespace ZuluClientCVR
{

    public class FramerateCounter
    {
        static public float updateInterval = 0.1f; // Update the frame rate every 0.5 seconds
        static private float accum = 0f;            // Accumulated time
        static private float frames = 0f;           // Number of frames
        static private float timeLeft;
        public static float fps = 0f;

        public static void start()
        {
            timeLeft = updateInterval;
            MelonLogger.Msg("Started FPS Counter!");
        }

        public static void OnUpdate()
        {
            timeLeft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            frames++;

            // Calculate frame rate every updateInterval seconds
            if (timeLeft <= 0.0)
            {
                fps = accum / frames;
                string fpsText = string.Format("{0:F2} FPS", fps);

                // Display the frame rate in the console
                

                // Reset variables for the next interval
                timeLeft = updateInterval;
                accum = 0f;
                frames = 0f;
            }
        }

    }
}