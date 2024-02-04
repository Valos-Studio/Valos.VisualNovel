using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
public partial class ResponseList : Node
{
    public ICollection<ResponseData> Values
    {
        get => this.list.Values;
    }

    public ICollection<string> Keys
    {
        get => this.list.Keys;
    }

    public ResponseData this[string key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<string, ResponseData> list;

    private Node parent;

    public ResponseList()
    {
        this.list = new Dictionary<string, ResponseData>();
    }

    public override void _Ready()
    {
        parent = GetParent();

        ChildEnteredTree += OnChildEnteredTree;

        ChildExitingTree += OnChildExitingTree;
    }

    public void OnChildEnteredTree(Node node)
    {
        if (node is ResponseData data)
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
        if (node is ResponseData data)
        {
            if (list.ContainsKey(data.Name) == false) return;

            this.list.Remove(data.Name);
        }
    }

    public bool TryAddChild(ResponseData responseData)
    {
        if (this.list.ContainsKey(responseData.Name) == true) return false;

        this.AddChildDeferred(responseData, parent, responseData.Name);

        return true;
    }

    public bool TryRemoveChild(string name)
    {
        if (this.list.ContainsKey(name) == false) return false;

        this.RemoveChild(this.list[name]);

        return true;
    }

    public IEnumerator<KeyValuePair<string, ResponseData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}