using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ZEYNEP ERMAN
// 180101014
namespace mayınTarlası
{
    public partial class Form1 : Form
    {
        Button[,] buttons;
        int numberOfFlags = 0;
        int for_minute = 0, for_second = 0;
        int width, height, nBombs, numberToWrite = 0;
        PictureBox game = new PictureBox();
        PictureBox fail = new PictureBox();
        PictureBox win = new PictureBox();
        Panel panel = new Panel();
        Label label_flag = new Label();
        Label timer_second = new Label();
        Label timer_minute = new Label();
        public Form1()
        {
            InitializeComponent();
        }
        public int Width_
        {
            get { return width; }
            set
            {
                width = Math.Abs(value);
                if (width < 7)
                {
                    width = 7;
                    textBoxWidth.Text = "7";
                }
            }
        }
        public int Height_ { get { return height; } set { height = Math.Abs(value); } }
        public int nBombs_ { get { return nBombs; } set { nBombs = Math.Abs(value); } }

        private void buttonUpdatee_Click(object sender, EventArgs e)
        {
            Width_ = Convert.ToInt32(textBoxWidth.Text);
            Height_ = Convert.ToInt32(textBoxHeight.Text);
            nBombs_ = Convert.ToInt32(textBoxMines.Text);
            buttons = new Button[Height_, Width_];
            groupBoxBoard.Controls.Clear();

            numberOfFlags = 0;

            if (nBombs < Width_ * Height_)
            {
                game_board();
                FormReScale();
                PlaceTheBombs(nBombs_, Width_, Height_);
                LabelTheRest(Width_, Height_);
            }
            else
            {
                MessageBox.Show("Mayın sayısı buton sayısından fazla olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for_minute = 0;
            for_second = 0;
        }

        public void game_board()
        {
            //bulunmayı bekleyen mayın sayısı için
            Point for_label_flag = new Point(60, 15);
            label_flag.Location = new Point(15, 30);
            label_flag.Size = new Size(for_label_flag);
            label_flag.Text = textBoxMines.Text;
            label_flag.BackColor = Color.DarkGray;
            groupBoxBoard.Controls.Add(label_flag);
            label_flag.Text = "Mİne:" + nBombs_.ToString();

            //saniye ve dakika için
            Point for_timer_second = new Point(25, 15);
            timer_second.Location = new Point(Width_ * 22 - 10, 30);
            timer_second.Size = new Size(for_timer_second);
            timer_second.BackColor = Color.DarkGray;
            groupBoxBoard.Controls.Add(timer_second);

            Point for_timer_minute = new Point(30, 15);
            timer_minute.Location = new Point((Width_ * 22) - 22, 30);
            timer_minute.Size = new Size(for_timer_minute);
            timer_minute.BackColor = Color.DarkGray;
            groupBoxBoard.Controls.Add(timer_minute);
            
            //oyun sırasında açık kalacak emoji
            game.Image = mayınTarlası.Properties.Resources.thinking_emoji;
            game.SetBounds(Width_ * 11, 12, 42, 42);
            game.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            game.Click += buttonUpdatee_Click;
            groupBoxBoard.Controls.Add(game);
            game.Show();
            add_panel();
            for (int i = 0; i < Height_; i++)
            {
                for (int j = 0; j < Width_; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(15 + j * 22, 56 + i * 22);
                    buttons[i, j].Size = new Size(20, 20);
                    buttons[i, j].Click += ButtonClicked;
                    buttons[i, j].MouseUp += Button_MouseUp;
                    buttons[i, j].Tag = "";

                    var mine = new MineBox();
                    mine.position = new Point(i, j);
                    mine.button = buttons[i, j];
                    buttons[i, j].Tag = mine;

                    groupBoxBoard.Controls.Add(buttons[i, j]);
                }
            }

            Point groupBoxBorder = new Point(buttons[Height_ - 1, Width_ - 1].Location.X + 37, buttons[Height_ - 1, Width_ - 1].Location.Y + 22);
            groupBoxBoard.Size = new Size(groupBoxBorder);
            timer1.Start();
        }

        public void game_over()
        {
            game.Hide();
            fail.Image = mayınTarlası.Properties.Resources.loser_emoji;
            fail.SetBounds(Width_ * 11, 12, 46, 42);
            fail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            fail.Click += buttonUpdatee_Click;
            groupBoxBoard.Controls.Add(fail);
            add_panel();
            for (int i = 0; i < Height_; i++)
            {
                for (int j = 0; j < Width_; j++)
                {
                    //burada button.tag'daki mineboxu almalıyız
                    MineBox mine = buttons[i, j].Tag as MineBox;

                    buttons[i, j].Enabled = false;

                    //eğer buttondaki kutu bombaysa
                    if (mine.isbomb)
                    {
                        timer1.Stop();
                        buttons[i, j].BackgroundImage = mayınTarlası.Properties.Resources.mine;
                        buttons[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //kutu bayraklanmış fakat bomba değilse
                    if (mine.flag && !mine.isbomb)
                    {
                        buttons[i, j].BackgroundImage = mayınTarlası.Properties.Resources.çarpı;
                    }
                }
            }
        }
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = ((Button)sender);
            MineBox minebox = btn.Tag as MineBox;
            if (e.Button == MouseButtons.Right)
            {
                if (btn.BackgroundImage == null)
                {
                    if (!minebox.flag)
                    {
                        if (numberOfFlags < Convert.ToInt32(textBoxMines.Text))
                        {
                            minebox.flag = true;
                            btn.BackgroundImage = mayınTarlası.Properties.Resources.flag;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            numberOfFlags++;
                            nBombs_ -= 1;
                            label_flag.Text = "Mİne:" + nBombs_.ToString();
                        }   
                    }
                    if (numberOfFlags == Convert.ToInt32(textBoxMines.Text))
                    {
                        game.Hide();
                        win.Image = mayınTarlası.Properties.Resources.win_emoji;
                        win.SetBounds(Width_ * 11, 12, 42, 42);
                        win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        win.Click += buttonUpdatee_Click;
                        groupBoxBoard.Controls.Add(win);

                        add_panel();
                        game_over();
                        MessageBox.Show("Tebrikler kazandınız...", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    minebox.flag = false;

                    btn.BackgroundImage = null;
                    numberOfFlags--;
                    nBombs += 1;
                    label_flag.Text = "Mİne:" + nBombs_.ToString();
                }
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            MineBox mine = btn.Tag as MineBox;
            //bayraklı ise geri dönüyoruz açmıyoruz
            if (mine.flag)
                return;

            btn.Enabled = false;
            this.Focus();

            //eğer mayınsa
            if (mine.isbomb)
            {
                btn.BackgroundImage = mayınTarlası.Properties.Resources.mine;
                btn.BackgroundImageLayout = ImageLayout.Stretch;

                game_over();
                MessageBox.Show("Kaybettin...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //burada kutuyu açıyoruz.
                OpenBox(btn.Tag as MineBox);
                btn.MouseUp += ButtonClicked;
            }
        }
        
        private void OpenBox(MineBox minebox)
        {
            //daha önce açmışsak  geri dönüyoruz.
            if (minebox.open)
                return;

            //açılmamış ve 0 sa etrafındakilerde açar
            if (minebox.minecount == 0)
            {
                minebox.button.Enabled = false;
                minebox.open = true;
                var etraf = EtrafMayin(minebox);
                foreach (var mine in etraf)
                {
                    OpenBox(mine);
                }
            }
            else
            {
                minebox.button.Text = minebox.minecount.ToString();
                minebox.button.Enabled = false;
            }
        }

        // bir kutuyu alır ve atrafındaki kutuları dönderir.
        private List<MineBox> EtrafMayin(MineBox minebox)
        {
            var etrafindakiler = new List<MineBox>();
            foreach (var item in groupBoxBoard.Controls)
            {
                var button = item as Button;
                if (button == null)
                    continue;

                var mine = button.Tag as MineBox;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;
                        if (mine.position.X == minebox.position.X + i && mine.position.Y == minebox.position.Y + j)
                            etrafindakiler.Add(mine);
                    }

                }

            }
            return etrafindakiler;
        }

        private void FormReScale()
        {
            int formX = groupBoxCustom.Location.X + groupBoxCustom.Size.Width > groupBoxBoard.Location.X + groupBoxBoard.Size.Width ? groupBoxCustom.Location.X + groupBoxCustom.Size.Width : groupBoxBoard.Location.X + groupBoxBoard.Size.Width;
            int formY = groupBoxBoard.Location.Y + groupBoxBoard.Size.Height;
            this.Size = new Size(formX + 30, formY + 50);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for_second += 1;
            timer_second.Text = for_second.ToString();
            timer_minute.Text = for_minute.ToString() + ".";
            if (for_second == 59)
            {
                for_minute += 1;
                for_second = 0;
                timer_minute.Text = for_minute.ToString() + ".";
            }
        }
        /// <summary>
        /// randomly assign bomb locations
        /// </summary>
        /// <param name="nBombs">number of bombs to place</param>
        /// <param name="width">width of the board</param>
        /// <param name="height">height of the board</param>
        private void PlaceTheBombs(int nBombs, int width, int height)
        {
            //randomly pick nBombs buttons
            int i = 0;
            Random r = new Random();
            int selectedButton;
            while (i < nBombs)
            {
                selectedButton = r.Next(width * height);
                int buttonIndexRow, buttonIndexCol;
                buttonIndexRow = selectedButton / width;
                buttonIndexCol = selectedButton % width;
                Button randombutton = buttons[buttonIndexRow, buttonIndexCol];
                MineBox randommine = randombutton.Tag as MineBox;
                if (!randommine.isbomb)
                {
                    randommine.isbomb = true;
                    i++;
                }
            }
        }
        /// <summary>
        /// this function labels the rest of the buttons with either numbers or empty string
        /// </summary>
        private void LabelTheRest(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Button button = buttons[i, j];
                    MineBox mine = button.Tag as MineBox;

                    if (!mine.isbomb)
                    {
                        int rowStart = (i - 1) > 0 ? (i - 1) : 0;
                        int colStart = (j - 1) > 0 ? (j - 1) : 0;
                        int rowEnd = (i + 1) < height ? (i + 1) : i;
                        int colEnd = (j + 1) < width ? (j + 1) : j;
                        numberToWrite = 0;
                        for (int r = rowStart; r <= rowEnd; r++)
                        {
                            for (int c = colStart; c <= colEnd; c++)
                            {
                                //etrafındaki her bir kutu için
                                MineBox etraf = buttons[r, c].Tag as MineBox;
                                if (etraf.isbomb)
                                {
                                    numberToWrite++;
                                }
                            }
                        }
                        mine.minecount = numberToWrite;
                    }               
                }
            }
        }
        public void add_panel()
        {
            Point giris_size = new Point(Width_ * 22, 44);
            panel.Location = new Point(15, 11);
            panel.Size = new Size(giris_size);
            panel.BackColor = Color.DarkGray;
            groupBoxBoard.Controls.Add(panel);
        }

        // her butonun Tag kısmına bu nesneyi koyabiliriz
        // böylece sadece etrafındaki mayın sayısını değilde daha fazla bilgi tutabiliriz button.tag kısmında.
        public class MineBox
        {
            public Point position;
            public Button button; //mayinin bağlandığı buton.
            public int minecount;//etrafındaki mayın sayısı.
            public bool isbomb;//bombaysa
            public bool open;// açıkmışsak
            public bool flag;//bayrak konmuşsa bunları true yapıyoruz.
        }
    }
}
