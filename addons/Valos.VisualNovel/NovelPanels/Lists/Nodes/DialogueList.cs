using System.Collections.Generic;
using Godot;
using Valos.VisualNovel.DataNodes;

namespace Valos.VisualNovel.GameNodes.Lists.Nodes;

[Tool]
[GlobalClass]
public partial class DialogueList : Node
{
    public ICollection<DialogueData> Values
    {
        get => this.list.Values;
    }

    public ICollection<int> Keys
    {
        get => this.list.Keys;
    }

    public DialogueData this[int key]
    {
        get => this.list[key];
    }

    public int Count
    {
        get => this.list.Count;
    }

    private readonly Dictionary<int, DialogueData> list;

    public DialogueList()
    {
        this.list = new Dictionary<int, DialogueData>();
    }

    public bool TryAdd(DialogueData dialogueData)
    {
        return true;
    }

    public IEnumerator<KeyValuePair<int, DialogueData>> GetEnumerator()
    {
        return this.list.GetEnumerator();
    }

    public virtual void Clear()
    {
        this.list.Clear();
    }
}