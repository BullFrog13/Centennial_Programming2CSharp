using System.Windows.Forms;

namespace MonthNamesGUI
{
    public partial class Form1 : Form
    {
        enum Month
        {
            JANUARY = 1,
            FEBRUARY = 2,
            MARCH = 3,
            APRIL = 4,
            MAY = 5,
            JUNE = 6,
            JULY = 7,
            AUGUST = 8,
            SEPTEMBER = 9,
            OCTOBER = 10,
            NOVEMBER = 11,
            DECEMBER = 12
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var selectedValue = numericUpDown1.Value;
            var selectedMonth = (Month)selectedValue;

            label2.Text = selectedMonth.ToString();
        }
    }
}