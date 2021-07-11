using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LittleSimTest.DilogueSystem
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI sentenceText;
        [SerializeField] private Button continueButton;

        public void HandleContinueButton(UnityAction callback)
        {
            continueButton.onClick.AddListener(callback);
        }
        public void SetnName(string text)
        {
            nameText.text = text;
        }
        public void SetSentence(string text)
        {
            sentenceText.text = text;
        }
    }
}