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

            // Отримуємо всі запущені процеси
            Process[] processes = Process.GetProcesses();

            // Додаємо кожен процес до списку
            foreach (Process process in processes)
            {
                // Створюємо новий елемент списку для кожного процесу
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.PagedMemorySize64.ToString());
                // Додаємо елемент до списку
                processListView.Items.Add(item);
            }
        }

        private void processListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem selectedItem = processListView.FocusedItem;

            int processId = int.Parse(selectedItem.SubItems[1].Text);

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Додаємо пункт меню для виведення інформації про процес
            contextMenu.Items.Add("Назва процесу: " + selectedItem.SubItems[0].Text);
            contextMenu.Items.Add("Ідентифікатор процесу: " + selectedItem.SubItems[1].Text);
            contextMenu.Items.Add("Виділено пам'яті: " + selectedItem.SubItems[2].Text);

            // Додаємо пункт меню для зупинки процесу
            ToolStripMenuItem stopProcessMenuItem = new ToolStripMenuItem("Зупинити процес");
            stopProcessMenuItem.Click += (s, args) => StopProcess(processId);
            contextMenu.Items.Add(stopProcessMenuItem);

            // Додаємо пункт меню для виведення інформації про потоки процесу
            ToolStripMenuItem threadsMenuItem = new ToolStripMenuItem("Потоки");
            threadsMenuItem.Click += (s, args) => ShowThreads(processId);
            contextMenu.Items.Add(threadsMenuItem);

            // Додаємо пункт меню для виведення інформації про модулі процесу
            ToolStripMenuItem modulesMenuItem = new ToolStripMenuItem("Модулі");
            modulesMenuItem.Click += (s, args) => ShowModules(processId);
            contextMenu.Items.Add(modulesMenuItem);

            contextMenu.Show(Cursor.Position);
        }
        private void StopProcess(int processId)
        {
            try
            {
                // Знаходимо процес за ідентифікатором
                Process process = Process.GetProcessById(processId);

                // Зупиняємо процес
                process.Kill();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при зупинці процесу: " + ex.Message);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            processListView.Items.Clear();

            // Отримуємо всі запущені процеси
            Process[] processes = Process.GetProcesses();

            // Додаємо кожен процес до списку
            foreach (Process process in processes)
            {
                // Створюємо новий елемент списку для кожного процесу
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.PagedMemorySize64.ToString());

                // Додаємо елемент до списку
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

                        writer.WriteLine("Назва процесу: " + processName);
                        writer.WriteLine("Ідентифікатор процесу: " + processId);
                        writer.WriteLine("Виділено пам'яті: " + memory);
                        writer.WriteLine();
                    }
                }

                MessageBox.Show("Список процесів експортовано до файлу 'processes.txt'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при експорті списку процесів: " + ex.Message);
            }
        }
        private void ShowThreads(int processId)
        {
            try
            {
                // Знаходимо процес за ідентифікатором
                Process process = Process.GetProcessById(processId);

                // Виводимо інформацію про потоки процесу
                string threadInfo = "Потоки процесу (" + process.ProcessName + "):\n\n";
                foreach (ProcessThread thread in process.Threads)
                {
                    threadInfo += "Ідентифікатор: " + thread.Id + "\n";
                    threadInfo += "Стан: " + thread.ThreadState + "\n";
                    threadInfo += "Пріоритет: " + thread.PriorityLevel + "\n";
                    threadInfo += "---------------------------------------\n";
                }

                MessageBox.Show(threadInfo, "Інформація про потоки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні інформації про потоки процесу: " + ex.Message);
            }
        }

        private void ShowModules(int processId)
        {
            try
            {
                // Знаходимо процес за ідентифікатором
                Process process = Process.GetProcessById(processId);

                // Виводимо інформацію про модулі процесу
                string moduleInfo = "Модулі процесу (" + process.ProcessName + "):\n\n";
                foreach (ProcessModule module in process.Modules)
                {
                    moduleInfo += "Назва: " + module.ModuleName + "\n";
                    moduleInfo += "Шлях: " + module.FileName + "\n";
                    moduleInfo += "Версія: " + module.FileVersionInfo.FileVersion + "\n";
                    moduleInfo += "---------------------------------------\n";
                }

                MessageBox.Show(moduleInfo, "Інформація про модулі", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні інформації про модулі процесу: " + ex.Message);
            }
        }
    }
}