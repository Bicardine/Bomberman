using UnityEngine;

namespace Bomberman.Components.GOBased
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private Object _objectToDestroy;

        public void Destroy() => Destroy(_objectToDestroy);
    }
}