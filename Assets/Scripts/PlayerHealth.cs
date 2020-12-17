using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _playerHealth = 10;
    [SerializeField] int _healthDecrease = 1;
    [SerializeField] Text _healthText;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerHealth -= _healthDecrease;
        _healthText.text = _playerHealth.ToString();

    }



}
