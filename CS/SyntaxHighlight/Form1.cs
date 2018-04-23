using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Services.Implementation;
using DevExpress.Services;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace SyntaxHighlight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richEditControl1.LoadDocument("FairyTales.rtf", DocumentFormat.Rtf);

            ISyntaxHighlightService service = richEditControl1.GetService<ISyntaxHighlightService>();
            MySyntaxHighlightServiceWrapper wrapper = new MySyntaxHighlightServiceWrapper(richEditControl1);
            richEditControl1.RemoveService(typeof(ISyntaxHighlightService));
            richEditControl1.AddService(typeof(ISyntaxHighlightService), wrapper);
        }

        class MySyntaxHighlightServiceWrapper : ISyntaxHighlightService
        {
            RichEditControl control;
            static string[] str = { "luck", "Hans" };
            SearchDirection direction = SearchDirection.Forward;
            SearchOptions options = SearchOptions.WholeWord |SearchOptions.CaseSensitive;
            public MySyntaxHighlightServiceWrapper(RichEditControl control) {
                this.control = control;
            }
            #region ISyntaxHighlightService Members

            public void Execute()
            {
                Document doc = this.control.Document;
                foreach (string word in str) {
                    ISearchResult result = control.Document.StartSearch(word, options, direction, doc.Range);
                    while (result.FindNext())
                    {
                        CharacterProperties charProperties = doc.BeginUpdateCharacters(result.CurrentResult);                        
                        charProperties.ForeColor = Color.IndianRed;
                        doc.EndUpdateCharacters(charProperties);
                    }
                }
                // your code here                
            }

            #endregion
        }
}
}