using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsCore.ZooManager
{
    public partial class ContentAndViewableForm : Form
    {
        private bool StateEddit;

        private delegate void EdditContent(Guid contentId);
        private EdditContent edditContent;
        private int edditState = 0;

        private delegate void NewContent();
        private NewContent newContent;
        private int newState = 0;

        private AnimalDTO animalDTO;
        private SpeciesDTO speciesDTO;
        private EnclosureDTO enclosureDTO;
        private ContentDTO contentDTO;

        private string filepath = GetFilePath(); /*@"C:\myFiles\fontys folder\SEM 2 Documents\project_Group\Project\semester2-zoo\ZooBazaar\ZooBazaar_WebApp\wwwroot\media\contentFolder\";*/



        private string state;
        public ContentAndViewableForm()
        {
            InitializeComponent();

            this.CmbxOrder.DataSource = Enum.GetValues(typeof(WebContentOrder));

            animalDTO = new AnimalDTO(new DAL.Repositories.AnimalRepository(), new DAL.Repositories.ContentRepository());
            speciesDTO = new SpeciesDTO();
            enclosureDTO = new EnclosureDTO();
            contentDTO = new ContentDTO();


            PopulateLsBxEnclosures();

        }
        private static string GetFilePath()
        {
            string directoryC = Environment.CurrentDirectory;
            string[] splt = directoryC.Split(new string[] { @"\WindowsFormsCore" }, StringSplitOptions.None);
            string path = Path.Combine(splt[0], @"ZooBazaar_WebApp\wwwroot\media\contentFolder\");


            return path;
        }

        private void FillContentGrBxWithObjec(object? selectedItem)
        {
            try
            {
                if (selectedItem.GetType() == typeof(Animal))
                {
                    state = "Animal";
                    Animal animal = (Animal)selectedItem;
                    animalDTO.DeselectAnimal();
                    animalDTO.SelectAnimal(animal);
                    contentDTO.GetAnimalContent(animal.AnimalId);

                }
                if (selectedItem.GetType() == typeof(Species))
                {
                    state = "Species";
                    Species species = (Species)selectedItem;

                    speciesDTO.DeselectSpecies();
                    speciesDTO.SelectSpecies(species);
                    contentDTO.GetSpeciesContents(species.SpeciesId);
                }
                if (selectedItem.GetType() == typeof(Enclosure))
                {
                    state = "Enclosure";

                    Enclosure enclosure = (Enclosure)selectedItem;
                    enclosureDTO.DeselectEnclosure();
                    enclosureDTO.SelectEnclosure(enclosure);
                    contentDTO.GetEnclosureContents(enclosure.Id);
                }
            }
            catch (Exception ex)
            {

            }

            RefillCmbxcontents();



        }

        private void BtnAddToWebsite_Click(object sender, EventArgs e)
        {
            if (this.LsBxNotOnline.SelectedIndex != -1)
            {
                if (this.LsBxNotOnline.SelectedItem.GetType() == typeof(Animal))
                {
                    Animal animal = (Animal)this.LsBxNotOnline.SelectedItem;
                    animalDTO.SelectAnimal(animal);
                    animalDTO.EdditShowStatus(true);

                }
                else if (this.LsBxNotOnline.SelectedItem.GetType() == typeof(Species))
                {
                    Species species = (Species)this.LsBxNotOnline.SelectedItem;
                    speciesDTO.SelectSpecies(species);
                    speciesDTO.EdditSpeciesShowStatus(true);
                }
                else if (this.LsBxNotOnline.SelectedItem.GetType() == typeof(Enclosure))
                {
                    Enclosure enclosure = (Enclosure)this.LsBxNotOnline.SelectedItem;
                    enclosureDTO.SelectEnclosure(enclosure);
                    enclosureDTO.EdditShowStatus(true);
                }
                ReloadListBoxes();
            }

        }

        private void BtnRemoveFormWebSite_Click(object sender, EventArgs e)
        {
            if (this.LsBxOnline.SelectedIndex != -1)
            {
                if (this.LsBxOnline.SelectedItem.GetType() == typeof(Animal))
                {
                    Animal animal = (Animal)this.LsBxOnline.SelectedItem;
                    animalDTO.SelectAnimal(animal);
                    animalDTO.EdditShowStatus(false);

                }
                else if (this.LsBxOnline.SelectedItem.GetType() == typeof(Species))
                {
                    Species species = (Species)this.LsBxOnline.SelectedItem;
                    speciesDTO.SelectSpecies(species);
                    speciesDTO.EdditSpeciesShowStatus(false);
                }
                else if (this.LsBxOnline.SelectedItem.GetType() == typeof(Enclosure))
                {
                    Enclosure enclosure = (Enclosure)this.LsBxOnline.SelectedItem;
                    enclosureDTO.SelectEnclosure(enclosure);
                    enclosureDTO.EdditShowStatus(false);
                }
                ReloadListBoxes();
            }
        }

        private void CmbxListContents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                StateEddit = true;
                Content content = (Content)this.CmbxListContents.SelectedItem;
                contentDTO.SelectContent(content);

                this.BtnDeleteNote.Enabled = true;
                FillContentGrbXForm();
            }
            else
            {
                this.BtnDeleteNote.Enabled = false;
                StateEddit = false;
                ClearContentForm();
            }
        }

        private void FillContentGrbXForm()
        {
            Content content = (Content)this.CmbxListContents.SelectedItem;
            this.TbxTitleContent.Text = content.Title;
            this.TbxContentText.Text = content.Text;
            this.CmbxOrder.SelectedItem = content.Order;
            this.TbxImageLink.Text = content.ImageUrl;

        }

        private void ClearContentForm()
        {
            newState = 0;
            newContent = null;

            edditState = 0;
            edditContent = null;
            this.CmbxListContents.SelectedIndex = -1;

            this.TbxContentText.Clear();
            this.TbxTitleContent.Clear();

            this.CmbxOrder.SelectedIndex = -1;

            this.TbxImageLink.Clear();
            this.TbxImageLink.PlaceholderText = "Please paste image link here";



        }

        private void RefillCmbxcontents()
        {
            if (contentDTO.ListContents.Count > 0)
            {
                this.CmbxListContents.DataSource = null;
                this.CmbxListContents.DisplayMember = "Title";
                this.CmbxListContents.ValueMember = "Title";
                this.CmbxListContents.DataSource = contentDTO.ListContents;
            }
            this.CmbxListContents.SelectedItem = null;
        }

        private void TbxTitleContent_TextChanged(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                if (this.TbxTitleContent.Text.Length == 0)
                {
                    this.TbxTitleContent.Text = contentDTO.SelectedContent.Title;
                }
                else
                {
                    if (edditContent == null || !edditContent.GetInvocationList().Contains(EdditContentTitle))
                    {
                        edditContent += EdditContentTitle;
                        edditState += 1;
                    }
                }
                if (this.TbxTitleContent.Text == contentDTO.SelectedContent.Title)
                {
                    if (edditContent != null && edditContent.GetInvocationList().Contains(EdditContentTitle))
                    {
                        edditContent -= EdditContentTitle;
                        edditState -= 1;

                    }
                }
            }
            else
            {
                if (this.TbxTitleContent.Text.Length == 0)
                {
                    this.TbxTitleContent.PlaceholderText = "Please provide a tittle";
                }
                else
                {
                    if (newContent == null || !newContent.GetInvocationList().Contains(NewContentTitle))
                    {
                        newContent += NewContentTitle;
                        newState += 1;
                    }

                    if (newContent != null && newContent.GetInvocationList().Contains(NewContentTitle))
                    {
                        newContent -= NewContentTitle;
                        newState -= 1;
                    }
                }


            }

            CheckStateEddit();
        }

        private void NewContentTitle()
        {
            contentDTO.NewContentTitle(this.TbxTitleContent.Text);
        }

        private void EdditContentTitle(Guid contentId)
        {
            contentDTO.EdditContentTitle(contentId, this.TbxTitleContent.Text);
        }

        private void TbxContentText_TextChanged(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                if (this.TbxContentText.Text.Length == 0)
                {
                    this.TbxContentText.Text = contentDTO.SelectedContent.Text;
                }
                else
                {
                    if (edditContent == null || !edditContent.GetInvocationList().Contains(EdditContentText))
                    {
                        edditContent += EdditContentText;
                        edditState += 1;
                    }
                }
                if (this.TbxContentText.Text == contentDTO.SelectedContent.Text)
                {
                    if (edditContent != null && edditContent.GetInvocationList().Contains(EdditContentText))
                    {
                        edditContent -= EdditContentText;
                        edditState -= 1;
                    }
                }
            }
            else
            {
                if (this.TbxContentText.Text.Length == 0)
                {
                    this.TbxContentText.PlaceholderText = "Please provide a tittle";
                }
                else
                {
                    if (newContent == null || !newContent.GetInvocationList().Contains(NewContentText))
                    {
                        newContent += NewContentText;
                        newState += 1;
                    }
                    if (newContent != null && newContent.GetInvocationList().Contains(NewContentText))
                    {
                        newContent -= NewContentText;
                        newState -= 1;
                    }
                }

            }
            CheckStateEddit();
        }

        private void NewContentText()
        {
            contentDTO.NewContentText(this.TbxContentText.Text);
        }

        private void EdditContentText(Guid contentId)
        {
            contentDTO.EdditContentText(contentId, this.TbxContentText.Text);
        }

        private void CmbxOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WebContentOrder webContentOrder = (WebContentOrder)this.CmbxOrder.SelectedItem;

            if (this.CmbxListContents.SelectedIndex != -1)
            {
                if (this.CmbxOrder.SelectedIndex == -1)
                {
                    this.CmbxOrder.SelectedItem = contentDTO.SelectedContent.Order;
                }
                else
                {
                    if (edditContent == null || !edditContent.GetInvocationList().Contains(EdditContentOrder))
                    {
                        edditContent += EdditContentOrder;
                        edditState += 1;
                    }
                }
                if (webContentOrder == contentDTO.SelectedContent.Order)
                {
                    if (edditContent != null && edditContent.GetInvocationList().Contains(EdditContentOrder))
                    {
                        edditContent -= EdditContentOrder;
                        edditState -= 1;
                    }
                }
            }
            else
            {
                if (this.CmbxOrder.Text.Length == 0 || this.CmbxOrder.Text == "Please provide an Order")
                {
                    this.CmbxOrder.Text = "Please provide an Order";
                }
                else
                {
                    if (newContent == null || !newContent.GetInvocationList().Contains(NewContentOrdert))
                    {
                        newContent += NewContentOrdert;
                        newState += 1;
                    }
                    if (newContent != null && newContent.GetInvocationList().Contains(NewContentOrdert))
                    {
                        newContent -= NewContentOrdert;
                        newState -= 1;
                    }
                }
            }
            CheckStateEddit();
        }







        private void CheckStateEddit()
        {
            if (edditState > 0 || newState >= 3)
            {
                this.BtnSaveNote.Enabled = true;

            }
            else
            {
                this.BtnSaveNote.Enabled = false;
            }
        }

        private void NewContentOrdert()
        {
            WebContentOrder wCO = (WebContentOrder)this.CmbxOrder.SelectedItem;
            contentDTO.NewContentOrder(wCO);
        }

        private void EdditContentOrder(Guid contentId)
        {
            WebContentOrder wCO = (WebContentOrder)this.CmbxOrder.SelectedItem;
            contentDTO.EdditContentOrder(contentId, wCO);
        }

        private void BtnNewContent_Click(object sender, EventArgs e)
        {
            RefillCmbxcontents();
            ClearContentForm();
        }


        private void NewContentImageUrl()
        {
            contentDTO.NewContentImageUrl(this.TbxImageLink.Text);
        }

        private void EdditContentImageUrl(Guid contentId)
        {
            contentDTO.EdditContentImageUrl(contentId, this.TbxImageLink.Text);
        }

        private void BtnDeleteNote_Click(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                contentDTO.DeleSelectedContent();
                ClearContentForm();
                RefillCmbxcontents();
            }

        }

        private void BtnSaveNote_Click(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                edditContent(contentDTO.SelectedContent.Id);
            }
            else
            {
                if (state == "Animal")
                {
                    newContent();
                    contentDTO.NewAnimalContent(animalDTO.SelectedAnimal);
                }
                if (state == "Species")
                {
                    newContent();
                    contentDTO.NewSpeciesContent(speciesDTO.SelectedSpecies);
                }
                if (state == "Enclosure")
                {
                    newContent();
                    contentDTO.NewEnclosureContent(enclosureDTO.SelectedEnclosure);
                }
            }
            if (this.LsBxNotOnline.SelectedIndex != -1)
            {
                FillContentGrBxWithObjec(this.LsBxNotOnline.SelectedItem);
            }
            if (this.LsBxOnline.SelectedIndex != -1)
            {
                FillContentGrBxWithObjec(this.LsBxNotOnline.SelectedItem);
            }
            RefillCmbxcontents();
            ClearContentForm();
        }

        private void RBtnEnclosures_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RBtnEnclosures.Checked)
            {
                ReloadListBoxes();
            }


        }

        private void ReloadListBoxes()
        {
            if (this.RBtnEnclosures.Checked)
            {
                state = "Enclosure";
                PopulateLsBxEnclosures();
            }
            if (this.RBtnAnimals.Checked)
            {
                state = "Animal";
                PopulateLsBxANimals();
            }
            if (this.RBtnSpecies.Checked)
            {
                state = "Species";
                PopulateLsBxSpecies();
            }
            this.GbxContent.Enabled = false;

            this.LsBxOnline.SelectedItems.Clear();
            this.LsBxNotOnline.SelectedItems.Clear();
        }

        private void PopulateLsBxEnclosures()
        {
            List<Enclosure> online = new List<Enclosure>();
            List<Enclosure> notOnline = new List<Enclosure>();
            enclosureDTO.getEnclosures();
            foreach (Enclosure enclosure in enclosureDTO.EnclosuresList)
            {
                if (enclosure.ShowOnWeb == true)
                {
                    online.Add(enclosure);

                }
                else
                {
                    notOnline.Add(enclosure);
                }
            }

            this.LsBxOnline.DataSource = null;
            this.LsBxNotOnline.DataSource = null;

            enclosureDTO.GetListEnclosures();
            List<Enclosure> enclosureListOnline = new List<Enclosure>();
            List<Enclosure> enclosureListNotOnline = new List<Enclosure>();

            foreach (Enclosure enclosure in enclosureDTO.EnclosuresList)
            {
                if (enclosure.ShowOnWeb)
                {
                    enclosureListOnline.Add(enclosure);
                }
                else
                {
                    enclosureListNotOnline.Add(enclosure);
                }
            }

            this.LsBxOnline.DisplayMember = "Name";
            this.LsBxOnline.ValueMember = "Name";
            this.LsBxOnline.DataSource = enclosureListOnline;

            this.LsBxNotOnline.DisplayMember = "Name";
            this.LsBxNotOnline.ValueMember = "Name";
            this.LsBxNotOnline.DataSource = enclosureListNotOnline;

            this.LsBxOnline.SelectedItems.Clear();
            this.LsBxNotOnline.SelectedItems.Clear();
        }

        private void RBtnAnimals_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RBtnAnimals.Checked)
            {
                ReloadListBoxes();
            }

        }

        private void PopulateLsBxANimals()
        {
            List<Animal> online = new List<Animal>();
            List<Animal> notOnline = new List<Animal>();
            animalDTO.GetAllAnimals();
            foreach (Animal animal in animalDTO.AllAnimals)
            {
                if (animal.ShowOnWeb == true)
                {
                    online.Add(animal);
                }
                else
                {
                    notOnline.Add(animal);
                }
            }
            this.LsBxOnline.DataSource = null;
            this.LsBxNotOnline.DataSource = null;

            this.LsBxOnline.DisplayMember = "AnimalName";
            this.LsBxOnline.ValueMember = "AnimalName";
            this.LsBxOnline.DataSource = online;

            this.LsBxNotOnline.DisplayMember = "AnimalName";
            this.LsBxNotOnline.ValueMember = "AnimalName";
            this.LsBxNotOnline.DataSource = notOnline;

        }

        private void RBtnSpecies_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RBtnSpecies.Checked)
            {
                ReloadListBoxes();
            }


        }

        private void PopulateLsBxSpecies()
        {
            List<Species> online = new List<Species>();
            List<Species> notOnline = new List<Species>();
            speciesDTO.GetListFromRepo();
            foreach (Species species in speciesDTO.ListOfSpecies)
            {
                if (species.ShowOnWeb == true)
                {
                    online.Add(species);
                }
                else
                {
                    notOnline.Add(species);
                }
            }
            this.LsBxOnline.DataSource = null;
            this.LsBxNotOnline.DataSource = null;


            this.LsBxOnline.DisplayMember = "SpeciesName";
            this.LsBxOnline.ValueMember = "SpeciesName";
            this.LsBxOnline.DataSource = online;

            this.LsBxNotOnline.DisplayMember = "SpeciesName";
            this.LsBxNotOnline.ValueMember = "SpeciesName";
            this.LsBxNotOnline.DataSource = notOnline;
        }

        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.RBtnAnimals.Checked)
            {
                if (this.TbxSearch.Text.Length > 0)
                {
                    List<Animal> filterOnline = new List<Animal>();
                    List<Animal> filterNotOnline = new List<Animal>();
                    foreach (Animal animal in animalDTO.AllAnimals)
                    {
                        if (animal.ShowOnWeb && animal.AnimalName.Contains(this.TbxSearch.Text))
                        {
                            filterOnline.Add(animal);
                        }
                        if (!animal.ShowOnWeb && animal.AnimalName.Contains(this.TbxSearch.Text))
                        {
                            filterNotOnline.Add(animal);
                        }
                    }
                    this.LsBxOnline.DataBindings.Clear();
                    this.LsBxNotOnline.DataBindings.Clear();

                    this.LsBxOnline.DataSource = filterOnline;
                    this.LsBxNotOnline.DataSource = filterNotOnline;
                }
                else
                {
                    PopulateLsBxANimals();
                }
            }
            if (this.RBtnSpecies.Checked)
            {
                if (this.TbxSearch.Text.Length > 0)
                {
                    List<Species> filterOnline = new List<Species>();
                    List<Species> filterNotOnline = new List<Species>();
                    foreach (Species species in speciesDTO.ListOfSpecies)
                    {
                        if (species.ShowOnWeb && species.SpeciesName.Contains(this.TbxSearch.Text))
                        {
                            filterOnline.Add(species);

                        }
                        if (!species.ShowOnWeb && species.SpeciesName.Contains(this.TbxSearch.Text))
                        {
                            filterNotOnline.Add(species);
                        }
                    }
                    this.LsBxOnline.DataBindings.Clear();
                    this.LsBxNotOnline.DataBindings.Clear();

                    this.LsBxNotOnline.DataSource = filterNotOnline;
                    this.LsBxOnline.DataSource = filterOnline;

                }
                else
                {
                    PopulateLsBxSpecies();
                }
            }
            if (RBtnEnclosures.Checked)
            {
                if (this.TbxSearch.Text.Length > 0)
                {
                    this.LsBxOnline.DataBindings.Clear();
                    var filteredEnclosures = enclosureDTO.EnclosuresList.Where(x => x.Name.ToLower().Contains(this.TbxSearch.Text.ToLower())).ToList();

                    this.LsBxOnline.DataBindings.Clear();
                    this.LsBxNotOnline.DataBindings.Clear();

                    this.LsBxOnline.DisplayMember = "Name";
                    this.LsBxOnline.ValueMember = "Name";
                    this.LsBxOnline.DataSource = filteredEnclosures;

                }
                else
                {
                    PopulateLsBxEnclosures();
                }
            }


        }

        private void clearCmbx()
        {
            this.CmbxListContents.DataSource = null;

        }

        private void LsBxOnline_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            int index = LsBxOnline.IndexFromPoint(pt);

            if (index <= -1)
            {
                LsBxOnline.SelectedItems.Clear();

            }

        }

        private void LsBxNotOnline_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            int index = LsBxNotOnline.IndexFromPoint(pt);

            if (index <= -1)
            {
                LsBxNotOnline.SelectedItems.Clear();

            }

        }



        private void TbxImageLink_TextChanged(object sender, EventArgs e)
        {
            if (this.CmbxListContents.SelectedIndex != -1)
            {
                string url = this.TbxImageLink.Text;
                if (url != contentDTO.SelectedContent.ImageUrl)
                {
                    if (edditContent == null || !edditContent.GetInvocationList().Contains(EdditContentImageUrl))
                    {

                        edditContent += EdditContentImageUrl;
                        edditState += 1;
                    }

                }
                else
                {
                    if (edditContent != null && edditContent.GetInvocationList().Contains(EdditContentImageUrl))
                    {
                        edditContent -= EdditContentImageUrl;
                        edditState -= 1;
                    }

                }

            }
            else
            {
                if (newContent == null || !newContent.GetInvocationList().Contains(NewContentImageUrl))
                {
                    newContent += NewContentImageUrl;
                    newState += 1;
                }
            }
            CheckStateEddit();
        }

        private void LsBxOnline_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearContentForm();
            if (this.LsBxOnline.SelectedIndex != -1)
            {

                this.BtnRemoveFormWebSite.Enabled = true;


                FillContentGrBxWithObjec(this.LsBxOnline.SelectedItem);
                this.GbxContent.Enabled = true;
            }
            else
            {
                this.BtnRemoveFormWebSite.Enabled = false;
                this.GbxContent.Enabled = false;
                clearCmbx();
            }
        }

        private void LsBxNotOnline_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearContentForm();
            if (this.LsBxNotOnline.SelectedIndex != -1)
            {
                this.BtnAddToWebsite.Enabled = true;
                FillContentGrBxWithObjec(this.LsBxNotOnline.SelectedItem);
                this.GbxContent.Enabled = true;

            }
            else
            {
                this.BtnAddToWebsite.Enabled = false;
                this.GbxContent.Enabled = false;
                clearCmbx();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}


