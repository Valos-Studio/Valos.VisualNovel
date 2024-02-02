using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
public partial class ResponseNodes : Node
{
    public ICollection<ResponseData> Values
    {
        get => this.list.Values;
    }

    public ICollection<int> Keys
    {
        get => this.list.Keys;
    }

    public ResponseData this[int key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<int, ResponseData> list;

    public ResponseNodes()
    {
        this.list = new Dictionary<int, ResponseData>();
    }
    
    public bool TryAdd(ResponseData responseData)
    {
        return true;
    }
    
    public IEnumerator<KeyValuePair<int, ResponseData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}