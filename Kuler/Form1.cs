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
using System.IO;
namespace Kuler
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();
            button1.Enabled = false;
            button48.Enabled = false;
            
            
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button48.Enabled = true;
            button11.Visible = false;
            button12.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label6.Visible = false;
            button4.Visible = false;
            button13.Enabled = false;
            textBox7.Visible = false;
            textBox7.Visible = false;
            label7.Visible = false;
            button4.Visible = false;
        }

        
        SqlConnection con = new SqlConnection(Konekcija.konString);

        SqlCommand cmd;

        
        private void button1_Click(object sender, EventArgs e)
        {
            

            {
                this.kuleriTableAdapter.Update(this.kadroviDataSet.Kuleri);
            }
            sakrij();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button35.Visible = false;
            button11.Visible = true;
            button12.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label8.Visible = true;
            richTextBox1.Visible = true;
            textBox6.Visible = false;
            label6.Visible = false;
            button3.Enabled = false;
            button4.Visible = false;
            button7.Enabled = false;
            button16.Visible = false;
            button27.Visible = false;
            textBox7.Visible = false;
            /*try
            {
                byte[] images = null;
                FileStream streem = new FileStream(filepicture, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(streem);
                images = br.ReadBytes((int)streem.Length);
                con.Open();
                string SqlQuery = "insert into Kuler(IDKulera,BrendingKulera,ModelKulera,VlasnikKulera,AdresaKulera,SlikaKulera)values " +
                    "('" + Convert.ToInt32(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "',@images)";
                cmd = new SqlCommand(SqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Uspesno uneto!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void unesiNovKulerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string filepicture = "";

        private void button2_Click(object sender, EventArgs e)
        {

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kadroviDataSet2.Korisnici' table. You can move, or remove it, as needed.
            this.korisniciTableAdapter.Fill(this.kadroviDataSet2.Korisnici);
            // TODO: This line of code loads data into the 'kadroviDataSet2.Kuler' table. You can move, or remove it, as needed.
            this.kulerTableAdapter1.Fill(this.kadroviDataSet2.Kuler);
            // TODO: This line of code loads data into the 'kadroviDataSet1.Kuler' table. You can move, or remove it, as needed.
            this.kulerTableAdapter.Fill(this.kadroviDataSet1.Kuler);
            // TODO: This line of code loads data into the 'kadroviDataSet.Kuleri' table. You can move, or remove it, as needed.
            this.kulerTableAdapter.Fill(this.kadroviDataSet1.Kuler);

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sakrij();
            button35.Visible = true;
            label6.Visible = true;
            textBox6.Visible = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT SlikaKulera from Kuler where IDKulera =' " + textBox7.Text + "'";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    byte[] img = (byte[])(dr[0]);

                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                    
                }
                else
                {
                   
                    MessageBox.Show("Slika ne postoji za dati ID.");
                }
            }
            catch (Exception ex)
            {

                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Morate uneti broj ID");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        void sakrij()
        {
            richTextBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            button35.Visible = false;
            button11.Visible = false;
            button4.Visible = false;
            button12.Visible = false;
            button6.Visible = false;
            button55.Visible = false;
            button32.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }
        private void button1_Validating(object sender, CancelEventArgs e)
        {
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox7.Visible = true;
            label7.Visible = true;
            button4.Visible = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;

        }
        int mouseX = 0;
        int mouseY = 0;
        bool mouse;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           

            if (mouse)
            {
                mouseX = MousePosition.X - 50;
                mouseY = MousePosition.Y - 50;


                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else this.WindowState = FormWindowState.Normal;
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;

            }
            else this.WindowState = FormWindowState.Normal;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filepicture = dialog.FileName.ToString();
                pictureBox1.ImageLocation = filepicture;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] images = null;
                FileStream streem = new FileStream(filepicture, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(streem);
                images = br.ReadBytes((int)streem.Length);
                con.Open();
                string SqlQuery = "insert into Kuler(IDKulera,BrendingKulera,ModelKulera,VlasnikKulera,AdresaKulera,SlikaKulera)values " +
                    "('" + Convert.ToInt32(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "',@images)";
                cmd = new SqlCommand(SqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                
                MessageBox.Show("Uspesno uneto!");
                this.kuleriTableAdapter.Update(this.kadroviDataSet.Kuleri);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                pictureBox1.Image = null;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string SqlQuery = "delete from Kuler WHERE IDKulera = @ID ";
                cmd = new SqlCommand(SqlQuery, con);
                cmd.Parameters.Add(new SqlParameter("@ID", Convert.ToInt32(textBox6.Text)));
                int n = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kuler uspešno obrisan!");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            sakrij();
            button16.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            button27.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            label11.Visible = true;
            button28.Visible = false;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            button16.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            button28.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
        }
        
        private void button28_Click(object sender, EventArgs e)
        {
           
            
            try
            {
                con.Open();



                using (SqlCommand cmd = new SqlCommand("SELECT KorisnickoIme, KorisnickaSifra from Korisnici where KorisnickoIme = @Ime ", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Ime", textBox8.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            listBox1.Items.Add(dr[0].ToString());
                            listBox1.Items.Add(dr[1].ToString());

                        }
                    }
                    else
                    {
                        MessageBox.Show("Korisnik sa datim imenom ne postoji. Pokušajte ponovo.");
                        
                    }
                    dr.Close();
                       
                }
                     
                
                if (listBox1.Items[0].ToString() == textBox8.Text && listBox1.Items[1].ToString() == textBox9.Text && listBox1.Items[0].ToString() == "Administrator")
                {
                    MessageBox.Show("Uspesan admin login!");
                    button3.Visible = true;
                    button1.Visible = true;
                    button7.Enabled = true;
                    button13.Enabled = true;
                    button3.Enabled = true;
                    button1.Enabled = true;
                    button52.Visible = true;
                    button14.Visible = true;
                    dataGridView1.Visible = true;
                    button21.Visible = true;

                }
                else if (listBox1.Items[0].ToString() == textBox8.Text && listBox1.Items[1].ToString() == textBox9.Text)
                {
                    MessageBox.Show("Uspesan user login!");
                    button7.Enabled = true;
                    button13.Enabled = true;
                    dataGridView1.Visible = true;

                }
                else
                {
                    MessageBox.Show("Greska u loginu.");
                   
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            listBox1.Items.Clear();
            textBox8.Clear();
            textBox9.Clear();
            
        }


        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        bool maskedpassword = false;
        private void button16_Click(object sender, EventArgs e)
        {
            if (maskedpassword == false)
            {
                textBox9.PasswordChar = '*';
                textBox10.PasswordChar = '*';
                maskedpassword = true;
            }
            else
            {

                textBox9.PasswordChar = '\0';
                textBox10.PasswordChar = '\0';
                maskedpassword = false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();



                using (SqlCommand cmd = new SqlCommand("SELECT KorisnickoIme, KorisnickaSifra from Korisnici where KorisnickoIme = @Ime ", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@Ime", textBox8.Text));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr[0].ToString());
                        listBox1.Items.Add(dr[1].ToString());

                    }
                    dr.Close();

                }


                if (listBox1.Items[0].ToString() == textBox8.Text && listBox1.Items[1].ToString() == textBox9.Text)
                {

                    using (SqlCommand cmd = new SqlCommand("UPDATE Korisnici SET KorisnickaSifra = @Sifra where KorisnickoIme = @Ime ", con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Ime", textBox8.Text));
                        cmd.Parameters.Add(new SqlParameter("@Sifra", textBox10.Text));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Uspesno promenjena sifra!");
                    }


                }
                
                else
                {
                    MessageBox.Show("Pogresno ime/lozinka. Pokusajte ponovo.");

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            listBox1.Items.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            sakrij();
            button16.Visible = true;
            button55.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string imee;
                using (SqlCommand kmd = new SqlCommand("select KorisnickoIme from Korisnici where KorisnickoIme = @Imeee", con))
                {
                    kmd.Parameters.Add(new SqlParameter("@Imeee", textBox8.Text));
                    SqlDataReader dr = kmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            listBox1.Items.Add(dr[0].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Korisnik sa datim imenom ne postoji. Pokušajte ponovo.");
                    }
                }

                if (listBox1.Items[0].ToString() == textBox8.Text)
                {
                    MessageBox.Show("Korisničko ime već postoji.");
                }
                else
                {
                    this.korisniciTableAdapter.Insert(textBox8.Text, textBox9.Text);
                    MessageBox.Show("Novi korisnik uspešno unet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                listBox1.Items.Clear();
            }
               
               
        }

        private void button52_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            richTextBox1.Visible = true;
            button6.Visible = true;
            button12.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
        }

        private void button95_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string imee ;
                using (SqlCommand kmd = new SqlCommand("select IDKulera from Kuler where IDKulera = @ID", con))
                {
                    kmd.Parameters.Add(new SqlParameter("@ID", textBox1.Text));
                    imee = kmd.ExecuteScalar().ToString();
                    
                }

                if (imee == null)
                {
                    MessageBox.Show("Korisnicki ID ne postoji.");
                }
                else
                {
                    byte[] images = null;
                    FileStream streem = new FileStream(filepicture, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(streem);
                    images = br.ReadBytes((int)streem.Length);
                    using (SqlCommand komanda = new SqlCommand("update Kuler set BrendingKulera = @Brending, ModelKulera = @Model, VlasnikKulera = @Vlasnik, AdresaKulera = @Adresa, SlikaKulera = @Slika, OpisKulera = @Opis where IDKulera = @ID", con))
                    {
                        komanda.Parameters.Add(new SqlParameter("@ID", textBox1.Text));
                        komanda.Parameters.Add(new SqlParameter("@Brending", textBox2.Text));
                        komanda.Parameters.Add(new SqlParameter("@Model", textBox3.Text));
                        komanda.Parameters.Add(new SqlParameter("@Vlasnik", textBox4.Text));
                        komanda.Parameters.Add(new SqlParameter("@Adresa", textBox5.Text));
                        komanda.Parameters.Add(new SqlParameter("@Opis", richTextBox1.Text));
                        komanda.Parameters.Add(new SqlParameter("@Slika", images));
                        komanda.ExecuteNonQuery();
                    }

                    MessageBox.Show("Uspesno izmenjeni podaci za kuler!");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska : ID ne postoji ili " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string imee;
        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                
                using (SqlCommand kmd = new SqlCommand("select KorisnickoIme from Korisnici where KorisnickoIme = @Imee", con))
                {
                    kmd.Parameters.Add(new SqlParameter("@Imee", textBox8.Text));
                    if (kmd.ExecuteScalar().ToString() != null)
                    {
                        imee = kmd.ExecuteScalar().ToString();
                    }
                    else imee = "";
                }
                if (textBox8.Text == "")
                {
                    MessageBox.Show("Unesite korisnicko ime i sifru.");
                }
                else if (imee == "")
                {
                    MessageBox.Show("Korisnik ne postoji. Probaj ponovo.");
                }
                else if (textBox8.Text == "Administrator")
                {
                    MessageBox.Show("Ne mozete obrisati administratora.");
                }
                else
                {
                    //(KorisnickoIme,KorisnickaSifra) 
                    using (SqlCommand kmd = new SqlCommand("delete from Korisnici where KorisnickoIme = @ImeKorisnika", con))
                    {
                        kmd.Parameters.Add(new SqlParameter("@ImeKorisnika", textBox8.Text));
                       
                        kmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Uspesno obrisan korisnik!");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sakrij();
            button32.Visible = true;
            textBox8.Visible = true;
            label9.Visible = true;
        }
    }

}
