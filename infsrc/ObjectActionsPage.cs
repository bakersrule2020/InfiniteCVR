using BTKUILib;
using BTKUILib.UIObjects;
using UnityEngine;
using MelonLoader;
using BTKUILib.UIObjects.Components;
using System.CodeDom;

namespace ZuluClientCVR
{
    public static class ObjectActionsPage
    {
        public static Button deletebutton;
        public static ToggleButton delobj;
        public static Category actions;
        public static GameObject obj;
        public static Page subPage2;
        public static void makeactionspage()
        {
            MelonLogger.Msg("Creating actions page...");
            var subPage2 = new Page("Object Actions", "", false, "OurMod");

            void toggleobjactive(bool active)
            {
                obj.SetActive(active);
            }
            void deleteobject()
            {
                GameObject.Destroy(obj);
                obj = null;
                CVRClient.CVRClient.subPage.OpenPage();
            }
              actions = subPage2.AddCategory(obj.name + " Actions");
            delobj = actions.AddToggle("Is object active?", "Change object active state", obj.activeSelf);
             deletebutton = actions.AddButton("Delete Object", "tools", "Deletes the object.");
             deletebutton.OnPress += deleteobject;

            delobj.OnValueUpdated += toggleobjactive;
            QuickMenuAPI.AddRootPage(subPage2);
            MelonLogger.Msg("Done creating actions page.");
        }
        public static void Selectobject(GameObject @object)
        {
             obj = @object;
        }
        public static void showactionspage()
        {
            actions.CategoryName = obj.name + " Actions";
            subPage2.MenuTitle = obj.name + " Actions";
            subPage2.OpenPage();
        }
    }
}
