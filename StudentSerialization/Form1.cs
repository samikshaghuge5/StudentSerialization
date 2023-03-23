using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;

namespace StudentSerialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\DotNet\studBinary.dat", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.Rollno = Convert.ToInt32(txtrollno.Text);
                student.Name = txtname.Text;
                student.Percentage = Convert.ToDouble(txtpercentage.Text);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, student);
                MessageBox.Show("Data Saved");
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\DotNet\studBinary.dat", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                BinaryFormatter bf = new BinaryFormatter();
                student = (Student)bf.Deserialize(fs);
                txtrollno.Text = student.Rollno.ToString();
                txtname.Text = student.Name;
                txtpercentage.Text = student.Percentage.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\DotNetstudentxml.xml", FileMode.Create, FileAccess.Write);
                Student student = new Student();
               
                student.Rollno = Convert.ToInt32(txtrollno.Text);
                student.Name = txtname.Text;
                student.Percentage = Convert.ToDouble(txtpercentage.Text);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
                xmlSerializer.Serialize(fs, student);
                MessageBox.Show("Data Saved");
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\DotNetstudentxml.xml", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
                student = (Student)xmlSerializer.Deserialize(fs);
                txtrollno.Text = student.Rollno.ToString();
                txtname.Text = student.Name;
                txtpercentage.Text = student.Percentage.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\studentsoap.soap", FileMode.Create, FileAccess.Write);
                Student student = new Student();

                student.Rollno = Convert.ToInt32(txtrollno.Text);
                student.Name = txtname.Text;
                student.Percentage = Convert.ToDouble(txtpercentage.Text);

                SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, student);
                MessageBox.Show("Data Saved");
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\studentsoap.soap", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                SoapFormatter soapFormatter = new SoapFormatter();
                student = (Student)soapFormatter.Deserialize(fs);
                txtrollno.Text = student.Rollno.ToString();
                txtname.Text = student.Name;
                txtpercentage.Text = student.Percentage.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\studentjson.json", FileMode.Create, FileAccess.Write);
                Student student = new Student();
                student.Rollno = Convert.ToInt32(txtrollno.Text);
                student.Name = txtname.Text;
                student.Percentage = Convert.ToDouble(txtpercentage.Text);
                JsonSerializer.Serialize<Student>(fs, student);
                MessageBox.Show("Data Saved");
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Admin\Documents\copy uts\studentjson.json", FileMode.Open, FileAccess.Read);
                Student student = new Student();
                student = JsonSerializer.Deserialize<Student>(fs);
                txtrollno.Text = student.Rollno.ToString();
                txtname.Text = student.Name;
                txtpercentage.Text = student.Percentage.ToString();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
