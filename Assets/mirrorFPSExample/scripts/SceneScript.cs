using Mirror;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneScript : NetworkBehaviour
{
    public SceneReference sceneReference;

    public TMP_Text canvasStatusText;
    public PlayerScript playerScript;

    public TMP_Text canvasAmmoText;

    public void UIAmmo(int _value)
    {
        canvasAmmoText.text = "Ammo: " + _value;
    }

    [SyncVar(hook = nameof(OnStatusTextChanged))]
    public string statusText;

    void OnStatusTextChanged(string _Old, string _New)
    {
        //called from sync var hook, to update info on screen for all players
        canvasStatusText.text = statusText;
    }

    public void ButtonSendMessage()
    {
        if (playerScript != null)
            playerScript.CmdSendPlayerMessage();
    }

    public void ButtonChangeScene()
    {
        if (isServer)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "MyScene")
                NetworkManager.singleton.ServerChangeScene("MyOtherScene");
            else
                NetworkManager.singleton.ServerChangeScene("MyScene");
        }
        else
            Debug.Log("You are not Host.");
    }
}
