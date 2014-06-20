using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLSLTester.Controls
{
    class TreeNodeEx : TreeNode
    {
        bool isSelectable = true;
        public bool IsSelectable { get { return isSelectable; } set { isSelectable = value; } }
        bool isSeparator = false;
        public bool IsSeparator { get { return isSeparator; } set { isSeparator = value; } }

        public TreeNodeEx() : base() { }
        public TreeNodeEx(string text) : base(text) { }
        public TreeNodeEx(string text, TreeNodeEx[] children) : base(text, children) { }
        public TreeNodeEx(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext context) : base(serializationInfo, context) { }
        public TreeNodeEx(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { }
        public TreeNodeEx(string text, int imageIndex, int selectedImageIndex, TreeNodeEx[] children) : base(text, imageIndex, selectedImageIndex, children) { }
    }
}
