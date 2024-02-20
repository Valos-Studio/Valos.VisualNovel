using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;
using Valos.VisualNovel.Extensions;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
public partial class LocationList : Node
{
    [Export()] public Dictionary<string, LocationData> List { get; set; }

    public ICollection<LocationData> Values
    {
        get => this.List.Values;
    }

    public ICollection<string> Keys
    {
        get => this.List.Keys;
    }

    public LocationData this[string key]
    {
        get => this.List[key];
    }

    public int Count
    {
        get => this.List.Count;
    }

    private Node parent;

    public LocationList()
    {
        this.List = new Dictionary<string, LocationData>();
    }

    public override void _Ready()
    {
        parent = GetParent();

        foreach (Node child in GetChildren())
        {
            OnChildEnteredTree(child);
        }

        ChildEnteredTree += OnChildEnteredTree;

        ChildExitingTree += OnChildExitingTree;
    }

    public void OnChildEnteredTree(Node child)
    {
        if (child.GetType() == typeof(NovelPanel))
        {
            LocationData data = (LocationData)child;

            if (this.List.ContainsKey(data.Name) == true)
            {
                GD.PrintErr("LocationList: Added child has duplicated name");

                return;
            }

            this.List.Add(data.Name, data);
        }
        else
        {
            CallDeferred(Node.MethodName.RemoveChild, child);
        }
    }

    public void OnChildExitingTree(Node node)
    {
        if (node is LocationData data)
        {
            if (List.ContainsKey(data.Name) == false) return;

            this.List.Remove(data.Name);
        }
    }

    public bool TryAddChild(LocationData locationData)
    {
        if (this.List.ContainsKey(locationData.Name) == true) return false;

        this.AddChildDeferred(locationData, parent.Owner, locationData.Name);

        return true;
    }

    public bool TryRemoveChild(string name)
    {
        if (this.List.ContainsKey(name) == false) return false;

        this.RemoveChild(this.List[name]);

        return true;
    }

    public IEnumerator<KeyValuePair<string, LocationData>> GetEnumerator()
    {
        return this.List.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.List.Clear();
    }
}