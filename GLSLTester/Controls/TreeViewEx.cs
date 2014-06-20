using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GLSLTester.Controls
{
    class TreeViewEx : TreeView
    {
        TreeNode lastSelected = null;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);

            if (!this.DesignMode)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
                {
                    Win32.SetWindowTheme(this.Handle, "explorer", null);
                    this.ShowLines = false;
                    this.Indent = 10;
                    this.ItemHeight = 20;
                }
                else
                {
                    this.ShowLines = true;
                    this.Indent = 19;
                    this.ItemHeight = 16;
                }
            }
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            lastSelected = e.Node;
            base.OnAfterSelect(e);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node is TreeNodeEx && (e.Node as TreeNodeEx).IsSeparator)
            {
                Point startPoint = new Point(e.Bounds.X, e.Bounds.Y + (e.Bounds.Height / 2));
                Point endPoint = new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y + (e.Bounds.Height / 2));
                e.Graphics.DrawLine(SystemPens.InactiveCaption, startPoint, endPoint);
                e.Graphics.DrawLine(Pens.White, new Point(startPoint.X, startPoint.Y + 1), new Point(endPoint.X, endPoint.Y + 1));
            }
            else if (e.Node is TreeNodeEx && !(e.Node as TreeNodeEx).IsSelectable)
            {
                //TODO make grayed out somehow??
                e.DrawDefault = true;
            }
            else
                e.DrawDefault = true;

            base.OnDrawNode(e);
        }

        private TreeNodeEx GetPrevValidNode(TreeNodeEx startNode)
        {
            TreeNodeEx validNode = null;

            if (startNode != null && (startNode.PrevNode is TreeNodeEx))
            {
                if (startNode.IsSelectable)
                    validNode = startNode;
                else if (startNode.IsSeparator || !startNode.IsSelectable)
                    validNode = GetPrevValidNode(startNode.PrevNode as TreeNodeEx);
            }

            return validNode;
        }

        private TreeNodeEx GetNextValidNode(TreeNodeEx startNode)
        {
            TreeNodeEx validNode = null;

            if (startNode != null && (startNode.NextNode is TreeNodeEx))
            {
                if (startNode.IsSelectable)
                    validNode = startNode;
                else if (startNode.IsSeparator || !startNode.IsSelectable)
                    validNode = GetNextValidNode(startNode.NextNode as TreeNodeEx);
            }

            return validNode;
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            if (e.Node is TreeNodeEx && ((e.Node as TreeNodeEx).IsSeparator || !(e.Node as TreeNodeEx).IsSelectable))
            {
                e.Cancel = true;

                if (e.Action == TreeViewAction.ByKeyboard)
                {
                    if (e.Node.NextNode == lastSelected && e.Node.PrevNode is TreeNodeEx)
                    {
                        this.SelectedNode = (GetPrevValidNode(e.Node.PrevNode as TreeNodeEx) as TreeNode);
                    }
                    else if (e.Node.PrevNode == lastSelected && e.Node.NextNode is TreeNodeEx)
                    {
                        this.SelectedNode = (GetNextValidNode(e.Node.NextNode as TreeNodeEx) as TreeNode);
                    }
                }
            }
            else
                base.OnBeforeSelect(e);
        }
    }
}
