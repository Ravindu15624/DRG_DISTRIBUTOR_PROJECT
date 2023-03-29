using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace DRGDistributorNew
{
    public partial class DSRSales02 : Form
    {
        float totAmt = 0;

        public static DSRSales02 instance;
        public DSRSales02()
        {
            InitializeComponent();
            instance = this;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login fm = new Login();
            fm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DSRHome fm = new DSRHome();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DSRSales01 fm = new DSRSales01();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (totAmt == 0 || totAmt == null)
            {
                
                button12.Enabled = false;
                MessageBox.Show("No Data Inserted");
                button12.Enabled = true;
            }
            else
            {
                
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;
                string Total = totAmt.ToString();




                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "insert into Invoice (Date,Customer,InvoiceID,Payment,Total) values('" + Date + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + Total + "')";

                SqlCommand cmd = new SqlCommand(qry, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Order Added Successfully");

                DSRSales03 fm = new DSRSales03();
                fm.Show();
                this.Hide();

                DSRSales03.instance.lab7.Text = comboBox1.Text;
                DSRSales03.instance.lab12.Text = comboBox2.Text;
                DSRSales03.instance.lab15.Text = dateTimePicker1.Text;
                DSRSales03.instance.lab19.Text = label51.Text;

                DSRSales03.instance.lab16.Text = TextBox1.Text;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                String str1 = textBox3.Text;
                int qty;
                int.TryParse(str1, out qty);
                int price = int.Parse(l46.Text);
                int amount = qty * price;
                label32.Text = amount.ToString();

                
            
           /* if(qty == null)
            {
                button7.Click
            }*/

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox4.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l45.Text);
            int amount = qty * price;
            label31.Text = amount.ToString();           



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox5.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l44.Text);
            int amount = qty * price;
            label30.Text = amount.ToString();

            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox6.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l43.Text);
            int amount = qty * price;
            label29.Text = amount.ToString();

            


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox7.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l42.Text);
            int amount = qty * price;
            label28.Text = amount.ToString();

            


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox8.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l41.Text);
            int amount = qty * price;
            label27.Text = amount.ToString();

            

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            String str1 = textBox9.Text;
            int qty;
            int.TryParse(str1, out qty);
            int price = int.Parse(l40.Text);
            int amount = qty * price;
            label26.Text = amount.ToString();

            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox3.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
               
                button7.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button7.Enabled = true;

            }
            else
            {
                
                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if(String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {

                    string ProductID = label12.Text;
                    string ProductName = label25.Text;
                    int Price = int.Parse(l46.Text);
                    int Amount = int.Parse(label32.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();


                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox4.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button8.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button8.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {

                    string ProductID = label13.Text;
                    string ProductName = label24.Text;
                    int Price = int.Parse(l45.Text);
                    int Amount = int.Parse(label31.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";


                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox5.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button10.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button10.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {



                    string ProductID = label14.Text;
                    string ProductName = label23.Text;
                    int Price = int.Parse(l44.Text);
                    int Amount = int.Parse(label30.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox6.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button11.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button11.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {



                    string ProductID = label15.Text;
                    string ProductName = label22.Text;
                    int Price = int.Parse(l43.Text);
                    int Amount = int.Parse(label29.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox7.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button13.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button13.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {



                    string ProductID = label16.Text;
                    string ProductName = label21.Text;
                    int Price = int.Parse(l42.Text);
                    int Amount = int.Parse(label28.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox8.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button14.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button14.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {



                    string ProductID = label17.Text;
                    string ProductName = label20.Text;
                    int Price = int.Parse(l41.Text);
                    int Amount = int.Parse(label27.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int QTY;
            String str1 = textBox9.Text;
            int.TryParse(str1, out QTY);

            if (QTY == 0 || QTY == null)
            {
                button15.Enabled = false;
                MessageBox.Show("Insert Product Quantity");
                button15.Enabled = true;
            }
            else
            {

                string DSRName = dsr.Text;
                string Date = dateTimePicker1.Text;
                string Customer = comboBox1.Text;
                string Invoice = TextBox1.Text;
                string Payment = comboBox2.Text;

                if (String.IsNullOrEmpty(TextBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Invoice ID");
                }
                else if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("Insert Customer Name");
                }
                else if (String.IsNullOrEmpty(comboBox2.Text.Trim()))
                {
                    MessageBox.Show("Insert Payment Method");
                }
                else
                {



                    string ProductID = label18.Text;
                    string ProductName = label19.Text;
                    int Price = int.Parse(l40.Text);
                    int Amount = int.Parse(label26.Text);



                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C#\drgDB.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "insert into Sales (Date,DSRName,Customer,InvoiceID,Payment,ProductID,ProductName,Price,QTY,Amount) values('" + Date + "','" + DSRName + "','" + Customer + "','" + Invoice + "','" + Payment + "','" + ProductID + "','" + ProductName + "','" + Price + "','" + QTY + "','" + Amount + "')";



                    SqlCommand cmd = new SqlCommand(qry, con);

                    totAmt = totAmt + Amount;
                    label51.Text = totAmt.ToString();



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Products Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label26_Clicked(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

