using System;
using UnityEngine;

namespace LittleSimTest.DilogueSystem
{
    [CreateAssetMenu(menuName = "Create Dialogue", fileName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject
    {
        public String characterName;
        [TextArea(3, 10)] public string[] sentences;
    }
}