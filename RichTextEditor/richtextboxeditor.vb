
Imports System.ComponentModel
Public Class RichtextboxEditor

#Region "Variablen"

    Private m_rtf As String
    Private m_ToolbarVisible As Boolean = True
    Private m_PlainText As String

    Private cButtonActive As Color = SystemColors.ActiveCaption
    Private cButtonInactive As Color = SystemColors.Control

    Private tempcontent As String 'Zwischenspeicher für Copy-Paste

    'Vorgaben für Einzüge
    Private Const ABSTAND_LINKS As Integer = 10
    Private Const ABSTAND_ZUM_AUFZAEHLUNGSZEICHEN As Integer = 10

    Private AktuellerEinzug As Integer

    Private Const FONT_SIZE_MINIMAL As Integer = 6

#End Region



    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.rtb.BackColor = SystemColors.Control

        Fonts2Combobox(cboFonts)
        cboFonts.Text = "Arial"

        cboSize.Text = 10
        Me.rtb.SelectionFont = New Font(cboFonts.Text, Int(cboSize.Text))

        AddHandler btnPaste.Click, AddressOf Paste
        AddHandler mnPaste.Click, AddressOf Paste
        AddHandler btnCopy.Click, AddressOf Copy
        AddHandler mnCopy.Click, AddressOf Copy
        AddHandler btnCut.Click, AddressOf Cut
        AddHandler mnCut.Click, AddressOf Cut

        Me.rtb.SelectionFont = New Font("Arial", 10, FontStyle.Regular)

    End Sub

#Region "Eigenschaften"

    <Category("RichTextBoxEditor")>
    Public Property rtf As String
        Set(value As String)

            m_rtf = value

        End Set

        Get
            Return m_rtf

        End Get
    End Property

    <Category("RichTextBoxEditor")>
    Public Property ToolbarVisible As Boolean

        Set(value As Boolean)

            m_ToolbarVisible = value
            ToolStrip1.Visible = value

        End Set

        Get

            Return m_ToolbarVisible

        End Get

    End Property

    <Category("RichTextEditor")>
    Public ReadOnly Property PlainText As String
        Get
            Return m_PlainText
        End Get
    End Property

#End Region

#Region "Controls"

    Private Sub rtb_TextChanged(sender As Object, e As EventArgs) Handles rtb.TextChanged

        'Übergabe des Textes an die Eigenschaften rtf und PlainText
        m_rtf = rtb.Rtf.ToString
        m_PlainText = rtb.Text

    End Sub


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

    Private Sub btnHighlightColor_Click(sender As Object, e As EventArgs) Handles btnHighlightColor.Click

        Dim dlg As New ColorDialog

        dlg.Color = rtb.SelectionBackColor

        If dlg.ShowDialog = DialogResult.OK Then

            rtb.SelectionBackColor = dlg.Color

        End If

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

#End Region

#Region "Prozeduren"

    Public Sub SetzeRTF()

        Me.rtb.Rtf = m_rtf

    End Sub

    Public Sub Fonts2Combobox(ByRef TheCombobox As ToolStripComboBox)

        TheCombobox.Items.Clear()

        For Each f As FontFamily In FontFamily.Families

            TheCombobox.Items.Add(f.Name)

        Next

    End Sub

    Public Sub ClearText()

        rtb.Clear()

    End Sub

    Public Sub SetReadOnly(ByVal status As Boolean)

        rtb.ReadOnly = status

    End Sub

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


    Private Sub Paste()

        If (Clipboard.ContainsText(TextDataFormat.Rtf)) Then
            Me.rtb.SelectedRtf = Clipboard.GetText(TextDataFormat.Rtf)
        End If

    End Sub

    Private Sub Copy()

        Me.rtb.Copy()

    End Sub

    Private Sub Cut()

        Me.rtb.Cut()

    End Sub


#End Region








End Class
