using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class VideoPopup : Form
    {
        private PictureBox pictureBox;

        public VideoPopup()
        {
            this.pictureBox = new PictureBox();
            this.pictureBox.Dock = DockStyle.Fill;
            this.Controls.Add(this.pictureBox);
        }

        public void UpdateImage(Image image)
        {
            if (this.pictureBox.InvokeRequired)
            {
                this.pictureBox.Invoke(new Action(() => this.pictureBox.Image = image));
            }
            else
            {
                this.pictureBox.Image = image;
            }
        }
    }
}
