using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }
    public AudioClip Coin;
    public AudioClip Hit;
    public AudioClip Slash;
    public AudioClip Upgrade;
    private AudioSource _audioSource;
    private float _hitTimer;
    private float _hitInterval = 0.5f;
    private float _slashTimer;
    private float _slashInterval = 0.5f;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _hitTimer = 0;
        _slashTimer = 0;
    }
    private void Update()
    {
        _hitTimer += Time.deltaTime;
        _slashTimer += Time.deltaTime;
    }

    public void CoinSound()
    {
        _audioSource.clip = Coin;
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    public void UpgradeSound()
    {
        _audioSource.clip = Upgrade;
        _audioSource.PlayOneShot(_audioSource.clip);
    }
    public void HitSound()
    {
        if (_hitTimer >= _hitInterval)
        {
            _audioSource.clip = Hit;
            _audioSource.PlayOneShot(_audioSource.clip);
            _hitTimer = 0;
        }
    }
    public void SlashSound()
    {
        if (_slashTimer >= _slashInterval)
        {
            _audioSource.clip = Slash;
            _audioSource.PlayOneShot(_audioSource.clip);
            _slashTimer = 0;
        }
    }
    
}
