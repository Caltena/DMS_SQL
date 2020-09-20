using System;
using System.Windows;
using System.Windows.Controls;

namespace ToolPanel
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ucToolPanel : UserControl
    {
        //public ucToolPanel()
        //{
        //    InitializeComponent();
        //}

        public csToolPanel ToolObject = new csToolPanel();

        /// <summary>
        /// Initializes a new instance of the <see cref="ucToolPanel"/> class.
        /// </summary>
        public ucToolPanel() : base()
        {
            InitializeComponent();
            this.DataContext = ToolObject;
        }


        public Boolean State
        {
            get { return (Boolean)this.GetValue(StateProperty); }
            set { this.SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
          "State", typeof(Boolean), typeof(ucToolPanel), new PropertyMetadata(false));




        #region RoutedEvent
        #region ClickEvent
        public static readonly RoutedEvent ClickEvent =
           EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
           typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        protected virtual void RaiseClickEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.ClickEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdADDEvent
        public static readonly RoutedEvent cmdADDEvent =
                EventManager.RegisterRoutedEvent("cmdADDClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdADDClick
        {
            add { AddHandler(cmdADDEvent, value); }
            remove { RemoveHandler(cmdADDEvent, value); }
        }
        protected virtual void RaisecmdADDEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdADDEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdSaveEvent
        public static readonly RoutedEvent cmdSaveEvent =
                EventManager.RegisterRoutedEvent("cmdSaveClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdSaveClick
        {
            add { AddHandler(cmdSaveEvent, value); }
            remove { RemoveHandler(cmdSaveEvent, value); }
        }
        protected virtual void RaisecmdSaveEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdSaveEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdSearchEvent
        public static readonly RoutedEvent cmdSearchEvent =
                EventManager.RegisterRoutedEvent("cmdSearchClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdSearchClick
        {
            add { AddHandler(cmdSearchEvent, value); }
            remove { RemoveHandler(cmdSearchEvent, value); }
        }
        protected virtual void RaisecmdSearchEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdSearchEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdListEvent
        public static readonly RoutedEvent cmdListEvent =
                EventManager.RegisterRoutedEvent("cmdListClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdListClick
        {
            add { AddHandler(cmdListEvent, value); }
            remove { RemoveHandler(cmdListEvent, value); }
        }
        protected virtual void RaisecmdListEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdListEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdSingleEvent
        public static readonly RoutedEvent cmdSingleEvent =
                EventManager.RegisterRoutedEvent("cmdSingleClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdSingleClick
        {
            add { AddHandler(cmdSingleEvent, value); }
            remove { RemoveHandler(cmdSingleEvent, value); }
        }
        protected virtual void RaisecmdSingleEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdSingleEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdPrintEvent
        public static readonly RoutedEvent cmdPrintEvent =
                EventManager.RegisterRoutedEvent("cmdPrintClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdPrintClick
        {
            add { AddHandler(cmdPrintEvent, value); }
            remove { RemoveHandler(cmdPrintEvent, value); }
        }
        protected virtual void RaisecmdPrintEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdPrintEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdImportEvent
        public static readonly RoutedEvent cmdImportEvent =
                EventManager.RegisterRoutedEvent("cmdImportClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdImportClick
        {
            add { AddHandler(cmdImportEvent, value); }
            remove { RemoveHandler(cmdImportEvent, value); }
        }
        protected virtual void RaisecmdImportEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdImportEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdUndoEvent
        public static readonly RoutedEvent cmdUndoEvent =
                EventManager.RegisterRoutedEvent("cmdUndoClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdUndoClick
        {
            add { AddHandler(cmdUndoEvent, value); }
            remove { RemoveHandler(cmdUndoEvent, value); }
        }
        protected virtual void RaisecmdUndoEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdUndoEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdDeleteEvent
        public static readonly RoutedEvent cmdDeleteEvent =
                EventManager.RegisterRoutedEvent("cmdDeleteClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdDeleteClick
        {
            add { AddHandler(cmdDeleteEvent, value); }
            remove { RemoveHandler(cmdDeleteEvent, value); }
        }
        protected virtual void RaisecmdDeleteEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdDeleteEvent);
            RaiseEvent(args);
        }
        #endregion

        #region cmdMailEvent
        public static readonly RoutedEvent cmdMailEvent =
                EventManager.RegisterRoutedEvent("cmdMailClick", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(ucToolPanel));

        public event RoutedEventHandler cmdMailClick
        {
            add { AddHandler(cmdMailEvent, value); }
            remove { RemoveHandler(cmdMailEvent, value); }
        }
        protected virtual void RaisecmdMailEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ucToolPanel.cmdMailEvent);
            RaiseEvent(args);
        }
        #endregion

        #endregion

        #region Button_Click
        void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdDeleteEvent();
        }
        void cmdUndo_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdUndoEvent();
        }
        void cmdImport_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdImportEvent();
        }
        void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdSaveEvent();
        }
        void cmdSingle_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdSingleEvent();
        }
        void cmdList_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdListEvent();
        }
        void cmdSearch_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdSearchEvent();
        }
        void cmdPrint_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdPrintEvent();
        }
        void cmdMail_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdMailEvent();
        }
        void cmdADD_Click(object sender, RoutedEventArgs e)
        {
            RaisecmdADDEvent();
        }
        #endregion
        #region IsEnabled

        public void ShowAll()
        {
            SearchIsEnabled = true;
            ListIsEnabled = true;
            SingleIsEnabled = true;
            PrinterIsEnabled = true;
            ImportIsEnabled = true;
            MailIsEnabled = true;
            UndoIsEnabled = true;
            DeleteIsEnabled = true;
            SaveIsEnabled = true;
            ADDIsEnabled = true;
        }

        public void ShowSearch()
        {
            SearchIsEnabled = false;
            ListIsEnabled = true;
            SingleIsEnabled = false;
            PrinterIsEnabled = true;
            ImportIsEnabled = false;
            MailIsEnabled = false;
            UndoIsEnabled = false;
            DeleteIsEnabled = false;
            SaveIsEnabled = false;
            ADDIsEnabled = false;
        }

        public void ShowList()
        {
            SearchIsEnabled = true;
            ListIsEnabled = false;
            SingleIsEnabled = true;
            PrinterIsEnabled = true;
            ImportIsEnabled = false;
            MailIsEnabled = false;
            UndoIsEnabled = false;
            DeleteIsEnabled = false;
            SaveIsEnabled = false;
            ADDIsEnabled = false;
        }

        public void ShowSingle()
        {
            SearchIsEnabled = false;
            ListIsEnabled = true;
            SingleIsEnabled = false;
            PrinterIsEnabled = true;
            ImportIsEnabled = true;
            MailIsEnabled = true;
            UndoIsEnabled = false;
            DeleteIsEnabled = true;
            SaveIsEnabled = true;
            ADDIsEnabled = true;
        }

        public bool ImportIsEnabled
        {
            get { return ToolObject.Import_IsEnabled; }
            set { ToolObject.Import_IsEnabled = value; }
        }
        public bool SearchIsEnabled
        {
            get { return ToolObject.Search_IsEnabled; }
            set { ToolObject.Search_IsEnabled = value; }
        }
        public bool ListIsEnabled
        {
            get { return ToolObject.List_IsEnabled; }
            set { ToolObject.List_IsEnabled = value; }
        }
        public bool SingleIsEnabled
        {
            get { return ToolObject.Single_IsEnabled; }
            set { ToolObject.Single_IsEnabled = value; }
        }
        public bool PrinterIsEnabled
        {
            get { return ToolObject.Printer_IsEnabled; }
            set { ToolObject.Printer_IsEnabled = value; }
        }
        public bool MailIsEnabled
        {
            get { return ToolObject.Mail_IsEnabled; }
            set { ToolObject.Mail_IsEnabled = value; }
        }
        public bool UndoIsEnabled
        {
            get { return ToolObject.Undo_IsEnabled; }
            set { ToolObject.Undo_IsEnabled = value; }
        }
        public bool DeleteIsEnabled
        {
            get { return ToolObject.Delete_IsEnabled; }
            set { ToolObject.Delete_IsEnabled = value; }
        }
        public bool SaveIsEnabled
        {
            get { return ToolObject.Save_IsEnabled; }
            set { ToolObject.Save_IsEnabled = value; }
        }
        public bool ADDIsEnabled
        {
            get { return ToolObject.ADD_IsEnabled; }
            set { ToolObject.ADD_IsEnabled = value; }
        }


        #endregion
    }
}
