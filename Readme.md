<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/SyntaxHighlight/Form1.cs) (VB: [Form1.vb](./VB/SyntaxHighlight/Form1.vb))
* [Program.cs](./CS/SyntaxHighlight/Program.cs) (VB: [Program.vb](./VB/SyntaxHighlight/Program.vb))
<!-- default file list end -->
# Syntax Highlighting


<p>This example illustrates how the custom service can be used to implement syntax highlighting in the XtraRichEdit editor. The service should be based on the <strong>ISyntaxHighlightService </strong>interface. You can override the <strong>Execute </strong>method of the service which is called every time the document content is changed.</p><p>Starting from <strong>v2010 vol.2.6</strong> you are advised to use the <strong>DevExpress.XtraRichEdit.API.Native.SubDocument.ApplySyntaxHighlight</strong> method as demonstrated in the <a href="https://www.devexpress.com/Support/Center/p/E2993">E2993: Syntax highlighting for C# and VB code using DevExpress CodeParser and Syntax Highlight tokens</a> example.</p>

<br/>


