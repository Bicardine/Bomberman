using Bomberman.BonusItems;
using Bomberman.Utils;
using UnityEngine;

public class GetRandomItem : MonoBehaviour
{
    public void Get()
    {
        var type = EnumUtils.GetRandomEnumValue<BonusItemType>();
    }
}
