using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance;
    public static SoundManager Instance => _instance;
    [SerializeField] private  SoundAndClips[]  _differentSounds;
    [SerializeField] private  AudioSource _backgroundSound;
    [SerializeField] private AudioSource _sfxSounds;
    
    
        
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        
    }


    private void Start()
    {
        PlayBackgroundMusic(GameSounds.BackGroundMusic);
    }


    [Serializable]
    public class SoundAndClips
    {
        public GameSounds Sounds;
        public AudioClip Clip;
    }

    public void  PlayBackgroundMusic(GameSounds backgroundMusic)
    {
        AudioClip SoundClip = GetAudiClip(backgroundMusic);
         _backgroundSound.clip=SoundClip;
        _backgroundSound.Play();
    }


    public void PlaySfxSound(GameSounds sfxsound)
    {
        AudioClip SoundClip = GetAudiClip(sfxsound);
        _sfxSounds.PlayOneShot(SoundClip);
    }
    public void StopSfxSound() {

        _sfxSounds.Stop();    
    }

    public void StopBackGroundMusic() { 
     
        _backgroundSound.Stop();
    
    }
    private AudioClip GetAudiClip(GameSounds backgroundMusic)
    {
        SoundAndClips item = Array.Find(_differentSounds, i => i.Sounds == backgroundMusic);
        
            if (item != null)
            {
                return item.Clip;
            }
        return null;
    }

    public enum GameSounds
    {
        BackGroundMusic,
        TankFiring,
        TankDestroy,
        TankCollison,
        EnemyDestroy,
        EnemyHit,
        
    }
}
