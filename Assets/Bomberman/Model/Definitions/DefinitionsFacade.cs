using Bomberman.Model.Definitions.Repositories.BonusItems;
using UnityEngine;

namespace Bomberman.Model.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/DefinitionsFacade", fileName = DEFAULDEFINITIONSFACADETNAME)]
    public class DefinitionsFacade : ScriptableObject
    {
        [SerializeField] private BonusItemsRepostiory _bonusItemsRepository;

        private static DefinitionsFacade _instance;

        public static DefinitionsFacade Instance => _instance == null ? LoadDefinitions() : _instance;

        private const string DEFAULDEFINITIONSFACADETNAME = "DefinitionsFacade";

        private static DefinitionsFacade LoadDefinitions()
        {
            return _instance = Resources.Load<DefinitionsFacade>(DEFAULDEFINITIONSFACADETNAME);
        }

        public BonusItemsRepostiory BonusItemsRepostiory => _bonusItemsRepository;
    }
}