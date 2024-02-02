using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
public partial class LocationNodes : Node
{
    public ICollection<LocationData> Values
    {
        get => this.list.Values;
    }

    public ICollection<int> Keys
    {
        get => this.list.Keys;
    }

    public LocationData this[int key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<int, LocationData> list;

    public LocationNodes()
    {
        this.list = new Dictionary<int, LocationData>();
    }

    public bool TryAdd(LocationData locationData)
    {
        return true;
    }

    public IEnumerator<KeyValuePair<int, LocationData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}