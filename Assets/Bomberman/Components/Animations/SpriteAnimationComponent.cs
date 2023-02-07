using UnityEngine;
using UnityEngine.Events;

namespace Bomberman.Components.Animations
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimationComponent : MonoBehaviour
    {
        [SerializeField] [Range(1, 120)] private int _frameRate = 10;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clips;

        private SpriteRenderer _spriteRenderer;
        private float _secondsPerFrame;
        private float _nextFrameTime;
        private int _currentClipIndex;
        private int _currentFrameIndex;

        public bool IsPlaying { get; private set;}

        private void OnValidate() => _secondsPerFrame = 1f / _frameRate;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _secondsPerFrame = 1f / _frameRate;
            StartAnimation();
        }

        public void SetClip(string clipName)
        {
            if (string.IsNullOrWhiteSpace(clipName)) return;

            for (int i = 0; i < _clips.Length; i++)
            {
                if (clipName.ToLower() == _clips[i].Name.ToLower())
                {
                    _currentClipIndex = i;
                    StartAnimation();
                    return;
                }
                enabled = IsPlaying = false;
            }
        }

        public void StopAnimation()
        {
            enabled = IsPlaying = false;
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = IsPlaying = true;
            _currentFrameIndex = 0;
        }

        private void Update()
        {
            if (_clips.Length == 0) return;

            if (_nextFrameTime > Time.time) return;

            var currentClip = _clips[_currentClipIndex];
            if (_currentFrameIndex >= currentClip.Sprites.Length)
            {
                _currentFrameIndex = 0;

                if (!currentClip.Loop)
                {
                    enabled = IsPlaying = currentClip.AllowNextClip;
                    currentClip.OnComplete.Invoke();
                    _onComplete?.Invoke(currentClip.Name);

                    if (currentClip.AllowNextClip)
                        _currentClipIndex = (int)Mathf.Repeat(_currentFrameIndex + 1, _clips.Length);
                }
            }

            _spriteRenderer.sprite = currentClip.Sprites[_currentFrameIndex];
            _nextFrameTime += _secondsPerFrame;
            _currentFrameIndex++;
        }
    }
}