using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace TowersWindows
{
    class AnimateView
    {
        public static Panel view;

        // Di chuyển đĩa lên
        public void moveUp(PictureBox Disk, int newY)
        {
            // Bắt đầu di chuyển
            while (Disk.Location.Y > newY)
            {
                Disk.Location = new Point(Disk.Location.X, Disk.Location.Y - 20);  // Tăng tốc độ
                view.Refresh();
                Thread.Sleep(5);  // Giảm thời gian ngủ của thread để tăng tốc độ
            }
        }

        // Di chuyển đĩa xuống 
        public void moveDown(PictureBox Disk, int newY)
        {
            // Bắt đầu di chuyển
            while (Disk.Location.Y < newY)
            {
                Disk.Location = new Point(Disk.Location.X, Disk.Location.Y + 20);  // Tăng tốc độ
                view.Refresh();
                Thread.Sleep(5);  // Giảm thời gian ngủ của thread để tăng tốc độ
            }
        }

        // Di chuyển đĩa sang phải 
        public void moveRight(PictureBox Disk, int newX)
        {
            // bắt đầu di chuyển
            while (Disk.Location.X < newX)
            {
                Disk.Location = new Point(Disk.Location.X + 20, Disk.Location.Y);  // tăng tốc độ 
                view.Refresh();
                Thread.Sleep(5);  // Giảm thời gian ngủ để tăng tốc độ 
            }
        }

        // Di chuyển đĩa sang trái 
        public void moveLeft(PictureBox Disk, int newX)
        {
            // Start moving
            while (Disk.Location.X > newX)
            {
                Disk.Location = new Point(Disk.Location.X - 20, Disk.Location.Y);  // tăng tốc độ
                view.Refresh();
                Thread.Sleep(5);  // Giảm thời gian ngủ để tăng tốc độ
            }
        }
    }
}
