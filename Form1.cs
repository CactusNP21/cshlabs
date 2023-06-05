using System;
using System.Diagnostics;

namespace LB31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void allProcBtn_Click(object sender, EventArgs e)
        {
            processListView.Items.Clear();

            // �������� �� ������� �������
            Process[] processes = Process.GetProcesses();

            // ������ ����� ������ �� ������
            foreach (Process process in processes)
            {
                // ��������� ����� ������� ������ ��� ������� �������
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.PagedMemorySize64.ToString());
                // ������ ������� �� ������
                processListView.Items.Add(item);
            }
        }

        private void processListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem selectedItem = processListView.FocusedItem;

            int processId = int.Parse(selectedItem.SubItems[1].Text);

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // ������ ����� ���� ��� ��������� ���������� ��� ������
            contextMenu.Items.Add("����� �������: " + selectedItem.SubItems[0].Text);
            contextMenu.Items.Add("������������� �������: " + selectedItem.SubItems[1].Text);
            contextMenu.Items.Add("������� ���'��: " + selectedItem.SubItems[2].Text);

            // ������ ����� ���� ��� ������� �������
            ToolStripMenuItem stopProcessMenuItem = new ToolStripMenuItem("�������� ������");
            stopProcessMenuItem.Click += (s, args) => StopProcess(processId);
            contextMenu.Items.Add(stopProcessMenuItem);

            // ������ ����� ���� ��� ��������� ���������� ��� ������ �������
            ToolStripMenuItem threadsMenuItem = new ToolStripMenuItem("������");
            threadsMenuItem.Click += (s, args) => ShowThreads(processId);
            contextMenu.Items.Add(threadsMenuItem);

            // ������ ����� ���� ��� ��������� ���������� ��� ����� �������
            ToolStripMenuItem modulesMenuItem = new ToolStripMenuItem("�����");
            modulesMenuItem.Click += (s, args) => ShowModules(processId);
            contextMenu.Items.Add(modulesMenuItem);

            contextMenu.Show(Cursor.Position);
        }
        private void StopProcess(int processId)
        {
            try
            {
                // ��������� ������ �� ���������������
                Process process = Process.GetProcessById(processId);

                // ��������� ������
                process.Kill();


            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ��� ������� �������: " + ex.Message);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            processListView.Items.Clear();

            // �������� �� ������� �������
            Process[] processes = Process.GetProcesses();

            // ������ ����� ������ �� ������
            foreach (Process process in processes)
            {
                // ��������� ����� ������� ������ ��� ������� �������
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.PagedMemorySize64.ToString());

                // ������ ������� �� ������
                processListView.Items.Add(item);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("processes.txt");
                {
                    foreach (ListViewItem item in processListView.Items)
                    {
                        string processName = item.SubItems[0].Text;
                        int processId = int.Parse(item.SubItems[1].Text);
                        long memory = long.Parse(item.SubItems[2].Text);

                        writer.WriteLine("����� �������: " + processName);
                        writer.WriteLine("������������� �������: " + processId);
                        writer.WriteLine("������� ���'��: " + memory);
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("������ ������� ������������ �� ����� 'processes.txt'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ��� ������� ������ �������: " + ex.Message);
            }
        }
        private void ShowThreads(int processId)
        {
            try
            {
                // ��������� ������ �� ���������������
                Process process = Process.GetProcessById(processId);

                // �������� ���������� ��� ������ �������
                string threadInfo = "������ ������� (" + process.ProcessName + "):\n\n";
                foreach (ProcessThread thread in process.Threads)
                {
                    threadInfo += "�������������: " + thread.Id + "\n";
                    threadInfo += "����: " + thread.ThreadState + "\n";
                    threadInfo += "��������: " + thread.PriorityLevel + "\n";
                    threadInfo += "---------------------------------------\n";
                }

                MessageBox.Show(threadInfo, "���������� ��� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ��� �������� ���������� ��� ������ �������: " + ex.Message);
            }
        }

        private void ShowModules(int processId)
        {
            try
            {
                // ��������� ������ �� ���������������
                Process process = Process.GetProcessById(processId);

                // �������� ���������� ��� ����� �������
                string moduleInfo = "����� ������� (" + process.ProcessName + "):\n\n";
                foreach (ProcessModule module in process.Modules)
                {
                    moduleInfo += "�����: " + module.ModuleName + "\n";
                    moduleInfo += "����: " + module.FileName + "\n";
                    moduleInfo += "�����: " + module.FileVersionInfo.FileVersion + "\n";
                    moduleInfo += "---------------------------------------\n";
                }

                MessageBox.Show(moduleInfo, "���������� ��� �����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("������� ��� �������� ���������� ��� ����� �������: " + ex.Message);
            }
        }
    }
}