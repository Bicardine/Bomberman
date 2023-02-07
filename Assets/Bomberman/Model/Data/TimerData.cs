using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bomberman.Model.Data
{
    [Serializable]
    public class TimerData
    {
        [SerializeField] private string _name;
        [SerializeField] private float _delay;
        [SerializeField] private UnityEvent _onTimesUp;

        public string Name => _name;
        public float Delay => _delay;
        public UnityEvent OnTimesUp => _onTimesUp;
    }
}