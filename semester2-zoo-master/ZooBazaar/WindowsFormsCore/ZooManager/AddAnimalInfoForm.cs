using BLL.Interfaces.Services;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.DTO;
using static System.Windows.Forms.AxHost;
using BLL.Interfaces.Services;
using DAL.Repositories;

namespace WindowsFormApp
{
    public partial class AddAnimalInfoForm : Form
    {
        private AnimalService animalService;
        private AnimalDTO animalDTO;
        private SpeciesDTO speciesDTO;

        private delegate void EdditAnimal(Guid id);
        private EdditAnimal edditAnimal;
        private int edditAnimalState;
        private delegate void NewAnimal();
        private NewAnimal newAnimal;
        private int newAnimalState;
        private Species _selectedSpecies;


        public AddAnimalInfoForm(Species selectedSpecies)
        {
            InitializeComponent();
            animalService = new AnimalService(new AnimalRepository(), new ContentRepository());
            _selectedSpecies = selectedSpecies;

            animalDTO = new AnimalDTO(new DAL.Repositories.AnimalRepository(), new DAL.Repositories.ContentRepository());
            speciesDTO = new SpeciesDTO();
            speciesDTO.SelectSpecies(selectedSpecies);

            this.CmbxSex.DataSource = Enum.GetValues(typeof(Sex));
            animalDTO.GetListOfAnimals(selectedSpecies);

            PoppulateList();
        }

        private void PoppulateList()
        {
            this.CmbxListAnimals.DisplayMember = "AnimalName";
            this.CmbxListAnimals.ValueMember = "AnimalName";
            this.CmbxListAnimals.DataSource = animalDTO.ListOfAnimals;

        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                edditAnimal(animalDTO.SelectedAnimal.AnimalId);
            }
            else
            {
                string name = TbxName.Text;
                int weight = Convert.ToInt32(NudSpeciesWeight.Value);
                int size = Convert.ToInt32(NudSpeciesSize.Value);
                int speed = Convert.ToInt32(NudSpeciesSpeed.Value);
                DateTime birthdate = DtpBirthdate.Value;
                Sex sex = (Sex)CmbxSex.SelectedItem;
                DateOnly arrival = DateOnly.FromDateTime(DtpAnimalAriveDate.Value);
                DateOnly? leave = DateOnly.FromDateTime(DtpAnimalLeaveDate.Value);

                animalService.CreateAnimal(_selectedSpecies, name, weight, size, speed, birthdate, sex, arrival, leave);
            }
            ClearForm();
            PoppulateList();
        }


        private void CmbxListAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                Animal animal = (Animal)this.CmbxListAnimals.SelectedItem;
                animalDTO.SelectAnimal(animal);
                FillFormWithIndex();
                this.BtnNewAnimal.Enabled = true;
                this.BtnNewAnimal.Visible = true;
            }
            else
            {
                ClearForm();
            }
        }

        private void FillFormWithIndex()
        {
            this.TbxName.Text = animalDTO.SelectedAnimal.AnimalName;
            this.CmbxSex.SelectedItem = animalDTO.SelectedAnimal.Sex;
            this.DtpBirthdate.Value = animalDTO.SelectedAnimal.Birthdate;
            this.DtpAnimalAriveDate.Value = animalDTO.SelectedAnimal.ArrivalDate;
            if (animalDTO.SelectedAnimal.ArrivalDate == animalDTO.SelectedAnimal.LeaveDate)
            {
                this.DtpAnimalLeaveDate.Value = (DateTime)animalDTO.SelectedAnimal.LeaveDate;
                this.CbxLeaveDate.Enabled = true;
            }
            else
            {
                this.DtpAnimalLeaveDate.Value = (DateTime)animalDTO.SelectedAnimal.LeaveDate;
            }
            this.NudSpeciesWeight.Value = animalDTO.SelectedAnimal.Weight;
            this.NudSpeciesSize.Value = animalDTO.SelectedAnimal.Size;
            this.NudSpeciesSpeed.Value = animalDTO.SelectedAnimal.Speed;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            newAnimal = null;
            edditAnimal = null;

            this.CmbxListAnimals.SelectedIndex = -1;
            this.TbxName.Clear();
            this.NudSpeciesWeight.Value = 0;
            this.NudSpeciesSize.Value = 0;
            this.NudSpeciesSpeed.Value = 0;
            this.CmbxSex.SelectedIndex = -1;

        }
        private void CheckNewAnimalState()
        {
            if (newAnimalState >= 3)
            {
                this.BtnSaveAnimal.Enabled = true;
            }
            else
            {
                this.BtnSaveAnimal.Enabled = false;
            }
        }

        private void CheckEdditAnimalState()
        {
            if (edditAnimalState > 0)
            {
                this.BtnSaveAnimal.Enabled = true;
            }
            else
            {
                this.BtnSaveAnimal.Enabled = false;
            }
        }

        private void DtpBirthdate_Leave(object sender, EventArgs e)
        {

        }

        private void AddNewAnimalBirthdate()
        {
            animalDTO.newAnimalBirthDate(this.DtpBirthdate.Value);
        }

        private void EdditBirhtDate(Guid Animalid)
        {
            animalDTO.EdditAnimalBirthDate(Animalid, Convert.ToDateTime(this.DtpBirthdate.Value));
        }

        private void TbxName_Leave(object sender, EventArgs e)
        {

        }

        private void newAnimalName()
        {
            animalDTO.NewAnimalName(this.TbxName.Text);
        }

        private void EdditAnimalName(Guid Animalid)
        {
            animalDTO.EdditAnimalName(Animalid, this.TbxName.Text);
        }

        private void CmbxSex_Leave(object sender, EventArgs e)
        {

        }

        private void newAnimalSex()
        {
            Sex sex = (Sex)Enum.Parse(typeof(Sex), this.CmbxSex.Text);
            animalDTO.NewAnimalSex(sex);
        }

        private void EdditAnimalSex(Guid Animalid)
        {
            Sex sex = (Sex)Enum.Parse(typeof(Sex), this.CmbxSex.Text);
            animalDTO.EdditAnimalSex(Animalid, sex);
        }

        private void BtnDeleteAnimal_Click(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                animalDTO.NullSelectedAnimal();
            }
            ClearForm();
        }

        private void CbxLeaveDate_CheckedChanged(object sender, EventArgs e)
        {

            if (this.CbxLeaveDate.Checked)
            {
                this.DtpAnimalLeaveDate.Enabled = false;
                if (this.CmbxListAnimals.SelectedIndex != -1)
                {
                    animalDTO.EdditAnimalLeaveD(animalDTO.SelectedAnimal.AnimalId, DateOnly.FromDateTime(this.DtpAnimalAriveDate.Value));
                }
                else
                {
                    animalDTO.NewAnimalLeaveDate(DateOnly.FromDateTime(this.DtpAnimalAriveDate.Value));
                }
            }
            else
            {
                this.DtpAnimalLeaveDate.Enabled = true;
            }
        }

        private void DtpAnimalAriveDate_Leave(object sender, EventArgs e)
        {

        }

        private void AddNewAnimalArivalDate()
        {
            animalDTO.NewAnimalArivalD(DateOnly.FromDateTime(this.DtpAnimalAriveDate.Value));
        }

        private void EdditArivalDate(Guid id)
        {
            animalDTO.EdditAnimalArrivalDate(id, DateOnly.FromDateTime(this.DtpAnimalAriveDate.Value));
        }

        private void DtpAnimalLeaveDate_Leave(object sender, EventArgs e)
        {

        }

        private void AddNewAnimalLeaveDate()
        {
            if (this.CbxLeaveDate.Checked)
            {
                animalDTO.NewAnimalLeaveDate(DateOnly.MinValue);
            }
            else
            {
                animalDTO.NewAnimalLeaveDate(DateOnly.FromDateTime(this.DtpAnimalLeaveDate.Value));
            }
        }

        private void EdditLeaveDate(Guid id)
        {
            if (this.CbxLeaveDate.Checked)
            {
                animalDTO.EdditAnimalLeaveD(id, DateOnly.MinValue);
            }
            else
            {
                animalDTO.EdditAnimalLeaveD(id, DateOnly.FromDateTime(this.DtpAnimalLeaveDate.Value));
            }
        }

        private void NudSpeciesWeight_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.NudSpeciesWeight.Value == 0)
                {
                    this.NudSpeciesWeight.Value = animalDTO.SelectedAnimal.Weight;


                }
                if (this.NudSpeciesWeight.Value != animalDTO.SelectedAnimal.Weight)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditAnimalWeight))
                    {
                        edditAnimal += EdditAnimalWeight;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditAnimalWeight))
                    {
                        edditAnimal -= EdditAnimalWeight;
                        edditAnimalState -= 1;
                    }

                }
                CheckEdditAnimalState();

            }
            else
            {
                if (this.NudSpeciesWeight.Value == 0)
                {
                    if (edditAnimal != null && newAnimal.GetInvocationList().Contains(newAnimalWeight))
                    {
                        newAnimal -= newAnimalWeight;
                        newAnimalState -= 1;
                    }

                }
                else
                {
                    if (newAnimal == null || !newAnimal.GetInvocationList().Contains(newAnimalWeight))
                    {
                        newAnimal += newAnimalWeight;
                        newAnimalState += 1;
                    }
                }
                CheckNewAnimalState();
            }
        }

        private void newAnimalWeight()
        {
            animalDTO.NewAnimalWeight(Convert.ToInt32(this.NudSpeciesWeight.Value));
        }

        private void EdditAnimalWeight(Guid id)
        {
            animalDTO.EdditAnimalWeight(id, Convert.ToInt32(this.NudSpeciesWeight.Value));
        }

        private void NudSpeciesSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.NudSpeciesSize.Value == 0)
                {
                    this.NudSpeciesSize.Value = animalDTO.SelectedAnimal.Size;


                }
                if (this.NudSpeciesSize.Value != animalDTO.SelectedAnimal.Size)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditAnimalSize))
                    {
                        edditAnimal += EdditAnimalSize;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditAnimalSize))
                    {
                        edditAnimal -= EdditAnimalSize;
                        edditAnimalState -= 1;
                    }

                }
                CheckEdditAnimalState();

            }
            else
            {
                if (this.NudSpeciesSize.Value == 0)
                {
                    if (edditAnimal != null && newAnimal.GetInvocationList().Contains(newAnimalSize))
                    {
                        newAnimal -= newAnimalSize;
                        newAnimalState -= 1;
                    }

                }
                else
                {
                    if (newAnimal == null || !newAnimal.GetInvocationList().Contains(newAnimalSize))
                    {
                        newAnimal += newAnimalSize;
                        newAnimalState += 1;
                    }
                }
                CheckNewAnimalState();
            }
        }

        private void newAnimalSize()
        {
            animalDTO.NewAnimalSize(Convert.ToInt32(this.NudSpeciesSize.Value));
        }

        private void EdditAnimalSize(Guid id)
        {
            animalDTO.EdditANimalSize(id, Convert.ToInt32(this.NudSpeciesSize.Value));
        }

        private void NudSpeciesSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.NudSpeciesSpeed.Value == 0)
                {
                    this.NudSpeciesSpeed.Value = animalDTO.SelectedAnimal.Speed;


                }
                if (this.NudSpeciesSpeed.Value != animalDTO.SelectedAnimal.Speed)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditAnimalSpeed))
                    {
                        edditAnimal += EdditAnimalSpeed;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditAnimalSpeed))
                    {
                        edditAnimal -= EdditAnimalSpeed;
                        edditAnimalState -= 1;
                    }

                }
                CheckEdditAnimalState();

            }
            else
            {
                if (this.NudSpeciesSpeed.Value == 0)
                {
                    if (edditAnimal != null && newAnimal.GetInvocationList().Contains(newAnimalSpeed))
                    {
                        newAnimal -= newAnimalSpeed;
                        newAnimalState -= 1;
                    }

                }
                else
                {
                    if (newAnimal == null || !newAnimal.GetInvocationList().Contains(newAnimalSpeed))
                    {
                        newAnimal += newAnimalSpeed;
                        newAnimalState += 1;
                    }
                }
                CheckNewAnimalState();
            }
        }

        private void newAnimalSpeed()
        {
            animalDTO.NewAnimalSpeed(Convert.ToInt32(this.NudSpeciesSpeed.Value));
        }

        private void EdditAnimalSpeed(Guid id)
        {
            animalDTO.EdditAnimalSpeed(id, Convert.ToInt32(this.NudSpeciesSpeed.Value));
        }

        private void BtnNewAnimal_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void TbxName_TextChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.TbxName.Text.Length == 0)
                {
                    this.TbxName.Text = animalDTO.SelectedAnimal.AnimalName;


                }
                if (this.TbxName.Text != animalDTO.SelectedAnimal.AnimalName)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditAnimalName))
                    {
                        edditAnimal += EdditAnimalName;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditAnimalName))
                    {
                        edditAnimal -= EdditAnimalName;
                        edditAnimalState -= 1;
                    }

                }
                CheckEdditAnimalState();

            }
            else
            {
                if (this.TbxName.Text.Length == 0 || this.TbxName.PlaceholderText == "please fill in the animal name")
                {
                    this.TbxName.PlaceholderText = "please fill in the animal name";
                    if (newAnimal != null && newAnimal.GetInvocationList().Contains(newAnimalName))
                    {
                        newAnimal -= newAnimalName;
                        newAnimalState -= 1;
                    }

                }
                else
                {
                    if (newAnimal == null || !newAnimal.GetInvocationList().Contains(newAnimalName))
                    {
                        newAnimal += newAnimalName;
                        newAnimalState += 1;
                    }
                }
                CheckNewAnimalState();
            }
        }

        private void DtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.DtpBirthdate.Value.Date != animalDTO.SelectedAnimal.Birthdate)
                {
                    if (edditAnimal == null! || edditAnimal.GetInvocationList().Contains(EdditBirhtDate))
                    {
                        edditAnimal += EdditBirhtDate;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditBirhtDate))
                    {
                        edditAnimal -= EdditBirhtDate;
                        edditAnimalState -= 1;
                    }
                }
                CheckEdditAnimalState();
            }
            else
            {
                if (newAnimal == null || !newAnimal.GetInvocationList().Contains(AddNewAnimalBirthdate))
                {
                    newAnimal += AddNewAnimalBirthdate;
                    newAnimalState += 1;
                }
            }
            CheckNewAnimalState();

        }

        private void CmbxSex_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                if (this.CmbxSex.SelectedIndex == -1)
                {
                    this.CmbxSex.Text = animalDTO.SelectedAnimal.Sex.ToString();


                }
                if (this.TbxName.Text != animalDTO.SelectedAnimal.Sex.ToString())
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditAnimalSex))
                    {
                        edditAnimal += EdditAnimalSex;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditAnimalSex))
                    {
                        edditAnimal -= EdditAnimalSex;
                        edditAnimalState -= 1;
                    }

                }
                CheckEdditAnimalState();

            }
            else
            {
                if (this.CmbxSex.Text.Length == 0 || this.CmbxSex.Text == "please select the animal sex")
                {
                    this.CmbxSex.Text = "please select the animal sex";
                    if (newAnimal != null && newAnimal.GetInvocationList().Contains(newAnimalSex))
                    {
                        newAnimal -= newAnimalSex;
                        newAnimalState -= 1;
                    }

                }
                else
                {
                    if (newAnimal == null || !newAnimal.GetInvocationList().Contains(newAnimalSex))
                    {
                        newAnimal += newAnimalSex;
                        newAnimalState += 1;
                    }
                }
                CheckNewAnimalState();
            }
        }

        private void DtpAnimalAriveDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {

                DateOnly selectedDate = DateOnly.FromDateTime(this.DtpAnimalAriveDate.Value);
                DateOnly animalArrivalDate = DateOnly.FromDateTime(animalDTO.SelectedAnimal.ArrivalDate);

                if (selectedDate != animalArrivalDate)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditArivalDate))
                    {
                        edditAnimal += EdditArivalDate;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditArivalDate))
                    {
                        edditAnimal -= EdditArivalDate;
                        edditAnimalState -= 1;
                    }
                }
                CheckEdditAnimalState();
            }
            else
            {
                if (newAnimal == null || !newAnimal.GetInvocationList().Contains(AddNewAnimalBirthdate))
                {
                    newAnimal += AddNewAnimalArivalDate;
                    newAnimalState += 1;
                }
            }
            CheckNewAnimalState();
        }

        private void DtpAnimalLeaveDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.CmbxListAnimals.SelectedIndex != -1)
            {
                DateOnly selectedLeaveDate = DateOnly.FromDateTime(this.DtpAnimalLeaveDate.Value);
                DateOnly animalLeaveDate = DateOnly.FromDateTime((DateTime)animalDTO.SelectedAnimal.LeaveDate);

                if (selectedLeaveDate != animalLeaveDate)
                {
                    if (edditAnimal == null || !edditAnimal.GetInvocationList().Contains(EdditLeaveDate))
                    {
                        edditAnimal += EdditLeaveDate;
                        edditAnimalState += 1;
                    }
                }
                else
                {
                    if (edditAnimal != null && edditAnimal.GetInvocationList().Contains(EdditLeaveDate))
                    {
                        edditAnimal -= EdditLeaveDate;
                        edditAnimalState -= 1;
                    }
                }
                CheckEdditAnimalState();
            }
            else
            {
                if (newAnimal == null || !newAnimal.GetInvocationList().Contains(AddNewAnimalLeaveDate))
                {
                    newAnimal += AddNewAnimalLeaveDate;
                    newAnimalState += 1;
                }
            }
            CheckNewAnimalState();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}