using Godot;

namespace Valos.VisualNovel.EditorNodes.TreeEditors;

public class Connection
{
    public StringName FromNode { get; }
    public long FromPort { get; }
    public StringName ToNode { get; }
    public long ToPort { get; }


    public Connection(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        this.FromNode = fromNode;

        this.FromPort = fromPort;

        this.ToNode = toNode;

        this.ToPort = toPort;
    }

    public bool Equals(Connection obj)
    {
        if (this.FromNode != obj.FromNode) return false;

        if (this.FromPort != obj.FromPort) return false;

        if (this.ToNode != obj.ToNode) return false;

        if (this.ToPort != obj.ToPort) return false;

        return true;
    }
}