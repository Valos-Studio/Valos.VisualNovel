using System.Collections.Generic;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public class ConnectionList
{
    private readonly Dictionary<int, Connection> list;

    public ConnectionList()
    {
        this.list = new Dictionary<int, Connection>();
    }

    public bool TryAdd(Connection connection)
    {
        if (this.list.ContainsKey(connection.GetHashCode()) == true) return false;

        this.list.Add(connection.GetHashCode(), connection);

        return true;
    }

    public bool TryDelete(int hashCode)
    {
        if (this.list.ContainsKey(hashCode) == false) return false;

        this.list.Remove(hashCode);

        return true;
    }
}