using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public GameObject[] TabPanel;
    private Vector3 InventoryTabFade = new Vector3(2000, 0, 0);
    public bool flipInventoryTab = false;
    [SerializeField] private GameObject player;

    [SerializeField] private CinemachineFreeLook CMFL;
    public static bool tabInventoryOpen = false;
    
    public GameObject PauseMenuUI;
    public static bool GameIsPaused = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            FlipInventory();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void FlipInventory()
    {
        if (!flipInventoryTab)
        {
            CMFL.m_XAxis.m_MaxSpeed = 0;
            CMFL.m_YAxis.m_MaxSpeed = 0;
            Cursor.lockState = CursorLockMode.None;
                
            for (int x = 0; x < TabPanel.Length; x++)
            {
                TabPanel[x].gameObject.GetComponent<RectTransform>().localPosition += InventoryTabFade;
            }
            flipInventoryTab = true;
            tabInventoryOpen = true;
        }
            
        else if (flipInventoryTab)
        {
            CMFL.m_YAxis.m_MaxSpeed = 1.5f;
            CMFL.m_XAxis.m_MaxSpeed = 225;
            Cursor.lockState = CursorLockMode.Locked;
                
            for (int x = 0; x < TabPanel.Length; x++)
            {
                TabPanel[x].gameObject.GetComponent<RectTransform>().localPosition -= InventoryTabFade;
            }
            flipInventoryTab = false;
            tabInventoryOpen = false;
        }
    }
    
    public void Resume()
    {
        CMFL.m_YAxis.m_MaxSpeed = 1.5f;
        CMFL.m_XAxis.m_MaxSpeed = 225;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause()
    {
        CMFL.m_XAxis.m_MaxSpeed = 0;
        CMFL.m_YAxis.m_MaxSpeed = 0;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    // Buttons
    
    public void ControlsButton()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }
    
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartAgain()
    {
        SceneManager.LoadScene("2- Game");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
