﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ZuluClientCVR
{
    internal static class UITextureHelper
    {
        public static Texture2D LoadTextureFromAssembly(Assembly asm, string resourcePath)
        {
            Stream stream = asm.GetManifestResourceStream(resourcePath);

            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            Texture2D texture = new Texture2D(256, 256);
            texture.LoadImage(buffer);
            return texture;

        }

    }
}
    public class RainbowColorChange : MonoBehaviour
    {
        public Image imageToChange;
        public TMP_Text textToChange;
        private bool changeColor = true;

        public void StartChange()
        {
            StartCoroutine(ChangeColor());
        }
        public void StopChange()
        {
            changeColor = false;
        }
        private IEnumerator ChangeColor()
        {
            while (changeColor)
            {
                float speed = 5.0f;
                float r = Mathf.Sin(Time.time * speed);
                float g = Mathf.Sin(Time.time * speed + 2 * Mathf.PI / 3); // phase shift
                float b = Mathf.Sin(Time.time * speed + 4 * Mathf.PI / 3); // phase shift

                r = (r + 1) / 2;
                g = (g + 1) / 2;
                b = (b + 1) / 2;
                imageToChange.canvasRenderer.SetColor(Color.white);

                imageToChange.color = new Color(r, g, b);
                yield return null;
            }
        }
        //text color change
        public void StartChangeText()
        {
            StartCoroutine(ChangeColorText());
        }
        private IEnumerator ChangeColorText()
        {
            while (changeColor)
            {
                float speed = 5.0f;
                float r = Mathf.Sin(Time.time * speed);
                float g = Mathf.Sin(Time.time * speed + 2 * Mathf.PI / 3); // phase shift
                float b = Mathf.Sin(Time.time * speed + 4 * Mathf.PI / 3); // phase shift

                r = (r + 1) / 2;
                g = (g + 1) / 2;
                b = (b + 1) / 2;

                textToChange.color = new Color(r, g, b);
                yield return null;
            }
        }
        public void StartChangeTextOutline()
        {
            StartCoroutine(ChangeColorTextOutline());
        }
        private IEnumerator ChangeColorTextOutline()
        {
            while (changeColor)
            {
                float speed = 5.0f;
                float r = Mathf.Sin(Time.time * speed);
                float g = Mathf.Sin(Time.time * speed + 2 * Mathf.PI / 3); // phase shift
                float b = Mathf.Sin(Time.time * speed + 4 * Mathf.PI / 3); // phase shift

                r = (r + 1) / 2;
                g = (g + 1) / 2;
                b = (b + 1) / 2;

                textToChange.outlineColor = new Color(r, g, b);
                yield return null;
            }
        }
    }
