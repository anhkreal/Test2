using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_Calendar;
using DTO_Calendar;

namespace GUI_Calendar
{
    public partial class Form1 : Form
    {
        //BUS_Appointment a = new BUS_Appointment();
        //BUS_GroupMeeting g = new BUS_GroupMeeting();
        //BUS_Users u = new BUS_Users();
        public Form1()
        {
            InitializeComponent();
            setDGV();
            groupBox2.Visible = false;
        }

        public void setDGV()
        {
            DataTable dt = BUS_Appointment.Instance.getAppointment();
            dataGridView1.DataSource = dt;
        }

        private void buttonAppointment_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_Appointment.Instance.getAppointment();
            dataGridView1.DataSource= dt;
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_Users.Instance.getUsers();
            dataGridView1.DataSource = dt;
        }

        private void buttonGroupMeeting_Click(object sender, EventArgs e)
        {
            DataTable dt = BUS_GroupMeeting.Instance.getGroupMeeting();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e) // button New
        {
            if(textBox1.Text != "")
            {
                int u_id = BUS_Users.Instance.timUser(textBox1.Text);
                if (u_id < 0)
                {
                    BUS_Users.Instance.themUser(new DTO_Users(0, textBox1.Text));
                    MessageBox.Show("Da them moi username " + textBox1.Text);
                }
                else
                {
                    MessageBox.Show("Da co " + textBox1.Text + " trong danh sach username");
                }
                buttonUsers_Click(sender, e);
                groupBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("Nhap username");
            }
        }

        private void button2_Click(object sender, EventArgs e) // button OK
        {
            int u_id = BUS_Users.Instance.timUser(textBox1.Text);
            if(textBox2.Text != "" && textBox3.Text != "")
            {
                int a_id = BUS_Appointment.Instance.timAppointment(textBox2.Text);
                if(a_id > 0)
                {
                    int g_id = BUS_GroupMeeting.Instance.timGroupMeeting(u_id, a_id);
                    MessageBox.Show(textBox2.Text + " da co trong danh sach cuoc hen");
                    if(g_id > 0)
                    {
                        MessageBox.Show("Da ton tai trong nhom cuoc hen");
                    }
                    else
                    {
                        BUS_GroupMeeting.Instance.themGroupMeeting(new DTO_GroupMeeting(0, a_id, u_id));
                    }
                }
                else
                {
                    int year = dateTimePicker1.Value.Year;
                    int month = dateTimePicker1.Value.Month;
                    int day = dateTimePicker1.Value.Day;
                    int hour1 = dateTimePicker2.Value.Hour;
                    int minute1 = dateTimePicker2.Value.Minute;
                    int second1 = dateTimePicker2.Value.Second;
                    int hour2 = dateTimePicker3.Value.Hour;
                    int minute2 = dateTimePicker3.Value.Minute;
                    int second2 = dateTimePicker3.Value.Second;
                    DateTime st = new DateTime(year, month, day, hour1, minute1, second1);
                    DateTime ft = new DateTime(year, month, day, hour2, minute2, second2);
                    bool ch;
                    TimeSpan ts;
                    if(radioButton1.Checked)
                    {
                        ch = true;
                        ts = new TimeSpan(0, 10, 0);
                    }
                    else if(radioButton2.Checked)
                    {
                        ch = true;
                        ts = new TimeSpan(0, 30, 0);
                    }
                    else
                    {
                        ch = false;
                        ts = new TimeSpan(0, 0, 0);    
                    }

                    if(st > ft)
                    {
                        MessageBox.Show("Thoi gian khong hop le");
                    }
                    else
                    {
                        //string ttt = string.Format("insert Appointment values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                        //     textBox2.Text, st.ToString("yyyy-MM-dd HH:mm:ss"), ft.ToString("yyyy-MM-dd HH:mm:ss"), textBox3.Text, ch ? '1' : '0', ts);
                        BUS_Appointment.Instance.themAppointment(new DTO_Appointment(0, textBox2.Text, st, ft, textBox3.Text, ch, ts));
                        BUS_GroupMeeting.Instance.themGroupMeeting(new DTO_GroupMeeting(0, BUS_Appointment.Instance.timAppointment(textBox2.Text),BUS_Users.Instance.timUser(textBox1.Text)));
                        MessageBox.Show("Da tien hanh them moi Appointment, GroupMeeting");
                        //MessageBox.Show(ttt);
                    }
                    buttonAppointment_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Hay nhap du lieu day du");
            }
        }
    }
}
