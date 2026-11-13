using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Abibas_New_York_Sport_Original
{
    public partial class OutputOfTheShoeModelCatalog : Form
    {
        public OutputOfTheShoeModelCatalog()
        {
            InitializeComponent();
            //this.MouseWheel += new MouseEventHandler(Form2_MouseWheel);
            this.MouseWheel += Form2_MouseWheel;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_MOUSEWHEEL = 0x020A;

        // Подписываемся на событие прокрутки колесика мыши самой формы
        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {
            // Проверяем, находится ли курсор над нашим контейнером
            if (containerPanel.ClientRectangle.Contains(containerPanel.PointToClient(Cursor.Position)))
            {
                // Передаем команду прокрутки контейнеру
                IntPtr hWnd = containerPanel.Handle;
                SendMessage(hWnd, WM_MOUSEWHEEL, (IntPtr)(e.Delta << 16), IntPtr.Zero);
            }

            
        }

        /*[DllImport("user32.dll")]
        private static extern IntPtr
            SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_MOUSEWHEEL = 0x020A;

        private void Form2_MouseWheel(object sender, MouseEventArgs e)
        {
            if(panel1.ClientRectangle.Contains(panel1.PointToClient(Cursor.Position)))
            {
                IntPtr hWnd = panel1.Handle;
                SendMessage(hWnd, WM_MOUSEWHEEL, (IntPtr)(e.Delta << 16), IntPtr.Zero);
            }
        }

        private void ArrangePanels()
        {
            Panel[] allPanels = { panel1, panel2, panel3 };

            var sortedPanels = allPanels.OrderByDescending(p => GetColorWeight(p.BackColor)).ToList();
            int currentY = 70;
            int margin = 10;

            foreach (var panel in sortedPanels)
            {
                panel.Top = currentY;
                currentY = panel.Height + margin;  
            }
        }

        private int GetColorWeight(Color color)
        {
            if (color == Color.Green) return 3;
            if(color == Color.Red) return 2;
            return 1;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*if(int.TryParse(label16.Text, out int value) && value > 0 && value <= 3)
                panel1.BackColor = Color.Red;
            else if (value <= 0)
                panel1.BackColor = Color.Gray;
            else
                panel1.BackColor = SystemColors.Control;*/

        /* if(int.TryParse(CountProduct1.Text, out int number))
         {
             if (number < 0 && number <= 3)
             {
                 panel1.BackColor = Color.Red;
             }
             else if (number <= 0)
             {
                 panel1.BackColor = Color.Gray;
             }
             else
                 panel1.BackColor = SystemColors.Control;
         }

         ArrangePanels();*/


        /*private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (int.TryParse(CountProduct2.Text, out int number))
            {
                if (number < 0 && number <= 3)
                {
                    panel2.BackColor = Color.Red;
                }
                else if (number <= 0)
                {
                    panel2.BackColor = Color.Gray;
                }
                else
                    panel2.BackColor = SystemColors.Control;
            }

            ArrangePanels();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (int.TryParse(CountProduct3.Text, out int number))
            {
                if (number < 0 && number <= 3)
                {
                    panel3.BackColor = Color.Red;
                }
                else if (number <= 0)
                {
                    panel3.BackColor = Color.Gray;
                }
                else
                    panel3.BackColor = SystemColors.Control;
            }

            ArrangePanels();
        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            panel1.Top = -vScrollBar1.Value;
        }*/


        private void SortPanels()
        {
            List<Panel> panels = new List<Panel> { panel1, panel2, panel3, panel4, panel5, panel6 };

            // 2. Сортируем по числу, которое написано в тексте панели (или в её Label)
            panels.Sort((p1, p2) =>
            {
                // Получаем числа из текста. Если текст не число, считаем его нулем.
                int val1 = GetPanelNumber(p1);
                int val2 = GetPanelNumber(p2);
                
                return val2.CompareTo(val1); // Сортировка по возрастанию
            });

            // 3. Расставляем панели по порядку
            int currentY = 15; // Отступ от верхнего края контейнера
            int margin = 15;   // Расстояние между панелями

            foreach (Panel p in panels)
            {
                p.Top = currentY; // Ставим панель
                p.Left = 250;      // Прижимаем к левому краю

                // Принудительно делаем ширину одинаковой, чтобы красиво смотрелось
                // p.Width = containerPanel.Width - 30; (Раскомментируйте, если нужно)

                currentY += p.Height + margin; // Вычисляем Y для следующей
            }
        }

        // Вспомогательный метод для получения числа из панели
        private int GetPanelNumber(Panel p)
        {
            // Если внутри панели есть Label (например, label1), берем число оттуда:
            // return int.Parse(label1.Text); 

            // Или если вы просто переименовали панели в "1", "2", "3":
            // return int.Parse(p.Text);

            // Универсальный вариант: ищем первый Label внутри панели
            var lbl = p.Controls.OfType<Label>().FirstOrDefault();
            if (lbl != null && int.TryParse(lbl.Text, out int result))
            {
                return result; // Возвращаем найденное число
            }
            return 0; // Если число не нашли, ставим в начало
        }

        private void containerPanel_Paint(object sender, PaintEventArgs e)
        {
            SortPanels();

        }

        private void spacerPanel_Paint(object sender, PaintEventArgs e)
        {
            
                // 1. Собираем панели в список
                List<Panel> panels = new List<Panel> { panel1, panel2, panel3 };

                // 2. Сортируем по убыванию (большие числа наверх)
                panels.Sort((p1, p2) => GetPanelNumber(p2).CompareTo(GetPanelNumber(p1)));

                // 3. Расставляем
                int currentY = 10; // Отступ сверху
                int margin = 15;   // Отступ между панелями

                foreach (Panel p in panels)
                {
                    // Жестко задаем координаты ВНУТРИ containerPanel
                    p.Top = currentY;
                    p.Left = 10;

                    // (Опционально) можно принудительно задать ширину, чтобы не было сюрпризов
                    // p.Width = containerPanel.ClientSize.Width - 30; 

                    currentY += p.Height + margin; // Считаем Y для следующей
                }

                // 4. САМЫЙ ВАЖНЫЙ ШАГ: Управление прокруткой (Спейсер)
                // Если у вас есть пустая панелька внизу (spacerPanel), задаем ей высоту
                // Если её нет, можно обойтись без неё, но тогда AutoScroll может глючить.
                // Вместо спейсера можно просто добавить невидимый Label в самый низ.

                // Если вы добавили spacerPanel внутрь containerPanel:
                // spacerPanel.Top = currentY; // Ставим её после всех панелей
                // spacerPanel.Height = 1; // Она просто нужна как маркер конца

                // Либо просто принудительно обновляем контейнер:
                containerPanel.AutoScrollMinSize = new Size(0, currentY);
            
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Account form3 = new Account();
            form3.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Box form4 = new Box();
            form4.Show();
            this.Hide();
        }
    }
  
}


    
