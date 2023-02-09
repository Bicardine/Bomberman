namespace Bomberman.Model.Data
{
    public interface IItemRenderer<TDataType>
    {
        void Render(TDataType data);
    }
}