using ABI_RC.Core.Player;
using System.Linq;
using System.Windows.Media;
using UnityEngine;


internal class Playerlist : MonoBehaviour
{
    private static float Delay = 0;
    GameObject TextObject;

    private TMPro.TextMeshProUGUI PlayerText;

    public void Start()
    {
        GameObject TextObject = new GameObject();
        TextObject.AddComponent<TMPro.TextMeshProUGUI>();
        TextObject.name = "Playerlist";
        PlayerText = TextObject.GetComponent<TMPro.TextMeshProUGUI>();
        PlayerText.enableWordWrapping = false;
        PlayerText.fontSize = 3.3f;
        PlayerText.color = Color.white;
        PlayerText.richText = true;
        PlayerText.alignment = TMPro.TextAlignmentOptions.TopLeft;
        PlayerText.text = "";
        PlayerText.outlineWidth = 0f;
        PlayerText.outlineColor = new Color(0, 0, 0, 0);
        PlayerText.gameObject.active = true;
    }


    public void Update()
    {
        //If we aren't parented to QuickMenu, make us so!
        if (!TextObject.transform.parent == transform.Find("QuickMenu"))
        {
            TextObject.transform.parent = transform.Find("QuickMenu");
        }
        Delay += Time.deltaTime;
        if (Delay < 2) return;
        Delay = 0;
       
        foreach (var Player in CVRPlayerManager.Instance.GetAllNetworkedPlayers())
        {
            PlayerText.text += Player.GetUsername() + "\n";
        }
    }
}