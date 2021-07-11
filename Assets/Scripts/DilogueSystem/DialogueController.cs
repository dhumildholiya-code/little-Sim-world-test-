using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LittleSimTest.DilogueSystem
{
    public class DialogueController : MonoBehaviour
    {
        public static DialogueController Instance;
        private Queue<string> _sentences;
        private UnityAction continueAction;

        [SerializeField] private DialogueUI dialogueUI;

        private void Awake()
        {
            Instance = this;
            continueAction = DisplayNextSentence;
        }

        private void Start()
        {
            _sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            _sentences.Clear();
            
            dialogueUI.gameObject.SetActive(true);
            dialogueUI.SetnName(dialogue.characterName);
            dialogueUI.HandleContinueButton(continueAction);
            
            foreach (var sentence in dialogue.sentences)    
            {
                _sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        private void DisplayNextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
            dialogueUI.SetSentence(sentence);
        }

        private void EndDialogue()
        {
            dialogueUI.gameObject.SetActive(false);
        }
    }
}
