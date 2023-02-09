using System.Collections.Generic;
using UnityEngine;

namespace Bomberman.Model.Definitions.Repositories
{
    public class DefinitionRepository<TDefinitionType> : ScriptableObject where TDefinitionType : IHaveId
    {
        [SerializeField] protected TDefinitionType[] _collection;
        
        public TDefinitionType Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return default;

            foreach (var item in _collection)
            {
                if (item.Id == id)
                    return item;
            }

            return default;
        }

        public TDefinitionType[] Collection => new List<TDefinitionType>(_collection).ToArray();
    }
}