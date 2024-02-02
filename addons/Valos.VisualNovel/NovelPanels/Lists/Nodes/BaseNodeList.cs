using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
public partial class BaseNodeList : Node
{
    public ICollection<DataNode> Values
    {
        get => this.list.Values;
    }

    public ICollection<int> Keys
    {
        get => this.list.Keys;
    }

    public DataNode this[int key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<int, DataNode> list;

    public BaseNodeList()
    {
        this.list = new Dictionary<int, DataNode>();
    }

    public IEnumerator<KeyValuePair<int, DataNode>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}