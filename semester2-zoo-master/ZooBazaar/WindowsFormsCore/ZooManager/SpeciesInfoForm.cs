using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.DTO;

namespace WindowsFormApp
{
    public partial class SpeciesInfoForm : Form
    {
        private EnclosureDTO enclosureDTO;
        private SpeciesDTO speciesDTO;
        private string state;

        private delegate void EdditSpecies(Guid id);
        private EdditSpecies edditSpecies;
        private int edditSpeciesState;

        private delegate void NewSpecies();
        private NewSpecies newSpecies;
        private int newSpeciesState;

        private string EnclosureState;


        public SpeciesInfoForm(Species selectedSpecies)
        {
            InitializeComponent();
            state = "eddit";
            speciesDTO = new SpeciesDTO();
            enclosureDTO = new EnclosureDTO();
            speciesDTO.SelectSpecies(selectedSpecies);
            PopulateEnclosureCMBX();
            PopulateEndangeredCMBx();
            FillFormWithObject(speciesDTO.SelectedSpecies);

        }

        private void PopulateEndangeredCMBx()
        {
            this.CmbxEndagered.DataSource = Enum.GetValues(typeof(Endangered));
        }

        private void FillFormWithObject(Species selectedSpecies)
        {
            this.TbxName.Text = selectedSpecies.SpeciesName;
            this.NudSpeciesWeight.Value = selectedSpecies.Weight;
            this.NudSpeciesSize.Value = selectedSpecies.Size;
            this.NudSpeciesLifeSpan.Value = selectedSpecies.SpeciesLifespan;
            this.NudSpeciesSpeed.Value = selectedSpecies.Speed;
            this.NudSpeciesIncubation.Value = selectedSpecies.SpeciesIncubationTime;
            this.CmbxEndagered.SelectedItem = selectedSpecies.SpeciesEndangeredLevel;
            string name = selectedSpecies.SpeciesEnclosure.Name;
            this.CmbxEnclosure.SelectedValue = selectedSpecies.SpeciesEnclosure.Name;

        }
        public SpeciesInfoForm()
        {
            InitializeComponent();
            state = "new";
            speciesDTO = new SpeciesDTO();
            enclosureDTO = new EnclosureDTO();
            PopulateEnclosureCMBX();
            PopulateEndangeredCMBx();
        }
        private void PopulateEnclosureCMBX()
        {
            enclosureDTO.GetListEnclosures();

            this.CmbxEnclosure.DisplayMember = "Name";
            this.CmbxEnclosure.ValueMember = "Name";
            this.CmbxEnclosure.DataSource = enclosureDTO.EnclosuresList;

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                edditSpecies(speciesDTO.SelectedSpecies.SpeciesId);

            }
            else
            {
                newSpecies();
                speciesDTO.NewSpeceisEnclosure((Enclosure)CmbxEnclosure.SelectedItem);
                speciesDTO.makeNewSpecies();
            }
            ClearForm();
        }
        private void BtnDeleteSpecies_Click(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                speciesDTO.DeleteSelectedSpecies();
                state = "new";
            }
            ClearForm();
        }
        private void ClearForm()
        {
            edditSpeciesState = 0;
            newSpeciesState = 0;

            edditSpecies = null;
            newSpecies = null;

            this.TbxName.Clear();
            this.NudSpeciesWeight.Value = 0;
            this.NudSpeciesSize.Value = 0;
            this.NudSpeciesLifeSpan.Value = 0;
            this.NudSpeciesSpeed.Value = 0;
            this.NudSpeciesIncubation.Value = 0;

            this.CmbxEnclosure.SelectedIndex = -1;
            this.CmbxEndagered.SelectedIndex = -1;
            CheckStates();
        }
        private void TbxName_TextChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.TbxName.Text.Length == 0)
                {
                    this.Text = speciesDTO.SelectedSpecies.SpeciesName;


                }
                if (this.TbxName.Text != speciesDTO.SelectedSpecies.SpeciesName)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSName))
                    {
                        edditSpecies += EdditSName;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSName))
                    {
                        edditSpecies -= EdditSName;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.TbxName.Text.Length == 0 || this.TbxName.PlaceholderText == "please fill in the name of the species")
                {
                    this.TbxName.PlaceholderText = "please fill in the name of the species";
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesName))
                    {
                        newSpecies -= NewSpeciesName;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesName))
                    {
                        newSpecies += NewSpeciesName;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }
        private void NewSpeciesName()
        {
            speciesDTO.NewSpeciesName(this.TbxName.Text);
        }
        private void EdditSName(Guid id)
        {
            speciesDTO.EdditSpeciesName(id, this.TbxName.Text);
        }
        private void CheckStates()
        {
            CheckStateSpecieseNew();
            CheckStateSpeciesUpdate();
        }
        private void CheckStateSpecieseNew()
        {
            if (newSpeciesState >= 8)
            {
                this.BtnSaveSpecies.Enabled = true;

            }
            else
            {
                this.BtnSaveSpecies.Enabled = false;
            }
        }
        private void CheckStateSpeciesUpdate()
        {
            if (edditSpeciesState != 0)
            {
                this.BtnSaveSpecies.Enabled = true;
            }
            else
            {
                this.BtnSaveSpecies.Enabled = false;
            }
        }
        private void NudSpeciesWeight_ValueChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.NudSpeciesWeight.Value == 0)
                {
                    this.NudSpeciesWeight.Value = speciesDTO.SelectedSpecies.Weight;


                }
                if (this.NudSpeciesWeight.Value != speciesDTO.SelectedSpecies.Weight)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSWeight))
                    {
                        edditSpecies += EdditSWeight;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSWeight))
                    {
                        edditSpecies -= EdditSWeight;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.NudSpeciesWeight.Value == 0)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesWeight))
                    {
                        newSpecies -= NewSpeciesWeight;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesWeight))
                    {
                        newSpecies += NewSpeciesWeight;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void EdditSWeight(Guid id)
        {
            speciesDTO.EdditSpeciesWeight(id, this.NudSpeciesWeight.Value);
        }

        private void NewSpeciesWeight()
        {
            speciesDTO.NewSpeciesWeight(this.NudSpeciesWeight.Value);
        }



        private void NudSpeciesSize_ValueChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.NudSpeciesSize.Value == 0)
                {
                    this.NudSpeciesSize.Value = speciesDTO.SelectedSpecies.Size;


                }
                if (this.NudSpeciesSize.Value != speciesDTO.SelectedSpecies.Size)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSSize))
                    {
                        edditSpecies += EdditSSize;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSSize))
                    {
                        edditSpecies -= EdditSSize;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.NudSpeciesSize.Value == 0)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesSize))
                    {
                        newSpecies -= NewSpeciesSize;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesSize))
                    {
                        newSpecies += NewSpeciesSize;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesSize()
        {
            speciesDTO.NewSpeciesSize(this.NudSpeciesSize.Value);
        }

        private void EdditSSize(Guid id)
        {
            speciesDTO.EdditSpeciesSize(id, this.NudSpeciesSize.Value);
        }

        private void NudSpeciesLifeSpan_ValueChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.NudSpeciesLifeSpan.Value == 0)
                {
                    this.NudSpeciesLifeSpan.Value = speciesDTO.SelectedSpecies.SpeciesLifespan;


                }
                if (this.NudSpeciesLifeSpan.Value != speciesDTO.SelectedSpecies.SpeciesLifespan)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSpeciesLifeSpan))
                    {
                        edditSpecies += EdditSpeciesLifeSpan;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSpeciesLifeSpan))
                    {
                        edditSpecies -= EdditSpeciesLifeSpan;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.NudSpeciesLifeSpan.Value == 0)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesLifeSpan))
                    {
                        newSpecies -= NewSpeciesLifeSpan;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesLifeSpan))
                    {
                        newSpecies += NewSpeciesLifeSpan;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesLifeSpan()
        {
            speciesDTO.NewSpeciesLifeSpan(this.NudSpeciesLifeSpan.Value);
        }

        private void EdditSpeciesLifeSpan(Guid id)
        {
            speciesDTO.EdditSpeciesLifeSpan(id, this.NudSpeciesLifeSpan.Value);
        }

        private void NudSpeciesSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.NudSpeciesSpeed.Value == 0)
                {
                    this.NudSpeciesSpeed.Value = speciesDTO.SelectedSpecies.Speed;


                }
                if (this.NudSpeciesSpeed.Value != speciesDTO.SelectedSpecies.Speed)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSpeciesSpeed))
                    {
                        edditSpecies += EdditSpeciesSpeed;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSpeciesSpeed))
                    {
                        edditSpecies -= EdditSpeciesSpeed;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.NudSpeciesSpeed.Value == 0)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesLifeSpeed))
                    {
                        newSpecies -= NewSpeciesLifeSpeed;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesLifeSpeed))
                    {
                        newSpecies += NewSpeciesLifeSpeed;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesLifeSpeed()
        {
            speciesDTO.NewSpeciesSpeed(this.NudSpeciesSpeed.Value);
        }

        private void EdditSpeciesSpeed(Guid id)
        {
            speciesDTO.EdditSPeciesSpeed(id, this.NudSpeciesSpeed.Value);
        }

        private void NudSpeciesIncubation_ValueChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                if (this.NudSpeciesIncubation.Value == 0)
                {
                    this.NudSpeciesIncubation.Value = speciesDTO.SelectedSpecies.SpeciesIncubationTime;


                }
                if (this.NudSpeciesIncubation.Value != speciesDTO.SelectedSpecies.SpeciesIncubationTime)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSpeciesIncubationTime))
                    {
                        edditSpecies += EdditSpeciesIncubationTime;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSpeciesIncubationTime))
                    {
                        edditSpecies -= EdditSpeciesIncubationTime;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.NudSpeciesIncubation.Value == 0)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesLifeIncubationTime))
                    {
                        newSpecies -= NewSpeciesLifeIncubationTime;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesLifeIncubationTime))
                    {
                        newSpecies += NewSpeciesLifeIncubationTime;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesLifeIncubationTime()
        {
            speciesDTO.NewSPeciesIncubation(this.NudSpeciesIncubation.Value);
        }

        private void EdditSpeciesIncubationTime(Guid id)
        {
            speciesDTO.EdditSpeciesIncubation(id, this.NudSpeciesIncubation.Value);
        }

        private void CmbxEndagered_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Endangered endangered;
            Enum.TryParse<Endangered>(this.CmbxEndagered.SelectedItem.ToString(), out endangered);
            if (state == "eddit")
            {
                if (this.CmbxEndagered.SelectedIndex == -1)
                {
                    this.CmbxEndagered.SelectedItem = speciesDTO.SelectedSpecies.SpeciesEndangeredLevel;


                }
                if (endangered != speciesDTO.SelectedSpecies.SpeciesEndangeredLevel)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSpeciesEndangeredLevel))
                    {
                        edditSpecies += EdditSpeciesEndangeredLevel;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSpeciesEndangeredLevel))
                    {
                        edditSpecies -= EdditSpeciesEndangeredLevel;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                if (this.CmbxEndagered.SelectedIndex == -1)
                {
                    MessageBox.Show("please fill in species endangered level");
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesEndangeredLevel))
                    {
                        newSpecies -= NewSpeciesEndangeredLevel;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesEndangeredLevel))
                    {
                        newSpecies += NewSpeciesEndangeredLevel;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesEndangeredLevel()
        {
            Endangered endangered;
            Enum.TryParse<Endangered>(this.CmbxEndagered.SelectedItem.ToString(), out endangered);
            speciesDTO.NewSpeciesEndangeredL(endangered);

        }

        private void EdditSpeciesEndangeredLevel(Guid id)
        {
            Endangered endangered;
            Enum.TryParse<Endangered>(this.CmbxEndagered.SelectedItem.ToString(), out endangered);
            speciesDTO.EdditSpeciesEndangeredL(id, endangered);
        }

        private void BtnNewEnclosure_Click(object sender, EventArgs e)
        {
            EnclosureState = "new";
            this.GrbxEnclosure.Enabled = true;
            this.GrbxEnclosure.Visible = true;
            this.TbxEName.Clear();
        }

        private void CmbxEnclosure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (state == "eddit")
            {
                this.BtnEditEnclosure.Enabled = true;
                this.BtnEditEnclosure.Visible = true;
                if (this.CmbxEnclosure.SelectedIndex == -1)
                {
                    this.CmbxEnclosure.SelectedItem = speciesDTO.SelectedSpecies.SpeciesEnclosure;


                }
                if ((Enclosure)this.CmbxEnclosure.SelectedItem != speciesDTO.SelectedSpecies.SpeciesEnclosure)
                {
                    if (edditSpecies == null || !edditSpecies.GetInvocationList().Contains(EdditSpeciesEnclosure))
                    {
                        edditSpecies += EdditSpeciesEnclosure;
                        edditSpeciesState += 1;
                    }
                }
                else
                {
                    if (edditSpecies != null && edditSpecies.GetInvocationList().Contains(EdditSpeciesEnclosure))
                    {
                        edditSpecies -= EdditSpeciesEnclosure;
                        edditSpeciesState -= 1;
                    }

                }
                CheckStateSpeciesUpdate();

            }
            else
            {
                this.BtnEditEnclosure.Enabled = false;
                this.BtnEditEnclosure.Visible = false;
                if (this.CmbxEndagered.SelectedIndex == -1)
                {
                    if (newSpecies != null && newSpecies.GetInvocationList().Contains(NewSpeciesEnclosurel))
                    {
                        newSpecies -= NewSpeciesEnclosurel;
                        newSpeciesState -= 1;
                    }

                }
                else
                {
                    if (newSpecies == null || !newSpecies.GetInvocationList().Contains(NewSpeciesEnclosurel))
                    {
                        newSpecies += NewSpeciesEnclosurel;
                        newSpeciesState += 1;
                    }
                }
                CheckStateSpecieseNew();
            }
        }

        private void NewSpeciesEnclosurel()
        {
            Enclosure enclosure = this.CmbxEnclosure.SelectedItem as Enclosure;
            speciesDTO.NewSpeceisEnclosure(enclosure);
        }

        private void EdditSpeciesEnclosure(Guid id)
        {
            Enclosure enclosure = this.CmbxEnclosure.SelectedItem as Enclosure;
            speciesDTO.EdditSpeciesEnclosure(id, enclosure);
        }

        private void BtnEditEnclosure_Click(object sender, EventArgs e)
        {
            EnclosureState = "eddit";
            this.GrbxEnclosure.Enabled = true;
            this.GrbxEnclosure.Visible = true;

            this.BtnDeleteEnclosure.Enabled = true;
            this.BtnDeleteEnclosure.Visible = true;

            Enclosure enclosure = this.CmbxEnclosure.SelectedItem as Enclosure;
            this.TbxEName.Text = enclosure.Name;
        }

        private void BtnSaveEnclosure_Click(object sender, EventArgs e)
        {
            if (EnclosureState == "new")
            {
                enclosureDTO.NewEnclosure(this.TbxEName.Text);
                MessageBox.Show("New enclosure was made");
                ClearGrBx();
            }
            else
            {
                Enclosure enclosure = this.CmbxEnclosure.SelectedItem as Enclosure;
                enclosureDTO.EdditEnclosure(enclosure, this.TbxEName.Text);
                MessageBox.Show("enclosure name wass eddited");
                ClearGrBx();

            }

            PopulateEnclosureCMBX();
            this.GrbxEnclosure.Visible = false;
            this.GrbxEnclosure.Enabled = false;
        }

        private void ClearGrBx()
        {
            this.TbxEName.Clear();
        }

        private void BtnDeleteEnclosure_Click(object sender, EventArgs e)
        {
            Enclosure enclosure = this.CmbxEnclosure.SelectedItem as Enclosure;
            enclosureDTO.DeleteEnclosure(enclosure.Id);

            PopulateEnclosureCMBX();
            this.GrbxEnclosure.Visible = false;
            this.GrbxEnclosure.Enabled = false;

            this.BtnDeleteEnclosure.Enabled = false;
            this.BtnDeleteEnclosure.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.GrbxEnclosure.Visible = false;
            this.GrbxEnclosure.Enabled = false;

        }
    }
}
