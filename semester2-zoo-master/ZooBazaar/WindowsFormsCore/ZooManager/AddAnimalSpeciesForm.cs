using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.DTO;

namespace WindowsFormApp
{
    public partial class AddAnimalSpeciesForm : Form
    {
        private SpeciesDTO speciesdto;
        public AddAnimalSpeciesForm()
        {
            InitializeComponent();
            speciesdto = new SpeciesDTO();
            PopulateList();
        }

        private void PopulateList()
        {
            this.LsbxSpecies.DataSource = null;

            speciesdto.GetListFromRepo();
            this.LsbxSpecies.DisplayMember = "SpeciesName";
            this.LsbxSpecies.ValueMember = "SpeciesName";
            this.LsbxSpecies.DataSource = speciesdto.ListOfSpecies;
        }

        private void BtnAddSpecies_Click(object sender, EventArgs e)
        {
            AddSpeciesBTN();

        }

        private void AddSpeciesBTN()
        {
            this.LsbxSpecies.SelectedItems.Clear();
            this.PnlForms.Controls.Clear();
            SpeciesInfoForm speciesinfo = new SpeciesInfoForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlForms.Controls.Add(speciesinfo);
            speciesinfo.Show();
            this.BtnAddAnimal.Enabled = false;
            this.BtnAddAnimal.Visible = false;
        }

        private void LsbxSpecies_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (this.LsbxSpecies.SelectedIndex != -1)
            {
                Species species = (Species)this.LsbxSpecies.SelectedItem;
                speciesdto.SelectSpecies(species);
                this.PnlForms.Controls.Clear();
                SpeciesInfoForm speciesinfo = new SpeciesInfoForm(speciesdto.SelectedSpecies) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.PnlForms.Controls.Add(speciesinfo);
                speciesinfo.Show();

                this.BtnAddAnimal.Enabled = true;
                this.BtnAddAnimal.Visible = true;
            }
            else
            {
                this.BtnAddAnimal.Enabled = false;
                this.BtnAddAnimal.Visible = false;
                PopulateList();
            }


        }

        private void BtnAddAnimal_Click(object sender, EventArgs e)
        {
            if (this.LsbxSpecies.SelectedIndex != -1)
            {
                this.PnlForms.Controls.Clear();
                AddAnimalInfoForm addAnimalInfoForm = new AddAnimalInfoForm(speciesdto.SelectedSpecies) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.PnlForms.Controls.Add(addAnimalInfoForm);
                addAnimalInfoForm.Show();
            }


        }

        private void LsbxSpecies_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            int index = LsbxSpecies.IndexFromPoint(pt);

            if (index <= -1)
            {
                LsbxSpecies.SelectedItems.Clear();
                AddSpeciesBTN();
            }

        }
    }
}