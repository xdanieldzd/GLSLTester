using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(2), ExecutionOrderAttribute(int.MaxValue), Serializable()]
    class Object : INode
    {
        Controls.Editors.ObjectEditor editor;

        string defaultName;
        int number;
        Guid guid;

        public string NodeName { get; set; }
        public Objects.IRenderable RenderableObject { get; set; }

        public double RotationX { get; set; }
        public double RotationY { get; set; }
        public double RotationZ { get; set; }
        public bool AutoRotateX { get; set; }
        public bool AutoRotateY { get; set; }
        public bool AutoRotateZ { get; set; }

        public string ObjectPath { get; set; }

        public Object()
        {
            CreateEditorControl();

            defaultName = "objectName";
            AutoSetNodeName(number = 0);

            guid = Guid.NewGuid();

            RenderableObject = (Objects.IRenderable)Activator.CreateInstance(typeof(Objects.Cube), null);

            RotationX = RotationY = RotationZ = 0.0;
            AutoRotateX = false;
            AutoRotateY = true;
            AutoRotateZ = false;

            ObjectPath = string.Empty;
        }

        public Object(System.Xml.XmlElement element)
        {
            CreateEditorControl();

            defaultName = "objectName";
            number = int.Parse(element.GetAttribute("Number"));
            NodeName = element.GetAttribute("NodeName");
            guid = Guid.Parse(element.GetAttribute("Guid"));

            ObjectPath = element.GetAttribute("ObjectPath");

            RotationX = double.Parse(element.GetAttribute("RotationX"));
            RotationY = double.Parse(element.GetAttribute("RotationY"));
            RotationZ = double.Parse(element.GetAttribute("RotationZ"));
            AutoRotateX = bool.Parse(element.GetAttribute("AutoRotateX"));
            AutoRotateY = bool.Parse(element.GetAttribute("AutoRotateY"));
            AutoRotateZ = bool.Parse(element.GetAttribute("AutoRotateZ"));

            Type objectType = Type.GetType(element.GetAttribute("RenderableObject"));
            RequiresPathAttribute reqPathAttrib = (RequiresPathAttribute)Attribute.GetCustomAttribute(objectType, typeof(RequiresPathAttribute));
            if (reqPathAttrib != null && reqPathAttrib.Value == true)
                RenderableObject = (Objects.IRenderable)Activator.CreateInstance(objectType, new object[] { ObjectPath });
            else
                RenderableObject = (Objects.IRenderable)Activator.CreateInstance(objectType, null);
        }

        public Guid GetGuid() { return guid; }

        public void AutoSetNodeName(int number) { this.number = number; NodeName = string.Format("{0}{1}", defaultName, this.number); }
        public string GetNodeTypeName() { return "3D Object"; }
        public string GetDescription() { return "3D object node\nRendered automatically; can also rotate automatically"; }
        public string GetIconKey() { return "BringForwardHS"; }
        public string GetNodeInstanceName() { return NodeName; }

        public void CreateEditorControl() { editor = new Controls.Editors.ObjectEditor() { Dock = System.Windows.Forms.DockStyle.Fill }; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.PushMatrix();

            double rotationIncrement = (Program.Elapsed / 60000.0);

            if (AutoRotateX) GL.Rotate(RotationX += rotationIncrement, OpenTK.Vector3d.UnitX);
            if (AutoRotateY) GL.Rotate(RotationY += rotationIncrement, OpenTK.Vector3d.UnitY);
            if (AutoRotateZ) GL.Rotate(RotationZ += rotationIncrement, OpenTK.Vector3d.UnitZ);

            if (RenderableObject != null) RenderableObject.Render();

            GL.PopMatrix();
        }

        public void StoreSettings(System.Xml.XmlDocument doc)
        {
            System.Xml.XmlElement element = doc.CreateElement(this.GetType().Name);

            element.SetAttribute("Guid", this.guid.ToString());
            element.SetAttribute("NodeName", this.NodeName.ToString());
            element.SetAttribute("Number", this.number.ToString());

            element.SetAttribute("RenderableObject", this.RenderableObject.GetType().FullName);

            element.SetAttribute("RotationX", this.RotationX.ToString());
            element.SetAttribute("RotationY", this.RotationY.ToString());
            element.SetAttribute("RotationZ", this.RotationZ.ToString());
            element.SetAttribute("AutoRotateX", this.AutoRotateX.ToString());
            element.SetAttribute("AutoRotateY", this.AutoRotateY.ToString());
            element.SetAttribute("AutoRotateZ", this.AutoRotateZ.ToString());

            element.SetAttribute("ObjectPath", this.ObjectPath.ToString());

            doc.DocumentElement.AppendChild(element);
        }

        public void Dispose()
        {
            RenderableObject = null;
        }
    }
}
