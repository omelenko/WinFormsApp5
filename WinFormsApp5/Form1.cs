namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        ApplicationContext db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new ApplicationContext();
            Team teamA = new Team { Id = 1, Name = "Реал Мадрид", City = "", WinCount = 16, LossCount = 13, TieCount = 2 };
            Team teamB = new Team { Id = 2, Name = "Жірона", City = "", WinCount = 15, LossCount = 12, TieCount = 2 };
            Team teamC = new Team { Id = 3, Name = "Барселона", City = "", WinCount = 15, LossCount = 10, TieCount = 4 };
            db.Teams.Add(teamA);
            db.Teams.Add(teamB);
            db.Teams.Add(teamC);
            db.SaveChanges();
            dataGridView1.DataSource = db.Teams.ToList();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) { }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) { }
    }
}
