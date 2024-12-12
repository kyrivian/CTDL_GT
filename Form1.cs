using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TowersWindows
{
    public partial class Form1 : Form
    {
        private List<string> moves = new List<string>();
        private List<Disks> _TowerDisks = new List<Disks>();
        AnimateView animate = new AnimateView();
        int _DiskCount = 3;
        int diskHeight = 30;
        int baseHeight = 20; // Đế cao 20
        int moveCounter = 1; // Để theo dõi lần di chuyển đĩa 

        public Form1()
        {
            InitializeComponent();
            AnimateView.view = panel1;
            resetPanel();
        }

        private void populateDisks()
        {
            int ii = 1;
            foreach (Disks disk in _TowerDisks)
            {
                PictureBox panelBox = disk.box;
                panelBox.BackColor = colorSelector(disk);
                disk.width = 200 - (20 * ii);
                panelBox.Width = disk.width;
                panelBox.Height = diskHeight;
                panelBox.Tag = disk.DiskNo;
                panelBox.BorderStyle = BorderStyle.FixedSingle;
                Point boxLocation = new Point(getDiskX(disk), (panel1.Height - baseHeight) - (diskHeight * ii++));
                panelBox.Location = boxLocation;
                disk.box = panelBox;
                panel1.Controls.Add(disk.box);
            }
        }

        private int getDiskX(Disks disk)
        {
            int X = 0;
            int Peg = 0;
            switch (disk.peg)
            {
                case 'A': Peg = 1; break;
                case 'B': Peg = 2; break;
                case 'C': Peg = 3; break;
            }
            X = ((panel1.Width / 4) * Peg) - (int)(disk.width / 2);
            return X;
        }

        private void resetPanel()
        {
            setupTower();
            panel1.Controls.Clear();
            _TowerDisks = Enumerable.Range(1, _DiskCount).Select(i => new Disks() { DiskNo = i, peg = 'A', box = new PictureBox() }).OrderByDescending(i => i.DiskNo).ToList();
            populateDisks();
            lblCounter.Text = string.Format("Số lượt đi tối ưu {0}", GetMoveCount(_DiskCount));
        }

        private int getDiskY(Disks disk)
        {
            int Y = 0;
            int stackNo = _TowerDisks.Count(x => x.peg == disk.peg);
            Y = panel1.Height - baseHeight - (diskHeight * stackNo);
            return Y;
        }

        private Color colorSelector(Disks disk)
        {
            switch (disk.DiskNo)
            {
                case 1: return Color.Red;
                case 2: return Color.OrangeRed;
                case 3: return Color.Yellow;
                case 4: return Color.Green;
                case 5: return Color.Blue;
                case 6: return Color.Purple;
                case 7: return Color.LightBlue;
                default: return Color.Black;
            }
        }

        private async void BtnSolve_Click(object sender, EventArgs e)
        {
            resetPanel();
            btnSolve.Enabled = false;
            moves.Clear();
            int NumberOfDisks = _DiskCount;

            // Dùng Task.Run để UI không bị đứng
            await System.Threading.Tasks.Task.Run(() => {
                solveTower(NumberOfDisks);
            });

            btnSolve.Enabled = true;
        }

        private void solveTower(int numberOfDisks)
        {
            char startPeg = 'A';
            char endPeg = 'C';
            char tempPeg = 'B';
            solveTowers(numberOfDisks, startPeg, endPeg, tempPeg);

            // Chúc mừng đã hoàn thành bài 
            AutoCloseMessageBox.Show("Xin chúc mừng, bạn đã hoàn thành bài Tháp Hà Nội", "FINAL");
        }

        private void solveTowers(int n, char startPeg, char endPeg, char tempPeg)
        {
            if (n > 0)
            {
                solveTowers(n - 1, startPeg, tempPeg, endPeg);

                Disks currentDisk = _TowerDisks.Find(x => x.DiskNo == n);
                currentDisk.peg = endPeg;

                // Làm hoạt ảnh cho sự di chuyển đĩa 
                animate.moveUp(currentDisk.box, 20); 
                if (startPeg < endPeg)
                    animate.moveRight(currentDisk.box, getDiskX(currentDisk));
                else
                    animate.moveLeft(currentDisk.box, getDiskX(currentDisk));
                animate.moveDown(currentDisk.box, getDiskY(currentDisk));

                // Format dòng chữ di chuyển đĩa 
                string moveInfo = string.Format("{0}. Di chuyển đĩa {1} từ {2} sang {3}", moveCounter++, n, startPeg, endPeg);

                // Pop up window cho mỗi lần di chuyển
                AutoCloseMessageBox.Show(moveInfo, "Thông tin di chuyển");

                // Thêm lượt di chuyển vào list
                moves.Add(moveInfo);

                // Update list với lượt di chuyển mới nhất
                listMoves.DataSource = null;
                listMoves.DataSource = moves;

                // tiếp tục đệ quy
                solveTowers(n - 1, tempPeg, endPeg, startPeg);
            }
        }

        public static int GetMoveCount(int numberOfDisks)
        {
            double numberOfDisks_Double = numberOfDisks;
            return (int)Math.Pow(2.0, numberOfDisks_Double) - 1;
        }

        private void DiskCount_ValueChanged(object sender, EventArgs e)
        {
            _DiskCount = (int)DiskCount.Value;
            resetPanel();
        }

        private void setupTower()
        {
            panel1.Paint += delegate
            {
                setBase();
            };
        }

        private void setBase()
        {
            Graphics g = panel1.CreateGraphics();
            int topSpacing = 100; // Khoảng cách từ đỉnh panel đến đỉnh cột
            int pegWidth = 30;    // Độ rộng của cột
            SolidBrush baseBrush = new SolidBrush(Color.PaleVioletRed);    // Màu của thanh ngang (base)
            SolidBrush pegBrush1 = new SolidBrush(Color.Crimson);      // Màu cột A
            SolidBrush pegBrush2 = new SolidBrush(Color.MediumSeaGreen); // Màu cột B
            SolidBrush pegBrush3 = new SolidBrush(Color.DodgerBlue);   // Màu cột C

            // Vẽ thanh ngang (base)
            g.FillRectangle(baseBrush, 0, panel1.Height - baseHeight, panel1.Width, baseHeight);

            // Tính toán vị trí các cột để căn đều
            int panelWidth = panel1.Width;
            int pegXOffset = panelWidth / 4;

            // Vẽ các cột với khoảng cách đều nhau và màu sắc dễ nhìn
            drawPeg(g, pegBrush1, pegXOffset * 1, pegWidth, topSpacing); // Cột A
            drawPeg(g, pegBrush2, pegXOffset * 2, pegWidth, topSpacing); // Cột B
            drawPeg(g, pegBrush3, pegXOffset * 3, pegWidth, topSpacing); // Cột C
        }

        private void drawPeg(Graphics g, SolidBrush brush, int pegXCenter, int pegWidth, int topSpacing)
        {
            int pegHeight = panel1.Height - topSpacing - baseHeight; // Chiều cao của cột
            g.FillRectangle(brush, pegXCenter - (pegWidth / 2), topSpacing, pegWidth, pegHeight);
        }

        private void BtnStartOver_Click(object sender, EventArgs e)
        {
            // Reset mọi thứ về trạng thái ban đầu 
            moveCounter = 1;  // Reset dòng đếm lượt di chuyển
            moves.Clear();    // Xóa hết danh sách các lượt di chuyển
            listMoves.DataSource = null; // Clear the moves list view

            // Reset các đĩa và UI về trạng thái ban đầu
            resetPanel();
            btnSolve.Enabled = true;  //Enable nút Solve trở lại
        }

        private void lblMoves_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCounter_Click(object sender, EventArgs e)
        {

        }
    }

    public class AutoCloseMessageBox
    {
        private static System.Windows.Forms.Timer timer;
        private static Form msg;

        public static void Show(string text, string caption)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // bảng popup sẽ tự đóng sau 1 giây
            timer.Tick += Timer_Tick;

            msg = new Form();
            msg.Height = 0;
            msg.Width = 0;
            msg.StartPosition = FormStartPosition.Manual;
            msg.Location = new Point(-2000, -2000);
            msg.Show();
            msg.Hide();
            timer.Start();

            // Hiện bảng thông báo với thông tin lượt di chuyển
            MessageBox.Show(msg, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            msg.DialogResult = DialogResult.OK;
            msg.Close();
            timer.Dispose();
            msg.Dispose();
        }
    }
}
