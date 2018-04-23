Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.Services.Implementation
Imports DevExpress.Services
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native

Namespace SyntaxHighlight
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			richEditControl1.LoadDocument("FairyTales.rtf", DocumentFormat.Rtf)

			Dim service As ISyntaxHighlightService = richEditControl1.GetService(Of ISyntaxHighlightService)()
			Dim wrapper As New MySyntaxHighlightServiceWrapper(richEditControl1)
			richEditControl1.RemoveService(GetType(ISyntaxHighlightService))
			richEditControl1.AddService(GetType(ISyntaxHighlightService), wrapper)
		End Sub

		Private Class MySyntaxHighlightServiceWrapper
			Implements ISyntaxHighlightService
			Private control As RichEditControl
			Private Shared str() As String = { "luck", "Hans" }
			Private direction As SearchDirection = SearchDirection.Forward
			Private options As SearchOptions = SearchOptions.WholeWord Or SearchOptions.CaseSensitive
			Public Sub New(ByVal control As RichEditControl)
				Me.control = control
			End Sub
			#Region "ISyntaxHighlightService Members"

			Public Sub Execute() Implements ISyntaxHighlightService.Execute
				Dim doc As Document = Me.control.Document
				For Each word As String In str
					Dim result As ISearchResult = control.Document.StartSearch(word, options, direction, doc.Range)
					Do While result.FindNext()
						Dim charProperties As CharacterProperties = doc.BeginUpdateCharacters(result.CurrentResult)
						charProperties.ForeColor = Color.IndianRed
						doc.EndUpdateCharacters(charProperties)
					Loop
				Next word
				' your code here                
			End Sub

			#End Region
		End Class
	End Class
End Namespace