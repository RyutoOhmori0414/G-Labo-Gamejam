using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSouse;
    [SerializeField] AudioClip[] BGM;
    [SerializeField] AudioClip[] SE;

    public static SoundManager Instance { get; set; }

    void Start()
    {
        GetComponent<AudioSource>();
        audioSouse = gameObject.AddComponent<AudioSource>();
    }

    private void Awake()
    {
        Instance = this;
    }
    public void Play(int Type, int ID)
    {
        Debug.Log(ID);
        switch (Type)
        {
            case 0:
                audioSouse.clip = BGM[ID];
                audioSouse.Play();
                break;

            case 1:
                audioSouse.PlayOneShot(SE[ID]);
                break;
        }
    }

    public void Button(AudioClip audio)
    {
        audioSouse.PlayOneShot(audio);
    }
}
