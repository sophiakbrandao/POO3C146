using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POO3C146.DTO;
using POO3C146.DAL;
using POO3C146.BLL;

namespace POO3C146
{
    public partial class FrmMusica : Form
    {
        public FrmMusica()
        {
            InitializeComponent();
        }

        /// Projeto feito em dupla by Sophia(30) e Larissa(16)

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMusica_Load(object sender, EventArgs e)
        {
            GridMusicas.DataSource = objbll.ListarMusicas();
        }

        DTO_musica objdto = new DTO_musica();
        BLL_musica objbll = new BLL_musica();

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                objdto.Idmusica = int.Parse(txtMusica.Text);
                objdto.Nome = txtNomeMusica.Text.Trim();
                objdto.NomeAutor = txtAutor.Text.Trim();
                objdto.Idgravadora = int.Parse(cbxGravadora.Text.Trim());
                objdto.IdCD = int.Parse(cbxCD.Text.Trim());

                GridMusicas.DataSource = objbll.ListarMusicas();


                if (objbll.Autenticar(objdto.Idmusica, objdto.Nome, objdto.NomeAutor, objdto.Idgravadora, objdto.IdCD))
                {
                    MessageBox.Show("Música encontrada no banco de dados");
                }
                else
                {
                    MessageBox.Show("Esta música não foi localizada no banco de dados");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Erro: \n" + fe.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception fe)
            {
                MessageBox.Show(fe.Message);
            }


        }

        private void cbxGravadora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                objdto.Idmusica = int.Parse(txtMusica.Text);
                objdto.Nome = txtNomeMusica.Text;
                objdto.NomeAutor = txtAutor.Text;
                objdto.Idgravadora = int.Parse(cbxGravadora.Text);
                objdto.IdCD = int.Parse(cbxCD.Text);

                GridMusicas.DataSource = objbll.ListarMusicas();
                objbll.AdicionarMusica(objdto);
                MessageBox.Show("Música adicionada com sucesso!\nPara ver a mudança feita na tabela clique em 'Atualizar'. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                objdto.Idmusica = int.Parse(txtMusica.Text);
                objdto.Nome = txtNomeMusica.Text;
                objdto.NomeAutor = txtAutor.Text;
                objdto.Idgravadora = int.Parse(cbxGravadora.Text);
                objdto.IdCD = int.Parse(cbxCD.Text);

                GridMusicas.DataSource = objbll.ListarMusicas();
                objbll.ExcluirMusica(objdto);
                MessageBox.Show("Música deletada com sucesso!\nPara ver a mudança feita na tabela clique em 'Atualizar'. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridMusicas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusica.Text = GridMusicas.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeMusica.Text = GridMusicas.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAutor.Text = GridMusicas.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbxGravadora.Text = GridMusicas.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbxCD.Text = GridMusicas.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.btnDeletar.Enabled = true;
            this.btnAlterar.Enabled = true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            GridMusicas.DataSource = objbll.ListarMusicas();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                objdto.Idmusica = int.Parse(txtMusica.Text);
                objdto.Nome = txtNomeMusica.Text;
                objdto.NomeAutor = txtAutor.Text;
                objdto.Idgravadora = int.Parse(cbxGravadora.Text);
                objdto.IdCD = int.Parse(cbxCD.Text);

                GridMusicas.DataSource = objbll.ListarMusicas();
                objbll.AlterarMusica(objdto);
                MessageBox.Show("Música alterada com sucesso!\nPara ver a mudança feita clique em 'Atualizar'. ", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMusica.Text = "0";
            txtNomeMusica.Clear();
            txtAutor.Clear();
            cbxGravadora.Text = "";
            cbxCD.Text = "";

            this.btnDeletar.Enabled = false;
            this.btnAlterar.Enabled = false;
        }
    }
}
