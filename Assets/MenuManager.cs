using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public InputActionReference menuButton;
    public GameObject menu;
    public string lobbyScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(lobbyScene);
    }
}
