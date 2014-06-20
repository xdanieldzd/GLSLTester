using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLSLTester
{
    class WorkspaceTreeNodeSorter : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (x as TreeNode);
            TreeNode ty = (y as TreeNode);

            if ((tx.Tag != null && tx.Tag is Nodes.INode) && (ty.Tag != null && ty.Tag is Nodes.INode))
            {
                Nodes.INode nx = (tx.Tag as Nodes.INode);
                Nodes.INode ny = (ty.Tag as Nodes.INode);

                DisplayOrderAttribute orderx = (DisplayOrderAttribute)Attribute.GetCustomAttribute(nx.GetType(), typeof(DisplayOrderAttribute));
                DisplayOrderAttribute ordery = (DisplayOrderAttribute)Attribute.GetCustomAttribute(ny.GetType(), typeof(DisplayOrderAttribute));

                if (orderx.Order < ordery.Order) return -1;
                else if (orderx.Order > ordery.Order) return 1;
                else if (orderx.Order == ordery.Order)
                {
                    return nx.GetNodeInstanceName().CompareTo(ny.GetNodeInstanceName());
                }
            }

            return 0;
        }
    }
}
