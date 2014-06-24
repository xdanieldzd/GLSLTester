using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using FastColoredTextBoxNS;

namespace GLSLTester.Controls.Editors
{
    internal partial class ShaderEditor : UserControl, IEditorControl
    {
        Shims.ShaderShim parentNode;
        Shims.ShaderShim originalNode;
        List<Nodes.INode> knownNodes;

        static TextStyle styleComments, styleNumbers, styleKeywords1, styleKeywords2, styleKeywords3, styleKeywords4, styleKeywords5, styleKeywords6;

        static ShaderEditor()
        {
            styleComments = new TextStyle(new SolidBrush(Color.FromArgb(0x00, 0x80, 0x40)), null, FontStyle.Regular);
            styleNumbers = new TextStyle(new SolidBrush(Color.FromArgb(0x80, 0x00, 0xFF)), null, FontStyle.Regular);
            styleKeywords1 = new TextStyle(new SolidBrush(Color.FromArgb(0x00, 0x80, 0xFF)), null, FontStyle.Regular);
            styleKeywords2 = new TextStyle(new SolidBrush(Color.FromArgb(0x40, 0x80, 0x80)), null, FontStyle.Regular);
            styleKeywords3 = new TextStyle(new SolidBrush(Color.FromArgb(0xC4, 0x62, 0x00)), null, FontStyle.Regular);
            styleKeywords4 = new TextStyle(new SolidBrush(Color.FromArgb(0x80, 0x80, 0xFF)), null, FontStyle.Regular);
            styleKeywords5 = new TextStyle(new SolidBrush(Color.FromArgb(0x00, 0x00, 0x00)), null, FontStyle.Regular);
            styleKeywords6 = new TextStyle(new SolidBrush(Color.FromArgb(0xFF, 0x80, 0x40)), null, FontStyle.Regular);
        }

        public ShaderEditor()
        {
            InitializeComponent();

            ofdShaderFile.Filter = sfdShaderFile.Filter = "GLSL Shader Files (*.vs;*.fs;*.vert;*.frag;*.glsl)|*.vs;*.fs;*.vert;*.frag;*.glsl|All Files (*.*)|*.*";
        }

        public void Initialize(Nodes.INode parentNode, List<Nodes.INode> knownNodes)
        {
            this.parentNode = parentNode as Shims.ShaderShim;
            this.originalNode = this.parentNode.Clone<Shims.ShaderShim>();
            this.knownNodes = knownNodes;

            this.fctbShader.Text = this.parentNode.ShaderString;

            this.cmsDefaultShaders.Items.Clear();
            foreach (KeyValuePair<string, string> shaderEntry in this.parentNode.DefaultShaderStrings)
            {
                ToolStripMenuItem shaderMenuItem = new ToolStripMenuItem(shaderEntry.Key) { Tag = shaderEntry.Value };
                shaderMenuItem.Click += ((s, e) =>
                {
                    if ((s as ToolStripMenuItem).Tag != null)
                    {
                        string shaderString = ((s as ToolStripMenuItem).Tag as string);
                        this.fctbShader.Text = shaderString;
                        this.Validate();
                    }
                });
                this.cmsDefaultShaders.Items.Add(shaderMenuItem);
            }
        }

        private void fctbShader_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            if (this.parentNode == null) return;

            FastColoredTextBoxNS.FastColoredTextBox fctb = (sender as FastColoredTextBoxNS.FastColoredTextBox);
            TextBoxApplyStyles(fctb, e);

            this.parentNode.ShaderString = fctb.Text;
            this.Validate();
        }

        private void btnOpenShader_Click(object sender, EventArgs e)
        {
            if (ofdShaderFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(ofdShaderFile.FileName);
                this.fctbShader.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void btnSaveShader_Click(object sender, EventArgs e)
        {
            if (sfdShaderFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(sfdShaderFile.FileName);
                sw.Write(this.fctbShader.Text);
                sw.Close();
            }
        }

        private void btnSetToDefaultShader_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);

            Point menuLocation = this.PointToScreen(button.Location);
            if (button.ClientRectangle.Contains(button.PointToClient(Cursor.Position))) menuLocation = Cursor.Position;

            this.cmsDefaultShaders.Show(menuLocation);
        }

        private bool AreEditsValid()
        {
            if (knownNodes == null) return true;

            // validation?

            return true;
        }

        private void fctbShader_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();

            if (!e.Cancel && this.ParentForm != null && this.ParentForm.DialogResult == DialogResult.OK)
            {
                e.Cancel = !GLSL.CompileShader(this.parentNode.ShaderType, this.parentNode.ShaderString);
            }
            else if (this.ParentForm.DialogResult == DialogResult.Cancel)
            {
                GLSL.CompileShader(this.parentNode.ShaderType, this.parentNode.ShaderString);
            }
        }

        private void TextBoxApplyStyles(FastColoredTextBox fctb, TextChangedEventArgs e)
        {
            fctb.LeftBracket = '(';
            fctb.RightBracket = ')';
            fctb.LeftBracket2 = '\x0';
            fctb.RightBracket2 = '\x0';

            e.ChangedRange.ClearStyle(styleNumbers, styleComments, styleKeywords1, styleKeywords2, styleKeywords3, styleKeywords4, styleKeywords5, styleKeywords6);

            e.ChangedRange.SetStyle(styleComments, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(styleComments, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(styleComments, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);

            e.ChangedRange.SetStyle(styleNumbers, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");

            e.ChangedRange.SetStyle(styleKeywords3,
                @"\s*#\b(define|undef|if|ifdef|ifndef|else|elif|endif|error|pragma|extension |version |line)\b");

            e.ChangedRange.SetStyle(styleKeywords1,
                @"\b(attribute|const|uniform|varying|buffer|shared|coherent|volatile|restrict|readonly|writeonly|struct|layout|centroid|flat|smooth|noperspective|patch|sample|break|continue|do|for|while|switch|case|default|if|else|subroutine|in|out|inout|true|false|invariant|discard|return|lowp|mediump|highp|precision)\b");

            e.ChangedRange.SetStyle(styleKeywords2,
                @"\b(sampler1D|sampler2D|sampler3D|samplerCube|sampler1DShadow|sampler2DShadow|samplerCubeShadow|sampler1DArray|sampler2DArray|sampler1DArrayShadow|sampler2DArrayShadow|isampler1D|isampler2D|isampler3D|isamplerCube|isampler1DArray|isampler2DArray|usampler1D|usampler2D|usampler3D|usamplerCube|usampler1DArray|usampler2DArray|sampler2DRect|sampler2DRectShadow|isampler2DRect|usampler2DRect|samplerBuffer|isamplerBuffer|usamplerBuffer|sampler2DMS|isampler2DMS|usampler2DMS|sampler2DMSArray|isampler2DMSArray|usampler2DMSArray|samplerCubeArray|samplerCubeArrayShadow|isamplerCubeArray|usamplerCubeArray|image1D|iimage1D|uimage1D|image2D|iimage2D|uimage2D|image3D|iimage3D|uimage3D|image2DRect|iimage2DRect|uimage2DRect|imageCube|iimageCube|uimageCube|imageBuffer|iimageBuffer|uimageBuffer|image1DArray|iimage1DArray|uimage1DArray|image2DArray|iimage2DArray|uimage2DArray|imageCubeArray|iimageCubeArray|uimageCubeArray|image2DMS|iimage2DMS|uimage2DMS|image2DMSArray|iimage2DMSArray|uimage2DMSArray|atomic_uint|mat2|mat3|mat4|dmat2|dmat3|dmat4|mat2x2|mat2x3|mat2x4|dmat2x2|dmat2x3|dmat2x4|mat3x2|mat3x3|mat3x4|dmat3x2|dmat3x3|dmat3x4|mat4x2|mat4x3|mat4x4|dmat4x2|dmat4x3|dmat4x4|vec2|vec3|vec4|ivec2|ivec3|ivec4|bvec2|bvec3|bvec4|dvec2|dvec3|dvec4|float|double|int|void|bool|uint|uvec2|uvec3|uvec4)\b");

            e.ChangedRange.SetStyle(styleKeywords4,
                @"\b(gl_NumWorkGroups|gl_WorkGroupSize|gl_WorkGroupID|gl_LocalInvocationID|gl_GlobalInvocationID|gl_LocalInvocationIndex|gl_VertexID|gl_InstanceID|gl_PerVertex|gl_Position|gl_PointSize|gl_ClipDistance|gl_in|gl_PrimitiveIDIn|gl_InvocationID|gl_Layer|gl_ViewportIndex|gl_PatchVerticesIn|gl_InvocationID|gl_out|gl_TessLevelOuter|gl_TessLevelInner|gl_PatchVerticesIn|gl_PrimitiveID|gl_TessCoord|gl_FragCoord|gl_FrontFacing|gl_ClipDistance|gl_PointCoord|gl_PrimitiveID|gl_SampleID|gl_SamplePosition|gl_SampleMaskIn|gl_Layer|gl_ViewportIndex|gl_FragDepth|gl_SampleMask)\b");

            e.ChangedRange.SetStyle(styleKeywords5,
                @"\b(gl_MaxComputeWorkGroupCount|gl_MaxComputeWorkGroupSize|gl_MaxComputeUniformComponents|gl_MaxComputeTextureImageUnits|gl_MaxComputeImageUniforms|gl_MaxComputeAtomicCounters|gl_MaxComputeAtomicCounterBuffers|gl_MaxVertexAttribs|gl_MaxVertexUniformComponents|gl_MaxVaryingComponents|gl_MaxVertexOutputComponents|gl_MaxGeometryInputComponents|gl_MaxGeometryOutputComponents|gl_MaxFragmentInputComponents|gl_MaxVertexTextureImageUnits|gl_MaxCombinedTextureImageUnits|gl_MaxTextureImageUnits|gl_MaxImageUnits|gl_MaxCombinedImageUnitsAndFragmentOutputs|gl_MaxImageSamples|gl_MaxVertexImageUniforms|gl_MaxTessControlImageUniforms|gl_MaxTessEvaluationImageUniforms|gl_MaxGeometryImageUniforms|gl_MaxFragmentImageUniforms|gl_MaxCombinedImageUniforms|gl_MaxFragmentUniformComponents|gl_MaxDrawBuffers|gl_MaxClipDistances|gl_MaxGeometryTextureImageUnits|gl_MaxGeometryOutputVertices|gl_MaxGeometryTotalOutputComponents|gl_MaxGeometryUniformComponents|gl_MaxGeometryVaryingComponents|gl_MaxTessControlInputComponents|gl_MaxTessControlOutputComponents|gl_MaxTessControlTextureImageUnits|gl_MaxTessControlUniformComponents|gl_MaxTessControlTotalOutputComponents|gl_MaxTessEvaluationInputComponents|gl_MaxTessEvaluationOutputComponents|gl_MaxTessEvaluationTextureImageUnits|gl_MaxTessEvaluationUniformComponents|gl_MaxTessPatchComponents|gl_MaxPatchVertices|gl_MaxTessGenLevel|gl_MaxViewports|gl_MaxVertexUniformVectors|gl_MaxFragmentUniformVectors|gl_MaxVaryingVectors|gl_MaxVertexAtomicCounters|gl_MaxTessControlAtomicCounters|gl_MaxTessEvaluationAtomicCounters|gl_MaxGeometryAtomicCounters|gl_MaxFragmentAtomicCounters|gl_MaxCombinedAtomicCounters|gl_MaxAtomicCounterBindings|gl_MaxVertexAtomicCounterBuffers|gl_MaxTessControlAtomicCounterBuffers|gl_MaxTessEvaluationAtomicCounterBuffers|gl_MaxGeometryAtomicCounterBuffers|gl_MaxFragmentAtomicCounterBuffers|gl_MaxCombinedAtomicCounterBuffers|gl_MaxAtomicCounterBufferSize|gl_MinProgramTexelOffset|gl_MaxProgramTexelOffset)\b");

            e.ChangedRange.SetStyle(styleKeywords6,
                @"\b(radians|degrees|sin|cos|tan|asin|acos|atan|sinh|cosh|tanh|asinh|acosh|atanh|pow|exp|log|exp2|log2|sqrt|inversqrt|abs|sign|floor|trunc|round|roundEven|ceil|fract|mod|modf|min|max|clamp|mix|step|smoothstep|isnan|isinf|floatBitsToInt|floatBitsToUInt|intBitsToFloat|uintBitsToFloat|fma|frexp|ldexp|packUnorm2x16|packSnorm2x16|packUnorm4x8|packSnorm4x8|unpackUnorm2x16|unpackSnorm2x16|unpackUnorm4x8|unpackSnorm4x8|packDouble2x32|unpackDouble2x32|packHalf2x16|unpackHalf2x16|length|distance|dot|cross|normalize|faceforward|reflect|refract|matrixCompMult|outerProduct|transpose|determinant|inverse|lessThan|lessThanEqual|greaterThan|greaterThanEqual|equal|notEqual|any|all|not|uaddCarry|usubBorrow|umulExtended|imulExtended|bitfieldExtract|bitfieldInsert|bitfieldReverse|findLSB|bitCount|findMSB|textureSize|textureQueryLod|textureQueryLevels|texture|textureProj|textureLod|textureOffset|texelFetch|texelFetchOffset|textureProjOffset|textureLodOffset|textureProjLod|textureProjLodOffset|textureGrad|textureGradOffset|textureProjGrad|textureProjGradOffset|textureGather|textureGatherOffset|textureGatherOffsets|texture1D|texture1DProj|texture1DLod|texture1DProjLod|texture2D|texture2DProj|texture2DLod|texture2DProjLod|texture3D|texture3DProj|texture3DLod|texture3DProjLod|textureCube|textureCubeLod|shadow1D|shadow2D|shadow1DProj|shadow2DProj|shadow1DLod|shadow2DLod|shadow1DProjLod|shadow2DProjLod|atomicCounterIncrement|atomicCounterDecrement|atomicCounter|atomicAdd|atomicMin|atomicMax|atomicAnd|atomicOr|atomicXor|atomicExchange|atomicCompSwap|imageSize|imageLoad|imageStore|imageAtomicAdd|imageAtomicMin|imageAtomicMax|imageAtomicAnd|imageAtomicOr|imageAtomicXor|imageAtomicExchange|imageAtomicCompSwap|dFdx|dFdy|fwidth|interpolateAtCentroid|interpolateAtSample|interpolateAtOffset|noise1|noise2|noise3|noise4|EmitStreamVertex|EndStreamPrimitive|EmitVertex|EndPrimitive|barrier|memoryBarrier|memoryBarrierAtomicCounter|memoryBarrierBuffer|memoryBarrierShared|memoryBarrierImage|groupMemoryBarrier)\b");

            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");
        }
    }
}
