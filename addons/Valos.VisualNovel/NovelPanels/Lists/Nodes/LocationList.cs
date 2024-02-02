using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
public partial class LocationList : Node
{
    public ICollection<LocationData> Values
    {
        get => this.list.Values;
    }

    public ICollection<string> Keys
    {
        get => this.list.Keys;
    }

    public LocationData this[string key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<string, LocationData> list;

    public LocationList()
    {
        this.list = new Dictionary<string, LocationData>();
    }

    public bool TryAdd(LocationData locationData)
    {
        if (this.list.ContainsKey(locationData.Name) == true) return false;
        
        this.list.Add(locationData.Name, locationData);
        
        this.AddChildDeferred(locationData, locationData.Name);

        return true;
    }

    public IEnumerator<KeyValuePair<string, LocationData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}