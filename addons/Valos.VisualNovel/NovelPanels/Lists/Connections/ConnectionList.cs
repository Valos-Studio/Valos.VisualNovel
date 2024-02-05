using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;

namespace Valos.VisualNovel.NovelPanels.Lists.Connections;

[Tool]
public partial class ConnectionList : Node
{
    public ICollection<Connection> Values
    {
        get => this.List.Values;
    }

    public ICollection<int> Keys
    {
        get => this.List.Keys;
    }

    public Connection this[int key]
    {
        get => this.List[key];
    }

    public int Count
    {
        get => this.List.Count;
    }

    [Export()] public Godot.Collections.Dictionary<int, Connection> List { get; set; }

    public ConnectionList()
    {
        this.List = new Godot.Collections.Dictionary<int, Connection>();
    }

    public override void _Ready()
    {
        base._Ready();

        GD.PrintErr(List.Count);
    }

    public bool TryAdd(Connection connection)
    {
        if (this.List.ContainsKey(connection.GetHashCode()) == true) return false;

        this.List.Add(connection.GetHashCode(), connection);

        return true;
    }

    public bool TryRemove(int key)
    {
        if (this.List.ContainsKey(key) == false) return false;

        this.List.Remove(key);

        return true;
    }

    public IEnumerable<Connection> GetListWhereName(StringName name)
    {
        return this.List.Values.Where(p => p.FromNode == name || p.ToNode == name);
    }

    public IEnumerator<KeyValuePair<int, Connection>> GetEnumerator()
    {
        return this.List.GetEnumerator();
    }

    public void Clear()
    {
        this.List.Clear();
    }

    // public override Array<Dictionary> _GetPropertyList()
    // {
    //     return new Array<Dictionary>()
    //     {
    //         new Dictionary()
    //         {
    //             { "List", List.GetType().ToString() }
    //         }
    //     };
    // }
}