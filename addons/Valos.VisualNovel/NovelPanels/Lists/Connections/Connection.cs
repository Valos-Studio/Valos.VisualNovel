using System.Text;
using Godot;

namespace Valos.VisualNovel.NovelPanels.Lists.Connections;

[Tool]
public partial class Connection : Resource
{
    [Export()]public StringName FromNode { get; set; }
    [Export()]public long FromPort { get; set; }
    [Export()]public StringName ToNode { get; set; }
    [Export()]public long ToPort { get; set; }

    public void AddProperties(StringName fromNode, long fromPort, StringName toNode, long toPort)
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

    public override int GetHashCode()
    {
        return HashCode(this.FromNode, this.FromPort, this.ToNode, this.ToPort);
    }

    public static int HashCode(StringName fromNode, long fromPort, StringName toNode, long toPort)
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(fromNode);
        stringBuilder.Append(fromPort);
        stringBuilder.Append(toNode);
        stringBuilder.Append(toPort);

        string result = stringBuilder.ToString();

        return result.GetHashCode();
    }
}