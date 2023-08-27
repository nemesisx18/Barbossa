using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGM : MonoBehaviour
{
    private static BGM instance;
    [BoxGroup("Audioclip Reference")]
    [SerializeField] private AudioClip _bgmClip;
    [BoxGroup("AudioSource Reference")]
    [SerializeField] private AudioSource _bgmSource;
    [BoxGroup("Variables")]
    [SerializeField] private float _bgmVolume;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    public bool isDestroyOnLoad;


    private void Awake()
    {
        if (isDestroyOnLoad) return;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.loop = true;
        SetBGMVolume(_bgmVolume);

        if (!_playerData._isBGMOff) _bgmSource.Play();

        if (isDestroyOnLoad) return;
        DontDestroyOnLoad(gameObject);
    }


    public void SetBGMVolume(float volume)
    {
        _bgmSource.volume = volume;
    }

    public void PauseBGM()
    {
        _bgmSource.Pause();
    }

    public void PlayBGM()
    {
        _bgmSource.Play();
    }

    public void UnpauseBGM()
    {

        _bgmSource.UnPause();
    }

    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    public void DestroyBGMGameObject()
    {
        Destroy(gameObject);
    }
}