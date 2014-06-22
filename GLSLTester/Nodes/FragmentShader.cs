﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(1), ExecutionOrderAttribute(int.MinValue), IsNextSeparatorAttribute(true), Serializable()]
    class FragmentShader : Shims.ShaderShim, INode
    {
        [NonSerialized()]
        Controls.Editors.ShaderEditor editor;

        public FragmentShader()
        {
            CreateEditorControl();

            ShaderType = OpenTK.Graphics.OpenGL.ShaderType.FragmentShader;
            ShaderString = (DefaultShaderStrings = GLSL.DefaultFragmentShaders)["Default"];

            GLSL.CompileShader(ShaderType, ShaderString);
        }

        public void AutoSetNodeName(int number) { /* Not used */ }
        public string GetNodeTypeName() { return "Fragment Shader"; }
        public string GetDescription() { return "GLSL fragment shader"; }
        public string GetIconKey() { return "EditCodeHS"; }
        public string GetNodeInstanceName() { return string.Empty; }

        public void CreateEditorControl() { editor = new Controls.Editors.ShaderEditor() { Dock = System.Windows.Forms.DockStyle.Fill }; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.UseProgram(GLSL.ShaderProgramID);
        }

        public void Dispose()
        {
            GLSL.DeleteShader(OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);
        }
    }
}
