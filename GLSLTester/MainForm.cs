using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

using GLSLTester.Controls;

namespace GLSLTester
{
    public partial class MainForm : Form
    {
        Workspace currentWorkspace;

        public MainForm()
        {
            InitializeComponent();

            glControl1.BackColor = Configuration.BackgroundColor;
            glControl1.VSync = vSyncToolStripMenuItem.Checked = Configuration.VSync;

            treeViewEx1.ImageList = Program.NodeImageList;
            treeViewEx1.TreeViewNodeSorter = new WorkspaceTreeNodeSorter();

            this.Text = string.Format("{0} {1}", Application.ProductName, VersionManagement.CreateVersionString(Application.ProductVersion));

            ofdOpenWorkspace.Filter = sfdSaveWorkspace.Filter = string.Format("{0} Workspace Files (*.xml)|*.xml|All Files (*.*)|*.*", Application.ProductName);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            Program.Stopwatch.Restart();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            Program.Stopwatch.Stop();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            Program.Stopwatch.Stop();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);

            glControl1.SetLightPosition(new float[] { -5.0f, 5.0f, 5.0f, 0.0f });

            //TEST
            //Objects.ColladaDae tmp1 = new ColladaDae(@"E:\Dokumente und Einstellungen\Daniel\Eigene Dateien\aero_model\aero_test.dae");
            //Objects.ColladaDae tmp2 = new ColladaDae(@"E:\- 3DS OoT Hacking -\collada\mjin_okarina_model.dae");
        }

        private void glControl1_Render(object sender, EventArgs e)
        {
            if (!this.ContainsFocus) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(0);

            GL.PushMatrix();
            GL.Translate(0.0, 0.0, -250.0);
            //GL.Scale(0.075, 0.075, 0.075);                          //TEST

            if (currentWorkspace != null) currentWorkspace.ExecuteNodes();

            GL.PopMatrix();

            Program.Stopwatch.Stop();
            Program.Elapsed = Program.Stopwatch.ElapsedTicks;
            tsslStatus.Text = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0.00} FPS", (sender as Aglex.GLControl).FPS);
            Program.Stopwatch.Restart();
        }

        private void newWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentWorkspace != null)
            {
                treeViewEx1.Nodes.Clear();
            }

            currentWorkspace = new Workspace(treeViewEx1);
            currentWorkspace.CreateDefault();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cdlgBackground.Color = glControl1.BackColor;

            if (cdlgBackground.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GL.ClearColor(Configuration.BackgroundColor = glControl1.BackColor = cdlgBackground.Color);
            }
        }

        private void vSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration.VSync = glControl1.VSync = (sender as ToolStripMenuItem).Checked;

            Program.Stopwatch.Restart();
            Program.Elapsed = 0;
        }

        private void openGLInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder oglInfoString = new StringBuilder();

            oglInfoString.AppendFormat("Vendor: {0}\n", Aglex.Toolkit.VendorString);
            oglInfoString.AppendFormat("Renderer: {0}\n", Aglex.Toolkit.RendererString);
            oglInfoString.AppendFormat("Version: {0}\n", Aglex.Toolkit.VersionString);
            oglInfoString.AppendFormat("Shading Language Version: {0}\n", Aglex.Toolkit.ShadingLanguageVersionString);
            oglInfoString.AppendLine();

            oglInfoString.AppendFormat("Max Texture Units: {0}\n", Aglex.Toolkit.GetInteger(GetPName.MaxTextureUnits));
            oglInfoString.AppendFormat("Max Texture Size: {0}\n", Aglex.Toolkit.GetInteger(GetPName.MaxTextureSize));
            oglInfoString.AppendLine();

            oglInfoString.AppendFormat("{0} OpenGL extension(s) supported.\n", Aglex.Toolkit.SupportedExtensions.Length);

            MessageBox.Show(this, oglInfoString.ToString(), (sender as ToolStripMenuItem).Text.Replace("&", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime linkerTimestamp = Program.RetrieveLinkerTimestamp();

            string buildString = string.Format("(Build: {0})", linkerTimestamp.ToString("MM/dd/yyyy HH:mm:ss UTCzzz", System.Globalization.CultureInfo.InvariantCulture));
            string yearString = (linkerTimestamp.Year == 2014 ? "2014" : string.Format("2014-{0}", linkerTimestamp.ToString("yyyy")));

            StringBuilder aboutString = new StringBuilder();

            aboutString.AppendFormat("{0} {1} {2}\n\nWritten {3} by xdaniel / http://magicstone.de/dzd/\n\nOpenTK version: {4}\nHelper ident: {5}",
                Application.ProductName, VersionManagement.CreateVersionString(Application.ProductVersion), buildString, yearString, Aglex.Toolkit.OpenTKVersion, Aglex.Toolkit.GetVersion());

            MessageBox.Show(this, aboutString.ToString(), (sender as ToolStripMenuItem).Text.Replace("&", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeViewEx1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewEx treeView = (sender as TreeViewEx);
            treeView.SelectedNode = treeView.GetNodeAt(e.Location);

            if (e.Button == MouseButtons.Right)
            {
                if (treeView.SelectedNode != null)
                {
                    addNodeToolStripMenuItem.Enabled = (treeView.SelectedNode.Parent == null);
                    editNodeToolStripMenuItem.Enabled = removeNodeToolStripMenuItem.Enabled = (treeView.SelectedNode.Tag != null);
                    cmsNodeMenu.Show(treeView, e.Location);
                }
            }
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AddNodeForm anf = new Forms.AddNodeForm(currentWorkspace.KnownNodes);

            if (anf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentWorkspace.KnownNodes.Add(anf.NewNode);
            }
        }

        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = treeViewEx1.SelectedNode;
            if (treeNode.Tag != null && treeNode.Tag is Nodes.INode) currentWorkspace.KnownNodes.Remove(treeNode.Tag as Nodes.INode);
        }

        private void EditUniformNode()
        {
            if (treeViewEx1.SelectedNode.Tag != null && treeViewEx1.SelectedNode.Tag is Nodes.INode)
            {
                Nodes.INode node = (treeViewEx1.SelectedNode.Tag as Nodes.INode);

                Forms.EditNodeForm enf = new Forms.EditNodeForm(currentWorkspace.KnownNodes, node);

                if (enf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentWorkspace.KnownNodes.Replace(node, enf.EditNode);
                }
            }
        }

        private void editNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUniformNode();
        }

        private void treeViewEx1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            EditUniformNode();
        }

        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdSaveWorkspace.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentWorkspace.Save(sfdSaveWorkspace.FileName);
            }
        }

        private void openWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpenWorkspace.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (currentWorkspace != null) currentWorkspace.Dispose();
                currentWorkspace = new Workspace(treeViewEx1, ofdOpenWorkspace.FileName);
            }
        }
    }
}
