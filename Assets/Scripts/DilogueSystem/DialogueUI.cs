using System;
using System.Collections;
using System.Collections.Generic;
using LittleSimTest.SoundSystem;
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
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(callback);
            continueButton.onClick.AddListener(PlayButtonClickSound);
        }
        public void SetName(string text)
        {
            nameText.text = text;
        }

        private IEnumerator StartUpdatingText(string text)
        {
            sentenceText.text = "";
            continueButton.gameObject.SetActive(false);
            foreach (var letter in text.ToCharArray())
            {
                sentenceText.text += letter;
                yield return new WaitForSeconds(0.01f);
            }

            continueButton.gameObject.SetActive(true);
        }

        private void PlayButtonClickSound()
        {
            SoundManager.Instance.PlayButtonClickSound();
        }
        
        public void SetSentence(string text)
        {
            StartCoroutine(StartUpdatingText(text));
        }
    }
}