using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
public partial class LocationList : Node
{
    private Node parent;

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

    public override void _Ready()
    {
        parent = GetParent();

        ChildEnteredTree += OnChildEnteredTree;

        ChildExitingTree += OnChildExitingTree;
    }

    public void OnChildEnteredTree(Node node)
    {
        if (node is LocationData data)
        {
            this.list.Add(data.Name, data);
        }
        else
        {
            RemoveChild(node);
        }
    }

    public void OnChildExitingTree(Node node)
    {
        if (node is LocationData data)
        {
            if (list.ContainsKey(data.Name) == false) return;

            this.list.Remove(data.Name);
        }
    }

    public bool TryAddChild(LocationData locationData)
    {
        if (this.list.ContainsKey(locationData.Name) == true) return false;

        this.AddChildDeferred(locationData, locationData.Name, parent);

        return true;
    }

    public bool TryRemoveChild(string name)
    {
        if (this.list.ContainsKey(name) == false) return false;

        this.RemoveChild(this.list[name]);

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