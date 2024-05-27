' RichTextEditor
'
' MIT License
'
' Copyright (c) Andreas Spiegel
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
' associated documentation files (the "Software"), to deal in the Software without restriction, 
' including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
' and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
' subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or 
' substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
' INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
' PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
' DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms
Public Class RichtextboxEditor

#Region "Variablen"



    Private cButtonActive As Color = SystemColors.ActiveCaption
    Private cButtonInactive As Color = SystemColors.Control

    Private tempcontent As String 'Zwischenspeicher für Copy-Paste

    'Vorgaben für Einzüge
    Private Const ABSTAND_LINKS As Integer = 10
    Private Const ABSTAND_ZUM_AUFZAEHLUNGSZEICHEN As Integer = 10

    Private AktuellerEinzug As Integer

    Private Const FONT_SIZE_MINIMAL As Integer = 6

#End Region

#Region "Konstruktor"

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.rtb.BackColor = SystemColors.Control

        'Hyperlinks erkennen
        Me.rtb.DetectUrls = m_UrlDetection

        Fonts2Combobox(cboFonts)
        cboFonts.Text = "Arial"

        cboSize.Text = 10
        Me.rtb.Font = New Font(cboFonts.Text, Int(cboSize.Text))

        AddHandler btnPaste.Click, AddressOf Paste
        AddHandler mnPaste.Click, AddressOf Paste
        AddHandler btnCopy.Click, AddressOf Copy
        AddHandler mnCopy.Click, AddressOf Copy
        AddHandler btnCut.Click, AddressOf Cut
        AddHandler mnCut.Click, AddressOf Cut

    End Sub

#End Region

#Region "Eigenschaften"

    Private m_rtf As String
    Private m_ToolbarVisible As Boolean = True
    Private m_PlainText As String
    Private m_UrlDetection As Boolean = True
    Private m_AllowBulletPoints As Boolean = True
    Private m_MenueStripBackColor As Color = SystemColors.Control
    Private m_SheetColor As Color = SystemColors.Control

    <Category("RichTextBoxEditor")>
    <Description("Blendet die Schaltfäche 'Aufzählung' ein oder aus")>
    Public Property AllowBulletPoints As Boolean
        Set(value As Boolean)
            m_AllowBulletPoints = value
            btnAufzaehlung.Visible = m_AllowBulletPoints
        End Set
        Get
            Return m_AllowBulletPoints
        End Get
    End Property

    <Category("RichTextBoxEditor")>
    <Description("Den RTF-String abfragen oder setzen")>
    Public Property rtf As String
        Set(value As String)
            m_rtf = value
            SetzeRTF()
        End Set
        Get
            Return m_rtf
        End Get
    End Property

    <Category("RichTextBoxEditor")>
    <Description("Buttonleiste ein- oder ausblenden")>
    Public Property ToolbarVisible As Boolean

        Set(value As Boolean)
            m_ToolbarVisible = value
            ToolStrip1.Visible = value
        End Set
        Get
            Return m_ToolbarVisible
        End Get

    End Property

    <Category("RichTextBoxEditor")>
    <Description("Simplen Text schreiben oder auslesen")>
    Public Property PlainText As String
        Get
            Return m_PlainText
        End Get
        Set(value As String)
            m_PlainText = value
            rtb.Text = m_PlainText
        End Set
    End Property

    <Category("RichTextBoxEditor")>
    <Description("Schaltet die Linkerkennung ein oder aus")>
    Public Property UrlDetection As Boolean
        Set(value As Boolean)
            m_UrlDetection = value
            rtb.DetectUrls = m_UrlDetection
        End Set
        Get
            Return m_UrlDetection
        End Get
    End Property

    <Category("RichTextBoxEditor")>
    <Description("Hintegrundfarbe der Buttonleiste festlegen")>
    Public WriteOnly Property MenuStripBackColor As Color
        Set(value As Color)
            m_MenueStripBackColor = value
            ToolStrip1.BackColor = m_MenueStripBackColor
        End Set
    End Property

    <Category("RichTextBoxEditor")>
    <Description("Die Paperfarbe des Textbereichs festlegen")>
    Public WriteOnly Property SheetColor As Color
        Set(value As Color)
            m_SheetColor = value
            rtb.BackColor = m_SheetColor
        End Set
    End Property

#End Region

#Region "Prozeduren"

    ''' <summary>
    ''' RTF-Text in die Richtextbox übernehmen
    ''' </summary>
    Public Sub SetzeRTF()

        Me.rtb.Rtf = m_rtf

    End Sub

    ''' <summary>
    ''' Schriftarten in cboFonts einlesen
    ''' </summary>
    ''' <param name="TheCombobox"></param>
    Public Sub Fonts2Combobox(ByRef TheCombobox As ToolStripComboBox)

        TheCombobox.Items.Clear()

        For Each f As FontFamily In FontFamily.Families

            TheCombobox.Items.Add(f.Name)

        Next

    End Sub

    ''' <summary>
    ''' Richtextbox leeren
    ''' </summary>
    Public Sub ClearText()

        rtb.Clear()

    End Sub

    ''' <summary>
    ''' ReadOnly-Status togglen
    ''' </summary>
    ''' <param name="status"></param>
    Public Sub SetReadOnly(ByVal status As Boolean)

        rtb.ReadOnly = status

    End Sub

    ''' <summary>
    ''' Die Buttons für den Fontstyle je nach Curorsposition einfärben
    ''' </summary>
    Private Sub SetButtonBackColor()

        Dim oFontStyle As FontStyle

        oFontStyle = rtb.SelectionFont.Style

        Select Case oFontStyle

            Case FontStyle.Bold
                btnBold.BackColor = cButtonActive
                btnItalic.BackColor = cButtonInactive
                btnUnderline.BackColor = cButtonInactive
            Case FontStyle.Italic
                btnBold.BackColor = cButtonInactive
                btnItalic.BackColor = cButtonActive
                btnUnderline.BackColor = cButtonInactive
            Case FontStyle.Underline
                btnBold.BackColor = cButtonInactive
                btnItalic.BackColor = cButtonInactive
                btnUnderline.BackColor = cButtonActive
            Case FontStyle.Bold Xor FontStyle.Italic
                btnBold.BackColor = cButtonActive
                btnItalic.BackColor = cButtonActive
                btnUnderline.BackColor = cButtonInactive
            Case FontStyle.Bold Xor FontStyle.Underline
                btnBold.BackColor = cButtonActive
                btnItalic.BackColor = cButtonInactive
                btnUnderline.BackColor = cButtonActive
            Case FontStyle.Bold Xor FontStyle.Italic Xor FontStyle.Underline
                btnBold.BackColor = cButtonActive
                btnItalic.BackColor = cButtonActive
                btnUnderline.BackColor = cButtonActive
            Case FontStyle.Italic Xor FontStyle.Underline
                btnBold.BackColor = cButtonInactive
                btnItalic.BackColor = cButtonActive
                btnUnderline.BackColor = cButtonActive
            Case FontStyle.Regular
                btnBold.BackColor = cButtonInactive
                btnItalic.BackColor = cButtonInactive
                btnUnderline.BackColor = cButtonInactive
            Case Else
                btnBold.BackColor = cButtonInactive
                btnItalic.BackColor = cButtonInactive
                btnUnderline.BackColor = cButtonInactive


        End Select

    End Sub

    ''' <summary>
    ''' RTF aus der Zwischenablage einfügen
    ''' </summary>
    Private Sub Paste()

        If (Clipboard.ContainsText(TextDataFormat.Rtf)) Then
            Me.rtb.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf)
        ElseIf (Clipboard.ContainsText(TextDataFormat.Text)) Then
            Me.rtb.SelectedText = Clipboard.GetText(TextDataFormat.Text)
        Else
            MsgBox("Das Format wird nicht unterstützt!")
        End If

    End Sub

    ''' <summary>
    ''' Auswahl in die Zwischenablage kopieren
    ''' </summary>
    Private Sub Copy()

        Me.rtb.Copy()

    End Sub

    ''' <summary>
    ''' Auswahl in die Zwischenablage ausschneiden
    ''' </summary>
    Private Sub Cut()

        Me.rtb.Cut()

    End Sub

#End Region

#Region "Controls"

    Private Sub btnBold_Click(sender As Object, e As EventArgs) Handles btnBold.Click

        With Me.rtb
            .SelectionFont = New System.Drawing.Font(.SelectionFont.FontFamily, .SelectionFont.Size, .SelectionFont.Style Xor FontStyle.Bold)
        End With
        SetButtonBackColor()

    End Sub

    Private Sub btnItalic_Click(sender As Object, e As EventArgs) Handles btnItalic.Click

        With Me.rtb
            .SelectionFont = New System.Drawing.Font(.SelectionFont.FontFamily, .SelectionFont.Size, .SelectionFont.Style Xor FontStyle.Italic)
        End With
        SetButtonBackColor()
    End Sub

    Private Sub btnUnderline_Click(sender As Object, e As EventArgs) Handles btnUnderline.Click

        With Me.rtb
            .SelectionFont = New System.Drawing.Font(.SelectionFont.FontFamily, .SelectionFont.Size, .SelectionFont.Style Xor FontStyle.Underline)
        End With
        SetButtonBackColor()
    End Sub

    Private Sub btnFontDialog_Click(sender As Object, e As EventArgs) Handles btnFontDialog.Click

        Dim dlg As New FontDialog
        Dim oFont As New Font(dlg.Font.Name, dlg.Font.Size, dlg.Font.Style)

        dlg.Font = rtb.SelectionFont

        If dlg.ShowDialog = DialogResult.OK Then

            Me.rtb.SelectionFont = oFont

        End If

    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click

        Dim dlg As New ColorDialog

        dlg.Color = rtb.SelectionColor

        If dlg.ShowDialog = DialogResult.OK Then

            rtb.SelectionColor = dlg.Color

        End If

    End Sub


    Private Sub rtb_TextChanged(sender As Object, e As EventArgs) Handles rtb.TextChanged

        'Übergabe des Textes an die Eigenschaft rtf
        m_rtf = rtb.Rtf.ToString

        'Übergabe des PlainTextes an die Eigenschaft PlainText
        m_PlainText = rtb.Text


    End Sub


    Private Sub cboFonts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFonts.SelectedIndexChanged

        With Me.rtb

            If rtb.SelectionFont IsNot Nothing Then

                .SelectionFont = New System.Drawing.Font(cboFonts.Text, .SelectionFont.Size, .SelectionFont.Style)

            End If

        End With

    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged

        With Me.rtb

            If rtb.SelectionFont IsNot Nothing Then

                .SelectionFont = New System.Drawing.Font(.SelectionFont.FontFamily, Int(cboSize.Text), .SelectionFont.Style)

            End If

        End With

    End Sub

    Private Sub rtb_SelectionChanged(sender As Object, e As EventArgs) Handles rtb.SelectionChanged

        If rtb.SelectionFont Is Nothing Then

            cboFonts.Text = Nothing
            cboSize.Text = Nothing

        Else

            cboFonts.Text = rtb.SelectionFont.Name
            cboSize.Text = rtb.SelectionFont.Size

            SetButtonBackColor()

        End If

    End Sub

    Private Sub btnHighlightColor_Click(sender As Object, e As EventArgs) Handles btnHighlightColor.Click

        Dim dlg As New ColorDialog

        dlg.Color = rtb.SelectionBackColor

        If dlg.ShowDialog = DialogResult.OK Then

            rtb.SelectionBackColor = dlg.Color

        End If

    End Sub

    Private Sub btnFontSizePlus_Click(sender As Object, e As EventArgs) Handles btnFontSizePlus.Click

        Me.rtb.SelectionFont = New Font(Me.rtb.SelectionFont.FontFamily, CInt(cboSize.Text) + 1, Me.rtb.SelectionFont.Style)
        cboSize.Text = Me.rtb.SelectionFont.Size.ToString

    End Sub

    Private Sub btnFontSizeMinus_Click(sender As Object, e As EventArgs) Handles btnFontSizeMinus.Click

        If CInt(cboSize.Text) >= FONT_SIZE_MINIMAL Then
            Me.rtb.SelectionFont = New Font(Me.rtb.SelectionFont.FontFamily, CInt(cboSize.Text) - 1, Me.rtb.SelectionFont.Style)
            cboSize.Text = Me.rtb.SelectionFont.Size.ToString
        End If

    End Sub

    Private Sub btnAufzaehlung_Click(sender As Object, e As EventArgs) Handles btnAufzaehlung.Click

        If Me.rtb.SelectionBullet = True Then

            AktuellerEinzug -= ABSTAND_LINKS

            Me.rtb.SelectionIndent = AktuellerEinzug
            Me.rtb.SelectionHangingIndent = 0
            Me.rtb.SelectionBullet = False

        Else

            AktuellerEinzug += ABSTAND_LINKS
            Me.rtb.SelectionIndent = AktuellerEinzug
            Me.rtb.SelectionHangingIndent = ABSTAND_ZUM_AUFZAEHLUNGSZEICHEN
            Me.rtb.SelectionBullet = True

        End If

    End Sub

    Private Sub btnEinzugPlus_Click(sender As Object, e As EventArgs) Handles btnEinzugPlus.Click

        AktuellerEinzug += ABSTAND_LINKS
        Me.rtb.SelectionIndent = AktuellerEinzug

    End Sub

    Private Sub btnEinzugMinus_Click(sender As Object, e As EventArgs) Handles btnEinzugMinus.Click

        If AktuellerEinzug >= ABSTAND_LINKS Then

            AktuellerEinzug -= ABSTAND_LINKS

        Else

            AktuellerEinzug = 0

        End If

        Me.rtb.SelectionIndent = AktuellerEinzug

    End Sub

    Private Sub rtb_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles rtb.LinkClicked

        ' bei Klick auf Hyperlink autom. die URL im 
        ' Standard-Browser öffnen
        If m_UrlDetection = True Then
            System.Diagnostics.Process.Start(e.LinkText)
        End If

    End Sub


#End Region

End Class
