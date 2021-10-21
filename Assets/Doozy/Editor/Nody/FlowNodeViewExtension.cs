// Copyright (c) 2015 - 2021 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using Doozy.Runtime.Nody;
namespace Doozy.Editor.Nody
{
    public partial class FlowNodeView
    {
        public static FlowNodeView GetView(FlowGraphView graphView, FlowNode node)
        {
            switch (node)
            {
                case Doozy.Runtime.UIManager.Nodes.BackButtonNode _:
                    return new Doozy.Editor.UIManager.Nodes.BackButtonNodeView(graphView, node);
                case Doozy.Runtime.UIManager.Nodes.PortalNode _:
                    return new Doozy.Editor.UIManager.Nodes.PortalNodeView(graphView, node);
                case Doozy.Runtime.UIManager.Nodes.SignalNode _:
                    return new Doozy.Editor.UIManager.Nodes.SignalNodeView(graphView, node);
                case Doozy.Runtime.UIManager.Nodes.UINode _:
                    return new Doozy.Editor.UIManager.Nodes.UINodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.ApplicationQuitNode _:
                    return new Doozy.Editor.Nody.Nodes.ApplicationQuitNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.DebugNode _:
                    return new Doozy.Editor.Nody.Nodes.DebugNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.PivotNode _:
                    return new Doozy.Editor.Nody.Nodes.PivotNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.RandomNode _:
                    return new Doozy.Editor.Nody.Nodes.RandomNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.StickyNoteNode _:
                    return new Doozy.Editor.Nody.Nodes.StickyNoteNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.TimeScaleNode _:
                    return new Doozy.Editor.Nody.Nodes.TimeScaleNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.System.EnterNode _:
                    return new Doozy.Editor.Nody.Nodes.EnterNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.System.ExitNode _:
                    return new Doozy.Editor.Nody.Nodes.ExitNodeView(graphView, node);
                case Doozy.Runtime.Nody.Nodes.System.StartNode _:
                    return new Doozy.Editor.Nody.Nodes.StartNodeView(graphView, node);
                default:
                    return new FlowNodeView(graphView, node);
            }
        }
    }
}