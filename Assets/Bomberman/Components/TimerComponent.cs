using UnityEngine;
using System.Linq;
using System.Collections;
using Bomberman.Model.Data;

namespace BombermanComponents
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private TimerData[] _timers;

        public void SetTimer(string name)
        {
            var timer = _timers.FirstOrDefault(timer => name == timer.Name);
            StartCoroutine(StartTimer(timer));
        }

        private IEnumerator StartTimer(TimerData timer)
        {
            yield return new WaitForSeconds(timer.Delay);
            timer.OnTimesUp?.Invoke();
        }
    }
}