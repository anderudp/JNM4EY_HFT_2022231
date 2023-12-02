using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JNM4EY_HFT_2022231.Models;

namespace JNM4EY_HFT_2022231.WpfClient
{
    class MainWindowViewModel : ObservableRecipient
    {
        public static MainWindowViewModel Instance { get; set; }

        private string errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        #region Agenda

        public RestCollection<Agenda> Agendas { get; set; }

        private Agenda selectedAgenda;
        public Agenda SelectedAgenda
        {
            get { return selectedAgenda; }
            set
            {
                if (value != null)
                {
                    selectedAgenda = new Agenda()
                    {
                        AgendaId = value.AgendaId,
                        Title = value.Title,
                        Description = value.Description,
                        Todos = value.Todos,
                        AgendaUsers = value.AgendaUsers
                    };
                    OnPropertyChanged();
                    (DeleteAgendaCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAgendaCommand { get; set; }
        public ICommand UpdateAgendaCommand { get; set; }
        public ICommand DeleteAgendaCommand { get; set; }

        public void SetAgendaCommands()
        {
            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];
            Agendas = new RestCollection<Agenda>(baseAddress, "api/Agenda", "hub");

            CreateAgendaCommand = new RelayCommand(() =>
            {
                Agendas.Add(new Agenda()
                {
                    Title = "Title",
                    Description = "Description"
                });
            });

            UpdateAgendaCommand = new RelayCommand(() =>
            {
                try
                {
                    Agendas.Update(SelectedAgenda);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });

            DeleteAgendaCommand = new RelayCommand(() =>
            {
                Agendas.Delete(SelectedAgenda.AgendaId);
            },
            () =>
            {
                return SelectedAgenda != null;
            });


            SelectedAgenda = new Agenda();
        }

        #endregion

        #region Todo
        public RestCollection<Todo> Todos { get; set; }

        private Todo selectedTodo;
        public Todo SelectedTodo
        {
            get { return selectedTodo; }
            set
            {
                if (value != null)
                {
                    selectedTodo = new Todo()
                    {
                        TodoId = value.TodoId,
                        Description = value.Description,
                        IsComplete = value.IsComplete,
                        IsImportant = value.IsImportant,
                        IsUrgent = value.IsUrgent,
                        AgendaId = value.AgendaId
                    };
                    OnPropertyChanged();
                    (DeleteTodoCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateTodoCommand { get; set; }
        public ICommand UpdateTodoCommand { get; set; }
        public ICommand DeleteTodoCommand { get; set; }

        public void SetTodoCommands()
        {
            var baseAddress = ConfigurationManager.AppSettings["baseAddress"];
            Todos = new RestCollection<Todo>(baseAddress, "api/Todo", "hub");

            CreateTodoCommand = new RelayCommand(() =>
            {
                var newTodo = new Todo()
                {
                    Description = "Description",
                    IsComplete = false,
                    IsImportant = false,
                    IsUrgent = false,
                    AgendaId = SelectedAgenda.AgendaId
                };
                Todos.Add(newTodo);
                UpdateAgendaCommand.Execute(null);
                UpdateTodoCommand.Execute(null);

            });

            UpdateTodoCommand = new RelayCommand(() =>
            {
                try
                {
                    Todos.Update(SelectedTodo);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });

            DeleteTodoCommand = new RelayCommand(() =>
            {
                Todos.Delete(SelectedTodo.TodoId);
                var selectedInList = SelectedAgenda.Todos.First(x => x.TodoId == SelectedTodo.TodoId);
                SelectedAgenda.Todos.Remove(selectedInList);
            },
            () =>
            {
                return SelectedTodo != null;
            });


            SelectedTodo = new Todo();
        }
        #endregion

        public ICommand OpenTodoEditorWindowCommand { get; set; }

        public MainWindowViewModel()
        {
            Instance = this;
            if (IsInDesignMode) return;

            SetAgendaCommands();
            SetTodoCommands();

            //OpenTodoEditorWindowCommand = new RelayCommand(() =>
            //{
            //    TodoEditorWindow window = new TodoEditorWindow();
            //    window.ShowDialog();
            //});

        }
    }
}
