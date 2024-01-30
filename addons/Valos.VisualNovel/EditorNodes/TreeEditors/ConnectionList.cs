using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public class ConnectionList
{
    public ICollection<Connection> Values
    {
        get => this.list.Values;
    }
    public ICollection<int> Keys
    {
        get => this.list.Keys;
    }
    public Connection this[int key]
    {
        get => this.list[key];
    }
    public int Count
    {
        get => this.list.Count;
    }

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
    
    public bool TryRemove(int key)
    {
        if (this.list.ContainsKey(key) == false) return false;
        
        this.list.Remove(key);

        return true;
    }

    public IEnumerable<Connection> GetListWhereName(StringName name)
    {
        return this.list.Values.Where(p => p.FromNode == name || p.ToNode == name);
    }

    public IEnumerator<KeyValuePair<int, Connection>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public void Clear()
    {
        this.list.Clear();
    }
}