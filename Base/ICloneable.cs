namespace AkaScan.EddyCurrent.Core.Base
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}