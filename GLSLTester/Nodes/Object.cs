using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(2), ExecutionOrderAttribute(int.MaxValue)]
    class Object : INode
    {
        string defaultName;
        Controls.Editors.ObjectEditor editor;
        int number;

        public string NodeName { get; set; }
        public Objects.IRenderable RenderableObject { get; set; }
        public double[] Rotation { get; set; }
        public bool[] AutoRotate { get; set; }
        public string ObjectPath { get; set; }

        public Object()
        {
            defaultName = "objectName";
            editor = new Controls.Editors.ObjectEditor() { Dock = System.Windows.Forms.DockStyle.Fill };

            AutoSetNodeName(number = 0);
            RenderableObject = (Objects.IRenderable)Activator.CreateInstance(typeof(Objects.Cube), null);
            Rotation = new double[3] { 0.0, 0.0, 0.0 };
            AutoRotate = new bool[3] { false, true, false };
            ObjectPath = string.Empty;
        }

        public void AutoSetNodeName(int number) { this.number = number; NodeName = string.Format("{0}{1}", defaultName, this.number); }
        public string GetNodeTypeName() { return "3D Object"; }
        public string GetDescription() { return "3D object node\nRendered automatically; can also rotate automatically"; }
        public string GetIconKey() { return "BringForwardHS"; }
        public string GetNodeInstanceName() { return NodeName; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.PushMatrix();

            double rotationIncrement = (Program.Elapsed / 60000.0);

            if (AutoRotate[0]) GL.Rotate(Rotation[0] += rotationIncrement, OpenTK.Vector3d.UnitX);
            if (AutoRotate[1]) GL.Rotate(Rotation[1] += rotationIncrement, OpenTK.Vector3d.UnitY);
            if (AutoRotate[2]) GL.Rotate(Rotation[2] += rotationIncrement, OpenTK.Vector3d.UnitZ);

            if (RenderableObject != null) RenderableObject.Render();

            GL.PopMatrix();
        }

        public void Dispose()
        {
            RenderableObject = null;
        }
    }
}
