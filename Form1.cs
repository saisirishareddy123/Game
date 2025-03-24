using System.Security.Cryptography;

namespace Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "b", "b", "n", "n", "L", "L", "h", "h",
            "J", "J", "S", "S", "w", "w", "Q", "Q"
        };

        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label label)
                {
                    int randomIndex = random.Next(icons.Count);
                    label.Text = icons[randomIndex];
                    label.ForeColor = label.BackColor;  
                    icons.RemoveAt(randomIndex);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

             
            if (clickedLabel == null || clickedLabel.ForeColor == Color.Black || timer1.Enabled)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;  
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;  

            CheckForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                 
                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label label && label.ForeColor == label.BackColor)
                {
                    return;  
                }
            }

            MessageBox.Show("You matched all the icons! Congrats!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;  
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
    }
}