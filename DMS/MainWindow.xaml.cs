using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace DMS
{



    /// <summary>    
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CsMainWindow scmw = new CsMainWindow();
        LayoutDocument docAddress = new LayoutDocument();
        ADD.ADDMain fmNewADD = new ADD.ADDMain();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = scmw;
            ChangeAppStyle();
            SetLanguageDictionary();
            scmw.stextBox = "start";
            // Start TimerEvent
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += EventTimerTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }


        /// <summary>
        /// Sets the language dictionary.
        /// </summary>
        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (System.Threading.Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "en-US":
                    dict.Source = new Uri("..\\Resources\\German.xaml", UriKind.Relative);
                    break;
                case "fr-CA":
                    dict.Source = new Uri("..\\Resources\\German.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\German.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }


        /// <summary>
        /// Changes the application style.
        /// </summary>
        public void ChangeAppStyle()
        {
            Fluent.ThemeManager.ChangeAppStyle(this,
                                         Fluent.ThemeManager.GetAccent("Cobalt"),
                                         Fluent.ThemeManager.GetAppTheme("BaseDark"));


            MahApps.Metro.ThemeManager.ChangeAppStyle(this,
                                        MahApps.Metro.ThemeManager.GetAccent("Cobalt"),
                                        MahApps.Metro.ThemeManager.GetAppTheme("BaseDark"));
        }

        // **************************************************************************************************
        // Build Documents
        // **************************************************************************************************
        #region Layout

        /// <summary>
        /// The OnSaveLayout
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void SaveLayout()
        {
            var serializer = new XmlLayoutSerializer(dockManager);
            using (var stream = new StreamWriter(string.Format(@".\AvalonDock.config")))
                serializer.Serialize(stream);
        }

        /// <summary>
        /// The OnLoadLayout
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void LoadLayout()
        {
            var currentContentsList = dockManager.Layout.Descendents().OfType<LayoutContent>().Where(c => c.ContentId != null).ToArray();

            var serializer = new XmlLayoutSerializer(dockManager);
            using (var stream = new StreamReader(string.Format(@".\AvalonDock.config")))
                serializer.Deserialize(stream);
        }

        /// <summary>
        /// The OnLayoutRootPropertyChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="System.ComponentModel.PropertyChangedEventArgs"/></param>
        private void OnLayoutRootPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var activeContent = ((LayoutRoot)sender).ActiveContent;
            if (e.PropertyName == "ActiveContent")
            {
                System.Diagnostics.Debug.WriteLine(string.Format("ActiveContent-> {0}", activeContent));
            }
        }

        /// <summary>
        /// The OnLoadManager
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void OnLoadManager(object sender, RoutedEventArgs e)
        {
            if (!layoutRoot.Children.Contains(dockManager))
                layoutRoot.Children.Add(dockManager);
        }

        /// <summary>
        /// The OnUnloadManager
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="RoutedEventArgs"/></param>
        private void OnUnloadManager(object sender, RoutedEventArgs e)
        {
            if (layoutRoot.Children.Contains(dockManager))
                layoutRoot.Children.Remove(dockManager);
        }
        #endregion

        // **************************************************************************************************
        // Close Documents
        // **************************************************************************************************
        #region CloseWindows

        private void OnToolWindow1Hiding(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to hide this tool?", "AvalonDock", MessageBoxButton.YesNo) == MessageBoxResult.No)
                e.Cancel = true;
        }


        private void dockManager_DocumentClosing(object sender, DocumentClosingEventArgs e)
        {
            string sTitle = "N.A.";

            if (e.Document.Title != null)
                sTitle = e.Document.Title.ToString();

            string s = string.Format("Are you sure you want to close the document '{0}' ?", sTitle);
            if (MessageBox.Show(s, "AvalonDock Sample", MessageBoxButton.YesNo) == MessageBoxResult.No)
                e.Cancel = true;
        }

        #endregion

        // **************************************************************************************************
        // Open Documents
        // **************************************************************************************************
        #region OpenWindow

        private LayoutDocument ShowWindow_LayoutDocumentPane(string sContentId)
        {
            LayoutDocument doc = new LayoutDocument();
            var currentContentsList = dockManager.Layout.Descendents().OfType<LayoutContent>().Where(c => c.ContentId == sContentId).ToArray();

            if (currentContentsList.Count() == 0)
            {

                var firstDocumentPane = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
                if (firstDocumentPane != null)
                {
                    doc.ContentId = sContentId;

                    firstDocumentPane.Children.Add(doc);
                }
            }
            return doc;
        }

        /// <summary>
        /// Shows the window layout document pane.
        /// </summary>
        /// <param name="sContentId">The s content identifier.</param>
        /// <param name="sTitle">The s title.</param>
        /// <returns></returns>
        private LayoutDocument ShowWindow_LayoutDocumentPane(string sContentId, string sTitle)
        {
            LayoutDocument doc = new LayoutDocument();
            var currentContentsList = dockManager.Layout.Descendents().OfType<LayoutContent>().Where(c => c.ContentId == sContentId).ToArray();

            if (currentContentsList.Count() == 0)
            {

                var firstDocumentPane = dockManager.Layout.Descendents().OfType<LayoutDocumentPane>().FirstOrDefault();
                if (firstDocumentPane != null)
                {
                    doc.ContentId = sContentId;
                    doc.Title = sTitle;
                    firstDocumentPane.Children.Add(doc);

                }
            }

            if (currentContentsList.Count() == 1)
            {
                currentContentsList[0].Title = sTitle;
            }
            return doc;
        }


        private LayoutAnchorable ShowWindow_Tool(string sContentId)
        {
            LayoutAnchorable toolWindow1;

            try
            {
                toolWindow1 = dockManager.Layout.Descendents().OfType<LayoutAnchorable>().Single(a => a.ContentId == sContentId);
                if (toolWindow1.IsHidden)
                {
                    toolWindow1.Show();
                    toolWindow1.IsSelected = true;
                }
                else if (toolWindow1.IsVisible)
                {
                    toolWindow1.IsActive = true;
                }
                else
                {
                    toolWindow1.AddToLayout(dockManager, AnchorableShowStrategy.Right | AnchorableShowStrategy.Most);
                    toolWindow1.ContentId = sContentId;
                }
                return toolWindow1;
            }
            catch
            {
                LayoutAnchorable toolWin = new LayoutAnchorable();
                toolWin.AddToLayout(dockManager, AnchorableShowStrategy.Right | AnchorableShowStrategy.Most);
                toolWin.ContentId = sContentId;
                toolWin.Hiding += new EventHandler<System.ComponentModel.CancelEventArgs>(OnToolWindow1Hiding);
                return toolWin;
            }
        }


        #endregion

        // **************************************************************************************************
        // Timer 
        // **************************************************************************************************
        #region EventTimer

        private void EventTimerTick(object sender, EventArgs e)
        {
            // code goes here
            if (fmNewADD.baseADD.GetADDKey() > 0)
            {
                scmw.stextBox = fmNewADD.baseADD.GetADDKey().ToString();
                docAddress.Title = "Address: " + fmNewADD.baseADD.GetADDKey().ToString();
                fmNewADD.baseADD.SetADDKey(0);
            }
        }

        #endregion

        // **************************************************************************************************
        // Button
        // **************************************************************************************************
        #region RibbonButton

        private void CmdShow_Mail(object sender, RoutedEventArgs e)
        {
            LayoutAnchorable toolWindow1 = ShowWindow_Tool("Mail");
            toolWindow1.Title = "Mail";
            toolWindow1.Content = new ToolPanel.ucToolPanel();


            LayoutDocument doc = new LayoutDocument();
            ToolPanel.ucToolPanel UCT = new ToolPanel.ucToolPanel();
            doc = ShowWindow_LayoutDocumentPane("Zusatz");

            if (doc != null)
            {
                doc.Title = "UCT";
                doc.IsSelected = true;
                doc.Content = UCT;

            }

        }

        private void CmdShow_ContactSearch(object sender, RoutedEventArgs e)
        {
            docAddress = ShowWindow_LayoutDocumentPane("Address");
            if (docAddress != null)
            {
                docAddress.Content = fmNewADD;
                docAddress.Title = "Contact";
                docAddress.IsSelected = true;
            }
        }

        private void CmdShow_ContactNew(object sender, RoutedEventArgs e)
        {
            docAddress = ShowWindow_LayoutDocumentPane("Address");
            if (docAddress != null)
            {
                docAddress.Content = fmNewADD;
                docAddress.Title = "Contact";
                docAddress.IsSelected = true;
            }
        }

        #endregion

        // **************************************************************************************************
        // Default Menu
        // **************************************************************************************************
        private void DMS_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }



    }
}
