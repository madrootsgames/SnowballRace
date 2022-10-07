using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField]
    private Button BtnServer;

    [SerializeField]
    private Button BtnHost;

    [SerializeField]
    private Button BtnClient;

    private bool serverStarted;
    private bool hostStarted;
    private bool clientStarted;

    private void Awake()
    {
        BtnServer.onClick.AddListener(() =>
        {
            if(serverStarted)
            {
                NetworkManager.Singleton.Shutdown();
                serverStarted = false;
                TMP_Text txt = BtnServer.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Start Server";

                GameObject[] players = GameObject.FindGameObjectsWithTag("t_player");
                foreach (GameObject player in players)
                {
                    GameObject.Destroy(player);
                }
            }
            else
            {
                NetworkManager.Singleton.StartServer();
                serverStarted = true;
                TMP_Text txt = BtnServer.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Stop Server";                
            }            
        });

        BtnHost.onClick.AddListener(() =>
        {            
            if (hostStarted)
            {
                NetworkManager.Singleton.Shutdown();
                hostStarted = false;
                TMP_Text txt = BtnHost.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Start Host";

                GameObject[] players = GameObject.FindGameObjectsWithTag("t_player");
                foreach (GameObject player in players)
                {
                    GameObject.Destroy(player);
                }
            }
            else
            {
                NetworkManager.Singleton.StartHost();
                hostStarted = true;
                TMP_Text txt = BtnHost.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Stop Host";                
            }
        });

        BtnClient.onClick.AddListener(() =>
        {            
            if (clientStarted)
            {
                NetworkManager.Singleton.Shutdown();
                clientStarted = false;
                TMP_Text txt = BtnClient.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Start Client";

                GameObject[] players = GameObject.FindGameObjectsWithTag("t_player");
                foreach (GameObject player in players)
                {
                    GameObject.Destroy(player);
                }
            }
            else
            {
                NetworkManager.Singleton.StartClient();
                clientStarted = true;
                TMP_Text txt = BtnClient.GetComponentInChildren<TMP_Text>(true);
                txt.text = "Stop Client";                
            }
        });
    }
}
