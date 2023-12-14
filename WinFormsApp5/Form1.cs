using System.Numerics;
using WinFormsApp5.Tables;

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
            Team teamA = new Team { Id = 1, Name = "���� ������", City = "", WinCount = 16, LossCount = 13, TieCount = 2, Goals = 10, MissedGoals = 5 };
            Team teamB = new Team { Id = 2, Name = "������", City = "", WinCount = 15, LossCount = 12, TieCount = 2, Goals = 14, MissedGoals = 6 };
            Team teamC = new Team { Id = 3, Name = "���������", City = "", WinCount = 15, LossCount = 10, TieCount = 4, Goals = 6, MissedGoals = 4 };
            Player player1 = new Player { Id = 1, TeamName = "���������", Country = "������", NameSurname = "����� ���������", Number = 26, Position = "�������" };
            Player player2 = new Player { Id = 2, TeamName = "���������", Country = "ͳ�������", NameSurname = "����� ��������", Number = 22, Position = "ϳ���������" };
            Player player3 = new Player { Id = 3, TeamName = "���������", Country = "������", NameSurname = "���� �����", Number = 27, Position = "��������" };
            Player player4 = new Player { Id = 4, TeamName = "������", Country = "������", NameSurname = "���� ������ �����", Number = 1, Position = "�������" };
            Player player5 = new Player { Id = 5, TeamName = "������", Country = "ͳ��������", NameSurname = "���� ����", Number = 17, Position = "ϳ���������" };
            Player player6 = new Player { Id = 6, TeamName = "������", Country = "�������", NameSurname = "���� ����", Number = 22, Position = "��������" };
            Player player7 = new Player { Id = 7, TeamName = "���� ������", Country = "������", NameSurname = "����� ����", Number = 13, Position = "�������" };
            Player player8 = new Player { Id = 8, TeamName = "���� ������", Country = "������", NameSurname = "������� �������", Number = 34, Position = "ϳ���������" };
            Player player9 = new Player { Id = 9, TeamName = "���� ������", Country = "���������", NameSurname = "���� �����", Number = 24, Position = "��������" };
            Game game1 = new Game { Id = 1, Team1 = teamA, Team2 = teamC, Goals1 = 3, Goals2 = 0, Scored = player9, Date = "30.07.2023" };
            Game game2 = new Game { Id = 2, Team1 = teamB, Team2 = teamC, Goals1 = 2, Goals2 = 4, Scored = player6, Date = "10.12.2023" };
            Game game3 = new Game { Id = 3, Team1 = teamB, Team2 = teamA, Goals1 = 0, Goals2 = 3, Scored = player9, Date = "30.09.2023" };
            db.Teams.Add(teamA);
            db.Teams.Add(teamB);
            db.Teams.Add(teamC);
            db.Players.Add(player1);
            db.Players.Add(player2);
            db.Players.Add(player3);
            db.Players.Add(player4);
            db.Players.Add(player5);
            db.Players.Add(player6);
            db.Players.Add(player7);
            db.Players.Add(player8);
            db.Players.Add(player9);
            db.Games.Add(game1);
            db.Games.Add(game2);
            db.Games.Add(game3);
            db.SaveChanges();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) { }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Players.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Teams.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Games.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Teams.Select(s => new { Name = s.Name, Difference = s.Goals - s.MissedGoals }).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ ����. (��.��.����)", "��� �����", $"{db.Games.ToList()[0].Date}", -1, -1);
            dataGridView1.DataSource = db.Games.Where(s => s.Date.Contains(input)).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ �������.", "��� �����", "", -1, -1);
            dataGridView1.DataSource = db.Games.Where(s => s.Team1.Name == input || s.Team2.Name == input).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ ����. (��.��.����)", "��� �����", $"{db.Games.ToList()[0].Date}", -1, -1);
            dataGridView1.DataSource = db.Games.Where(s => s.Date.Contains(input)).Select(s => s.Scored).ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ ����� ������ �� ���� ���������� ����� ����� ����. ���������: �������1,�������2,��.��.����", "��������� �����", "", -1, -1);
            var query = db.Games.Where(g => (g.Team1.Name + "," + g.Team2.Name + "," + g.Date) == input).ToList();
            var success = MessageBox.Show("�� ������� �� ������ �������� ���?", "�����", MessageBoxButtons.YesNo);
            if (success == DialogResult.Yes)
            {
                foreach (var a in query)
                {
                    db.Games.Remove(a);
                    db.SaveChanges();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ �� ��� �����������.", "����������� �����", "1", -1, -1);
            int productid;
            bool success = int.TryParse(input, out productid);

            string input1 = Microsoft.VisualBasic.Interaction.InputBox("������ ����� �������1, �������2, ������� ���� �������1, ������� ���� �������2, ϲ� ������ ���� ����� ��� ����� ����. ���������: �������1,�������2,1,1,���� ���", "����������� �����", "", -1, -1);
            List<string> newobject = input1.Split(",").ToList<string>();
            var query = db.Games.Where(g => g.Id == productid).ToList();
            foreach (var a in query)
            {
                db.Games.Remove(a);
                db.SaveChanges();
            }
            db.Games.Add(new Game { Id = productid, Team1 = new Team { Name = newobject[0] }, Team2 = new Team { Name = newobject[1] }, Goals1 = int.Parse(newobject[2]), Goals2 = int.Parse(newobject[3]), Scored = new Player { NameSurname = newobject[4] }, Date = newobject[5]);
            db.SaveChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("������ ����� �������1, �������2, ������� ���� �������1, ������� ���� �������2, ϲ� ������ ���� ����� ��� ����� ����. ���������: �������1,�������2,1,1,���� ���", "��� �����", "", -1, -1);
            List<string> newobject = input.Split(",").ToList<string>();
            int tempid = db.Games.ToList().IndexOf(db.Games.ToList().Last()) + 2;
            try
            {
                db.Games.Add(new Game { Id = tempid, Team1 = new Team { Name = newobject[0] }, Team2 = new Team { Name = newobject[1] }, Goals1 = int.Parse(newobject[2]), Goals2 = int.Parse(newobject[3]), Scored = new Player { NameSurname = newobject[4] }, Date = newobject[5] });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�������. " + ex.Message);
            }
        }
    }
}
