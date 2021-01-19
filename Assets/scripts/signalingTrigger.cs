using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SignalingTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _step;
    [SerializeField] private float _minVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        VolumeUp();
        StartVolumeUp();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopVolumeUp();
        StartVolumeReduce();
    }

    public void StartVolumeUp()
    {
        var VolumeUpJob = StartCoroutine(VolumeUp());
    }

    private void StopVolumeUp()
    {
        StopCoroutine(VolumeUp());
    }

    private void StartVolumeReduce()
    {
        var VolumeReduceJob = StartCoroutine(VolumeReduce());        
    }

    private IEnumerator VolumeUp()
    {
        float _volume = _sound.volume;
        _sound.volume = 0;
        _sound.Play();

        float i = 0;
        while (i <= _volume)
        {
            i += Time.deltaTime * _step;
            _sound.volume = i;
            yield return null;
        }
    }

    private IEnumerator VolumeReduce()
    {
        float i = _sound.volume;
        while (i >= _minVolume)
        {
            i -= Time.deltaTime * _step;
            _sound.volume = i;
            yield return null;
        }
    }


}
