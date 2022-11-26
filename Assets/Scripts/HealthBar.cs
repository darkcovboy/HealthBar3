using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private float _recoveryRate = 0.2f;
    private float _divider = 100;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.value = _player.Health / _divider;
    }

    private void OnHealthChanged()
    {
        StopCoroutine(Fill());
        var fill = StartCoroutine(Fill());
    }

    private IEnumerator Fill()
    {
        while (_slider.value != (_player.Health / _divider))
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.Health / _divider, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
