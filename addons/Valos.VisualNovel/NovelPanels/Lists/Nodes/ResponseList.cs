using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
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

    public ResponseList()
    {
        this.list = new Dictionary<string, ResponseData>();
    }
    
    public bool TryAdd(ResponseData responseData)
    {
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