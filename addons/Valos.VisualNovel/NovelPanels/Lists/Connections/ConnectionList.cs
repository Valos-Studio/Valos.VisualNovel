﻿// using System.Collections.Generic;

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

    private Godot.Collections.Dictionary<int, Connection> list;

    public ConnectionList()
    {
        this.list = new Godot.Collections.Dictionary<int, Connection>();
    }

    public override void _Ready()
    {
        base._Ready();

        GD.PrintErr(list.Count);
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

    public override Array<Dictionary> _GetPropertyList()
    {
        return new Array<Dictionary>()
        {
            new Dictionary()
            {
                { "list", list.GetType().ToString() }
            }
        };
    }
}