using DevicesUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VendingMachineApplication;

namespace VendingMachineApplication
{
    public partial class FormVendingTest : Form
    {
        private UserMessages Messages = new UserMessages();

        private List<Product> _productList = new List<Product>();
        private List<int> _priceList = new List<int>();
        string SelectedLanguage { get; set; }

        public FormVendingTest()
        {
            InitializeComponent();
            SelectedLanguage = "";
            cell1.Product = product1;
            LoadSettings();
            // ApplyLanguage("form_eng.xml");
        }

        private void FormVendingTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormVendingTest_MouseWheel);


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = ((System.Drawing.Image)(resources.GetObject("can1")));
            
            Product p = new Product("pepsi", image);
            vendingMachine.Cell.Product = p;
            vendingMachine.Init();

            CreateCells();

            foreach (object obj in panel1.Controls)
            {
                if (obj is Product)
                {
                    _productList.Add(obj as Product);
                    _priceList.Add(0);
                }
            }
        }

        void InsertBanknote(object sender, InsertBanknoteEventArgs e)
        {
            e.Banknote.ImagePack = Properties.Resources.money as Bitmap;
            e.Banknote.Repaint();

            this.Controls.Add(e.Banknote);

            acceptor1.GetMoney(e.Banknote);
        }

        void FormVendingTest_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) vendingMachine.Scale *= 1.1f;
            if (e.Delta > 0) vendingMachine.Scale /= 1.1f;
        }

        private void vendingMachineSizeChanged(object sender, EventArgs e)
        {
            this.Width = vendingMachine.Left + vendingMachine.Width + 25;
            this.Height = vendingMachine.Top + vendingMachine.Height + 25;
        }

        private void CreateCells()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = new Bitmap(global::VendingMachineApplication.Properties.Resources.small_wall);//((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            List<Cell> lc = vendingMachine.CreateCells(image);
            if (lc == null)
                return;
            foreach (Cell c in lc)
            {
                this.Controls.Add(c);
                c.Show();
                c.Repaint();
                c.BringToFront();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            vendingMachine.Update();
        }

        private void buttonRandomizeClick(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < _priceList.Count; i++)
                _priceList[i] = r.Next() % 100;

            for (int i = 1; i < 61; i++)
            {
                Product cellProduct = vendingMachine.GetCellProduct(i);

                if (_productList != null && _productList.Count > 0)
                {
                    int index = -1;

                    if (cellProduct == null)
                    {
                        index = r.Next() % _productList.Count;
                        cellProduct = _productList[index];
                        vendingMachine.SetCellProduct(i, cellProduct);
                    }
                    else
                    {
                        for ( int j = 0; j < _productList.Count; j++ )
                            if (_productList[j].Name == cellProduct.Name)
                            {
                                index = j;
                                break;
                            }
                    }
                    vendingMachine.SetCellPrice(i, (uint)_priceList[index]);
                }
                vendingMachine.AddProductsToCell(i, r.Next() % 11);
            }
        }

        private void vendingMachineProductFallRequest(object sender, Product product)
        {
            if (product == null)
                return;
            product.Visible = true;
            this.Controls.Add(product);
            product.BringToFront();
        }

        private void vendingMachineProductRemoveRequest(object sender, Product product)
        {
            if (product == null)
                return;

            components.Remove(product);
        }

        void InsertBanknote(int value)
        {
            Banknote banknote = new Banknote(value);

            banknote.ImagePack = Properties.Resources.money as Bitmap;
            banknote.Repaint();
            this.Controls.Add(banknote);
            if (!acceptor1.GetMoney(banknote))
                this.Controls.Remove(banknote);
        }

        private void buttonInsertBanknoteClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null)
                return;

            switch (b.Name)
            {
                case "buttonInsert10": InsertBanknote(10); break;
                case "buttonInsert50": InsertBanknote(50); break;
                case "buttonInsert100": InsertBanknote(100); break;
                case "buttonInsert500": InsertBanknote(500); break;
                default: break;
            }
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                Close();
            
            base.ProcessCmdKey(ref msg, keyData);

            return false;
        }

        private void ApplyField(XmlNode node, ref string dest)
        {
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
                dest = node.InnerText;
        }

        public bool ApplyLanguage(string filename)
        {
            try
            {
                string xml = "";

                xml = File.ReadAllText(filename, Encoding.UTF8); // если не удалось прочитать - переход в catch

                if (string.IsNullOrEmpty(xml))
                    return false;

                var doc = new XmlDocument();
                doc.Load(new StringReader(xml));

                if (doc == null || doc.FirstChild == null)
                    return false;

                var messages = doc.FirstChild;
                if (messages.Name.ToLower() != "usermessages")
                    return false;

                UserMessages data = new UserMessages();
                ApplyField(messages["Header"], ref data.Header);
                ApplyField(messages["UserActions"], ref data.UserActions);
                ApplyField(messages["Randomize"], ref data.Randomize);
                ApplyField(messages["Fill10"], ref data.Fill10);
                ApplyField(messages["Fill50"], ref data.Fill50);
                ApplyField(messages["Fill100"], ref data.Fill100);
                ApplyField(messages["Fill500"], ref data.Fill500);
                if (messages["VendingMessages"] != null)
                    vendingMachine.ApplyLanguage(messages["VendingMessages"].OuterXml);

                ApplyInfo(data);

                return true;
            }
            catch
            {
                ApplyInfo(new UserMessages());

                return false;
            }
        }

        private void ApplyInfo(UserMessages info)
        {
            this.Messages = info;
            this.Text = Messages.Header;
            this.groupBoxUserActions.Text = Messages.UserActions;
            this.buttonInsert10.Text = Messages.Fill10;
            this.buttonInsert50.Text = Messages.Fill50;
            this.buttonInsert100.Text = Messages.Fill100;
            this.buttonInsert500.Text = Messages.Fill500;
            this.buttonRandomize.Text = Messages.Randomize;
        }

        public void LoadSettings()
        {
            languages = new List<Language>();

            string configFile = "settings.xml";

            if (!File.Exists(configFile))
            {
                SaveSettings();
                return;
            }

            string xml = "";
            var doc = new XmlDocument();

            try
            {
                xml = File.ReadAllText(configFile, Encoding.UTF8);
                doc.Load(new StringReader(xml));
            }
            catch
            {
                return;
            }

            if (doc == null || doc.FirstChild == null)
                return;

            var settings = doc.FirstChild;
            if (settings.Name.ToLower() != "settings")
                return;

            foreach (XmlNode node in settings.ChildNodes)
            {
                switch (node.Name.ToLower())
                {
                    case "lang": AddLanguage(node); break;
                    case "selectedlang": SelectedLanguage = node.InnerText; break;
                    default: break;
                }
            }

            languagesList.DropDownItems.Clear();
            foreach (Language lang in languages)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = lang.Name;
                item.Text = lang.DisplayName;
                item.Tag = lang;
                item.Click += languageItemClick;
                languagesList.DropDownItems.Add(item);

                if (lang.Name.ToLower() == SelectedLanguage.ToLower())
                    SelectLanguage(lang);
            }
        }

        public void SaveSettings()
        {
            string outXml =
            @"<settings>
                <selectedLang>{0}</selectedLang>
                {1}
            </settings>";
            string langXml =
            @"
                <lang>
                    <name>{0}</name>
                    <displayname>{1}</displayname>
                    <filename>{2}</filename>
                </lang>
            ";
            string items = "";
            foreach (Language lang in languages)
                items += string.Format(langXml, lang.Name, lang.DisplayName, lang.FileName);

            string result = string.Format(outXml, SelectedLanguage, items);
            try
            {
                File.WriteAllText("settings.xml", result);
            }
            catch
            {

            }
        }

        List<Language> languages = new List<Language>();

        private void AddLanguage(XmlNode node)
        {
            if (node == null)
                return;

            Language lang = new Language();

            if (node["displayname"] != null && !string.IsNullOrEmpty(node["displayname"].InnerText))
                lang.DisplayName = node["displayname"].InnerText;
            else
                lang.DisplayName = "<undefined>";

            if (node["name"] != null && !string.IsNullOrEmpty(node["name"].InnerText))
                lang.Name = node["name"].InnerText;

            if (node["filename"] != null && !string.IsNullOrEmpty(node["filename"].InnerText))
                lang.FileName = node["filename"].InnerText;

            if (!string.IsNullOrEmpty(lang.FileName) && File.Exists(lang.FileName))
                languages.Add(lang);
        }

        public void SelectLanguage(Language lang)
        {
            if (lang == null || string.IsNullOrEmpty(lang.FileName) || !File.Exists(lang.FileName))
                return;

            if (ApplyLanguage(lang.FileName))
                SelectedLanguage = lang.Name;
        }

        private void languageItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null || item.Tag == null)
                return;
            Language lng = item.Tag as Language;
            if (lng == null)
                return;

            SelectLanguage(lng);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormVendingTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
    }

    public class Language
    {
        public string Name;
        public string DisplayName;
        public string FileName;
        
        public Language()
        {
            Name = "";
            DisplayName = "";
            FileName = "";
        }
    }

    public class InsertBanknoteEventArgs : EventArgs
    {
        public Banknote Banknote { get; private set; }

        public InsertBanknoteEventArgs(Banknote banknote)
        {
            Banknote = banknote;
        }

        public InsertBanknoteEventArgs(int value)
        {
            Banknote = new Banknote(value);
        }
    }

    public class UserMessages
    {
        public string Header = "Симулятор торгового автомата";
        public string UserActions = "Действия пользователя";
        public string Randomize = "Загрузить автомат";
        public string Fill10 = "Пополнить баланс на 10 рублей";
        public string Fill50 = "Пополнить баланс на 50 рублей";
        public string Fill100 = "Пополнить баланс на 100 рублей";
        public string Fill500 = "Пополнить баланс на 500 рублей";

        public UserMessages()
        {
        }
    }
}
