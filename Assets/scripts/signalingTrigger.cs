using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class signalingTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

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

        float step = 0.1f;
        float i = 0;
        while (i <= _volume)
        {
            i += Time.deltaTime * step;
            _sound.volume = i;
            yield return null;
        }
    }

    private IEnumerator VolumeReduce()
    {
        float step = 0.1f;
        float i = _sound.volume;
        while (i >= 0.05f)
        {
            i -= Time.deltaTime * step;
            _sound.volume = i;
            yield return null;
        }
    }


}
