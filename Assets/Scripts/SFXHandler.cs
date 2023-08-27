using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]
public class SFXHandler : MonoBehaviour
{
    [BoxGroup("AudioClip")]
    [SerializeField] private AudioClip _attackSFX,_jumpSFX,_deathSFX,_collectibleSFX,_checkPointSFX,_birdAttackSFX ;
    [BoxGroup("AudioSource")]
    [SerializeField] private AudioSource _audioSource;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    public void PlayAttackSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_attackSFX, 0.5f);
    }

    public void PlayJumpSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_jumpSFX, 0.5f);
    }

    public void PlayDeathSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_deathSFX, 0.5f);
    }

    public void PlayCollectbleSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_collectibleSFX, 0.5f);
    }

    public void PlayCheckpointSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_checkPointSFX, 0.5f);
    }

    public void PlayBirdAttackSFX()
    {
        if (_playerData._isSFXOff) return;
        _audioSource.PlayOneShot(_birdAttackSFX, 0.5f);
    }

}
