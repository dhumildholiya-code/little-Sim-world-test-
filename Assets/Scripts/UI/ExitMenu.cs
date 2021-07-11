using System;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimTest.UI
{
    public class ExitMenu : MonoBehaviour
    {
        [SerializeField] private GameObject exitMenu;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;
        
        private bool _isOpen;

        private void Start()
        {
            yesButton.onClick.AddListener(()=>Quit(true));
            noButton.onClick.AddListener(()=>Quit(false));
            closeButton.onClick.AddListener(()=>Open(false));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _isOpen = !_isOpen;
                Open(_isOpen);
            }
        }

        private void Quit(bool isQuit)
        {
            if(isQuit)
                Application.Quit();
            else
                Open(false);
        }

        private void Open(bool isActive)
        {
            exitMenu.SetActive(isActive);
            _isOpen = isActive;
        }
    }
}