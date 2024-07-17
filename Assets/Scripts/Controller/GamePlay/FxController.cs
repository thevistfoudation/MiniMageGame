using Core.Pool;
using System.Collections;
using UnityEngine;

public class FxController : MonoBehaviour
{
   
    [SerializeField]
    private float _timeScale;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        Invoke("StopEmission", _timeScale);
    }

    private void StopEmission()
    {
        _particleSystem.Stop();
        Invoke("CollectPool", _timeScale);
    }

    private void CollectPool()
    {
        SmartPool.Instance.Despawn(gameObject);
    }
}
