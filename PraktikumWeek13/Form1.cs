using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PraktikumWeek13
{
    public partial class Form1 : Form
    {
        public static string sqlConnection = "server=139.255.11.84;uid=student;pwd=isbmantap;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        int counter = 0;
        string temp = "";

        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd ,MMMM dd, yyyy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = "SELECT `player_id`, `team_number`, `player_name`, `nation`, `birthdate`,`team_name`, IF(status = 1, 'Available', 'Not Available') as status FROM team t, player_james p, nationality n WHERE p.nationality_id = n.nationality_id AND t.team_id = p.team_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            textBoxID.Text = dt.Rows[0][0].ToString();
            textBoxName.Text = dt.Rows[0][2].ToString();
            dateTimePicker1.Text = dt.Rows[0][4].ToString();
            numericUpDownTeamNumber.Text = dt.Rows[counter][1].ToString(); 
            labelStatus.Text = dt.Rows[0][6].ToString();

            DataTable nationality = new DataTable();
            sqlQuery = "SELECT n.nation, n.nationality_id FROM nationality n";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(nationality);
            comboBoxNationality.DataSource = nationality;
            comboBoxNationality.ValueMember = "nation";

            DataTable team = new DataTable();
            sqlQuery = "SELECT t.team_name, t.team_id FROM team t";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(team);
            comboBoxTeam.DataSource = team;
            comboBoxTeam.ValueMember = "team_name";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            counter = 0;
            sqlQuery = "SELECT `player_id`, `team_number`, `player_name`, `nation`, `birthdate`,`team_name`, IF(status = 1, 'Available', 'Not Available') as status, n.nation, n.nationality_id, t.team_name, t.team_id FROM team t, player_james p, nationality n WHERE p.nationality_id = n.nationality_id AND t.team_id = p.team_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            textBoxID.Text = dt.Rows[counter][0].ToString();
            textBoxName.Text = dt.Rows[counter][2].ToString();
            dateTimePicker1.Text = dt.Rows[counter][4].ToString();
            numericUpDownTeamNumber.Text = dt.Rows[counter][1].ToString();
            labelStatus.Text = dt.Rows[counter][6].ToString();

            comboBoxTeam.SelectedValue = dt.Rows[counter][5].ToString();
            comboBoxNationality.SelectedValue = dt.Rows[counter][7].ToString();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (counter <= 0)
            {
                MessageBox.Show("Sudah data pertama");
            }
            else
            {
                counter--;
                sqlQuery = "SELECT `player_id`, `team_number`, `player_name`, `nation`, `birthdate`,`team_name`, IF(status = 1, 'Available', 'Not Available') as status, n.nation, n.nationality_id, t.team_name, t.team_id FROM team t, player_james p, nationality n WHERE p.nationality_id = n.nationality_id AND t.team_id = p.team_id";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);
                textBoxID.Text = dt.Rows[counter][0].ToString();
                textBoxName.Text = dt.Rows[counter][2].ToString();
                dateTimePicker1.Text = dt.Rows[counter][4].ToString();
                numericUpDownTeamNumber.Text = dt.Rows[counter][1].ToString();
                labelStatus.Text = dt.Rows[counter][6].ToString();

                comboBoxTeam.SelectedValue = dt.Rows[counter][5].ToString();
                comboBoxNationality.SelectedValue = dt.Rows[counter][7].ToString();
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            counter = 858;
            sqlQuery = "SELECT `player_id`, `team_number`, `player_name`, `nation`, `birthdate`,`team_name`, IF(status = 1, 'Available', 'Not Available') as status, n.nation, n.nationality_id, t.team_name, t.team_id FROM team t, player_james p, nationality n WHERE p.nationality_id = n.nationality_id AND t.team_id = p.team_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            textBoxID.Text = dt.Rows[counter][0].ToString();
            textBoxName.Text = dt.Rows[counter][2].ToString();
            dateTimePicker1.Text = dt.Rows[counter][4].ToString();
            numericUpDownTeamNumber.Text = dt.Rows[counter][1].ToString();
            labelStatus.Text = dt.Rows[counter][6].ToString();

            comboBoxTeam.SelectedValue = dt.Rows[counter][5].ToString();
            comboBoxNationality.SelectedValue = dt.Rows[counter][7].ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (counter >= 858)
            {
                MessageBox.Show("Sudah data terakhir");
            }
            else
            {
                counter++;
                sqlQuery = "SELECT `player_id`, `team_number`, `player_name`, `nation`, `birthdate`,`team_name`, IF(status = 1, 'Available', 'Not Available') as status, n.nation, n.nationality_id, t.team_name, t.team_id FROM team t, player_james p, nationality n WHERE p.nationality_id = n.nationality_id AND t.team_id = p.team_id";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);
                textBoxID.Text = dt.Rows[counter][0].ToString();
                textBoxName.Text = dt.Rows[counter][2].ToString();
                dateTimePicker1.Text = dt.Rows[counter][4].ToString();
                numericUpDownTeamNumber.Text = dt.Rows[counter][1].ToString();
                labelStatus.Text = dt.Rows[counter][6].ToString();

                comboBoxTeam.SelectedValue = dt.Rows[counter][5].ToString();
                comboBoxNationality.SelectedValue = dt.Rows[counter][7].ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (labelStatus.Text == "Not Available")
            {
                MessageBox.Show("Team Number sudah dipakai");
            }
            else
            {
                sqlQuery = "UPDATE  player_name = '" + textBoxName.Text + "', nationality_id = '" + comboBoxNationality.SelectedValue.ToString() + "', birthdate = '" + dateTimePicker1.Value.ToString("yyyMMdd") + "', team_id = '" + comboBoxTeam.SelectedValue.ToString() + "' where player_id = '" + textBoxID.Text + "'";

                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);

                MessageBox.Show("Data Player bernama " + textBoxName.Text + " berhasil diupdate.");
                sqlConnect.Close();
            }
        }

        private void numericUpDownTeamNumber_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
