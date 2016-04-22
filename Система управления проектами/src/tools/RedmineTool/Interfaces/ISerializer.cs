namespace RedmineTool.Interfaces
{
    public interface ISerializer
    {
        string Serialize(object source);
        T Deserialize<T>(string source);
    }
}