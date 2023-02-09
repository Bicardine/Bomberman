using System;
using Bomberman.Model.Data;
using UnityEngine;

namespace Bomberman.Model.Definitions.Repositories.BonusItems
{
    [Serializable]
    public class BonusItemDefinition : IHaveId
    {
        [SerializeField] private string _id;
        [SerializeField] private BonusItemData _data;

        public string Id => _id;
        public BonusItemData Data => _data;
        public bool IsVoid => string.IsNullOrEmpty(_id);
    }
}