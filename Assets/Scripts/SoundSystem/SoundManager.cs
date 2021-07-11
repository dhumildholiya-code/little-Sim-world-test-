using System;
using UnityEngine;

namespace LittleSimTest.SoundSystem
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        private AudioSource _audioSource;

        [Header("Confirmation Sound")] [SerializeField]
        private AudioClip confirmSound;

        [Header("button Click Sound")] [SerializeField]
        private AudioClip buttonClickSound;

        [Header("Equip/Dequip Clothe Sound")] [SerializeField]
        private AudioClip clothSound;

        [Header("open sound")] [SerializeField]
        private AudioClip openSound;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(this.gameObject);
            }
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayConfirmSound()
        {
            PlaySound(confirmSound);
        }

        public void PlayButtonClickSound()
        {
            PlaySound(buttonClickSound);
        }

        public void PlayOpenSound()
        {
            _audioSource.PlayOneShot(openSound, 0.15f);
        }

        public void PlayOnEquipSound()
        {
            PlaySound(clothSound);
        }

        private void PlaySound(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
        
    }
}
