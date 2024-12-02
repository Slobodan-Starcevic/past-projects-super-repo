using BLL.Interfaces.Services;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsCore.HrManager
{
    public partial class Notes : Form
    {
        private NoteService _noteService;
        private EmployeeService _employeeService;

        private List<Note> AllNotes { get; set; }
        private List<Employee> AllEmployees { get; set; }

        public Notes()
        {
            InitializeComponent();
            AllNotes = new List<Note>();
            AllEmployees = new List<Employee>();
            _noteService = new NoteService(new NoteRepository());
            _employeeService = new EmployeeService(new EmployeeRepository());
        }

        private void Notes_Load(object sender, EventArgs e)
        {

            comboBoxEmployeeFilter.Items.Add("All");
            AllEmployees = _employeeService.GetAllEmployees();
            foreach (var employee in AllEmployees)
            {
                comboBoxEmployeeFilter.Items.Add(employee);
            }
            comboBoxEmployeeFilter.SelectedItem = "All";

            comboBoxSpeciesOrNotFilter.Items.Clear();
            comboBoxSpeciesOrNotFilter.Items.Add("All");
            comboBoxSpeciesOrNotFilter.Items.Add("Animal Note");
            comboBoxSpeciesOrNotFilter.Items.Add("Employee Note");
            comboBoxSpeciesOrNotFilter.SelectedItem = "All";

            panelNoteInfo.Hide();
            panelNoteSpecies.Hide();

            buttonSwitchArchiveActive.Text = "Show archived";

            AllNotes = _noteService.GetAllNotes();
            foreach (var note in AllNotes)
            {
                if (note.Archive == false)
                {
                    listBoxNotes.Items.Add(note);
                }
            }
        }

        private void comboBoxSpeciesOrNotFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEmployeeFilter.SelectedItem = "All";
            string selectedOption = comboBoxSpeciesOrNotFilter.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "All":
                    listBoxNotes.Items.Clear();
                    foreach (var note in AllNotes)
                    {
                        listBoxNotes.Items.Add(note);
                    }
                    break;
                case "Animal Note":
                    listBoxNotes.Items.Clear();
                    foreach (var note in AllNotes)
                    {
                        if (note.Species != null)
                        {
                            listBoxNotes.Items.Add(note);
                        }
                    }
                    break;
                case "Employee Note":
                    listBoxNotes.Items.Clear();
                    foreach (var note in AllNotes)
                    {
                        if (note.Species == null)
                        {
                            listBoxNotes.Items.Add(note);
                        }
                    }
                    break;
            }
        }

        private void comboBoxEmployeeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSpeciesOrNotFilter.SelectedItem = "All";

            if (comboBoxEmployeeFilter.SelectedItem is Employee selectedEmployee)
            {
                Guid selectedEmployeeId = selectedEmployee.Id;

                listBoxNotes.Items.Clear();
                foreach (var note in AllNotes)
                {
                    if (note.Employee.Id == selectedEmployeeId)
                    {
                        listBoxNotes.Items.Add(note);
                    }
                }
            }
            else if (comboBoxEmployeeFilter.SelectedItem.ToString() == "All")
            {
                listBoxNotes.Items.Clear();
                foreach (var note in AllNotes)
                {
                    listBoxNotes.Items.Add(note);
                }
            }
        }

        private void listBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex != -1)
            {
                Note selectedNote = (Note)listBoxNotes.SelectedItem;
                PopulateUserInfoPanel(selectedNote);

                if (selectedNote.Archive == true)
                {
                    buttonArchive.Enabled = false;
                }
            }
        }

        private void PopulateUserInfoPanel(Note note)
        {
            panelNoteInfo.Show();

            if (note.Species != null)
            {
                panelNoteSpecies.Show();
                textBoxSpeciesName.Text = note.Species[0].SpeciesName;
            }
            else
            {
                panelNoteSpecies.Hide();
            }

            textBoxSubmitterName.Text = $"{note.Employee.FirstName} {note.Employee.LastName}";
            textBoxNoteText.Text = note.Text;
        }

        private void buttonArchive_Click(object sender, EventArgs e)
        {
            Note selectedNote = (Note)listBoxNotes.SelectedItem;
            DialogResult result = MessageBox.Show("Are you sure you want to archive the note?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _noteService.ArchiveNote(selectedNote.Id);
                listBoxNotes.Items.Clear();
                AllNotes = _noteService.GetAllNotes();
                foreach (var note in AllNotes)
                {
                    if (note.Archive == false)
                    {
                        listBoxNotes.Items.Add(note);
                    }
                }
                MessageBox.Show("The note has been succesfully archived", "Archive success");
            }
            else
            {
                //nothing
            }
        }

        private void buttonSwitchArchiveActive_Click(object sender, EventArgs e)
        {
            switch (buttonSwitchArchiveActive.Text)
            {
                case "Show archived":
                    buttonSwitchArchiveActive.Text = "Show active";
                    listBoxNotes.Items.Clear();
                    foreach (var note in AllNotes)
                    {
                        if (note.Archive == true)
                        {
                            listBoxNotes.Items.Add(note);
                        }
                    }
                    break;
                case "Show active":
                    buttonSwitchArchiveActive.Text = "Show archived";
                    listBoxNotes.Items.Clear();
                    foreach (var note in AllNotes)
                    {
                        if (note.Archive == false)
                        {
                            listBoxNotes.Items.Add(note);
                        }
                    }
                    break;
            }
        }
    }
}
