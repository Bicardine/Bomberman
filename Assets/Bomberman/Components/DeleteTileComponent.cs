using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace Bomberman.Components
{
    public class DeleteTileComponent : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private UnityEvent<Vector2> _onDeleted;

        public UnityEvent<Vector2> OnDeleted => _onDeleted;

        public void Delete(Vector2 position)
        {
            var cell = _tileMap.WorldToCell(position);
            var tile = _tileMap.GetTile(cell);

            if (tile != null)
            {
                _tileMap.SetTile(cell, null);
                _onDeleted?.Invoke(position);
            }
        }
    }
}