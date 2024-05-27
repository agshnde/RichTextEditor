﻿' RichTextEditor
' Public Class richtextboxeditor.Designer.vb
'
' MIT License
'
' Copyright (c) 2024 Andreas Spiegel
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

' Written by Andreas Spiegel <aspiegel@web.de>,


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RichtextboxEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl1 überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnFontDialog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboFonts = New System.Windows.Forms.ToolStripComboBox()
        Me.cboSize = New System.Windows.Forms.ToolStripComboBox()
        Me.btnColor = New System.Windows.Forms.ToolStripButton()
        Me.btnHighlightColor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBold = New System.Windows.Forms.ToolStripButton()
        Me.btnItalic = New System.Windows.Forms.ToolStripButton()
        Me.btnUnderline = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFontSizePlus = New System.Windows.Forms.ToolStripButton()
        Me.btnFontSizeMinus = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAufzaehlung = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEinzugPlus = New System.Windows.Forms.ToolStripButton()
        Me.btnEinzugMinus = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnCut = New System.Windows.Forms.ToolStripButton()
        Me.btnPaste = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.KontextMenue1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.KontextMenue1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFontDialog, Me.ToolStripSeparator2, Me.cboFonts, Me.cboSize, Me.btnColor, Me.btnHighlightColor, Me.ToolStripSeparator1, Me.btnBold, Me.btnItalic, Me.btnUnderline, Me.ToolStripSeparator3, Me.btnFontSizePlus, Me.btnFontSizeMinus, Me.ToolStripSeparator4, Me.btnAufzaehlung, Me.ToolStripSeparator5, Me.btnEinzugPlus, Me.btnEinzugMinus, Me.ToolStripSeparator6, Me.btnCopy, Me.btnCut, Me.btnPaste, Me.toolStripSeparator, Me.toolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(571, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnFontDialog
        '
        Me.btnFontDialog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFontDialog.Image = Global.RichTextEditor.My.Resources.Resources.Schriftdialog
        Me.btnFontDialog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFontDialog.Name = "btnFontDialog"
        Me.btnFontDialog.Size = New System.Drawing.Size(23, 22)
        Me.btnFontDialog.Text = "FontDialog"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cboFonts
        '
        Me.cboFonts.Name = "cboFonts"
        Me.cboFonts.Size = New System.Drawing.Size(121, 25)
        '
        'cboSize
        '
        Me.cboSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"})
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(75, 25)
        '
        'btnColor
        '
        Me.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnColor.Image = Global.RichTextEditor.My.Resources.Resources.format_text_color
        Me.btnColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(23, 22)
        Me.btnColor.Text = "Schriftfarbe"
        '
        'btnHighlightColor
        '
        Me.btnHighlightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHighlightColor.Image = Global.RichTextEditor.My.Resources.Resources.Oxygen_Icons_org_Oxygen_Actions_format_stroke_color_24
        Me.btnHighlightColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHighlightColor.Name = "btnHighlightColor"
        Me.btnHighlightColor.Size = New System.Drawing.Size(23, 22)
        Me.btnHighlightColor.Text = "Textmarkierung"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnBold
        '
        Me.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBold.Image = Global.RichTextEditor.My.Resources.Resources._118763_text_bold_format_format_text_bold
        Me.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBold.Name = "btnBold"
        Me.btnBold.Size = New System.Drawing.Size(23, 22)
        Me.btnBold.Text = "Fett"
        '
        'btnItalic
        '
        Me.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnItalic.Image = Global.RichTextEditor.My.Resources.Resources._118764_format_italic_text_text_italic_format
        Me.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnItalic.Name = "btnItalic"
        Me.btnItalic.Size = New System.Drawing.Size(23, 22)
        Me.btnItalic.Text = "Kursiv"
        '
        'btnUnderline
        '
        Me.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUnderline.Image = Global.RichTextEditor.My.Resources.Resources._118766_underline_underline_text_format_text_format
        Me.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnderline.Name = "btnUnderline"
        Me.btnUnderline.Size = New System.Drawing.Size(23, 22)
        Me.btnUnderline.Text = "Unterstrichen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnFontSizePlus
        '
        Me.btnFontSizePlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFontSizePlus.Image = Global.RichTextEditor.My.Resources.Resources.Schrift_Groesser
        Me.btnFontSizePlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFontSizePlus.Name = "btnFontSizePlus"
        Me.btnFontSizePlus.Size = New System.Drawing.Size(23, 22)
        Me.btnFontSizePlus.Text = "Schriftgröße erhöhen"
        '
        'btnFontSizeMinus
        '
        Me.btnFontSizeMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFontSizeMinus.Image = Global.RichTextEditor.My.Resources.Resources.Schrift_Kleiner
        Me.btnFontSizeMinus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFontSizeMinus.Name = "btnFontSizeMinus"
        Me.btnFontSizeMinus.Size = New System.Drawing.Size(23, 22)
        Me.btnFontSizeMinus.Text = "Schriftgröße verringern"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnAufzaehlung
        '
        Me.btnAufzaehlung.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAufzaehlung.Image = Global.RichTextEditor.My.Resources.Resources.Aufzaehlung_ein
        Me.btnAufzaehlung.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAufzaehlung.Name = "btnAufzaehlung"
        Me.btnAufzaehlung.Size = New System.Drawing.Size(23, 22)
        Me.btnAufzaehlung.Text = "Aufzählung an/aus"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnEinzugPlus
        '
        Me.btnEinzugPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEinzugPlus.Image = Global.RichTextEditor.My.Resources.Resources.EInzug_vergroessern
        Me.btnEinzugPlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEinzugPlus.Name = "btnEinzugPlus"
        Me.btnEinzugPlus.Size = New System.Drawing.Size(23, 22)
        Me.btnEinzugPlus.Text = "Einzug vergrößern"
        '
        'btnEinzugMinus
        '
        Me.btnEinzugMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEinzugMinus.Image = Global.RichTextEditor.My.Resources.Resources.Einzug_verkleinern
        Me.btnEinzugMinus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEinzugMinus.Name = "btnEinzugMinus"
        Me.btnEinzugMinus.Size = New System.Drawing.Size(23, 22)
        Me.btnEinzugMinus.Text = "Einzug verkleinern"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnCopy
        '
        Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCopy.Image = Global.RichTextEditor.My.Resources.Resources.clipboard_copy
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(23, 22)
        Me.btnCopy.Text = "In Zwischenablage kopieren"
        '
        'btnCut
        '
        Me.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCut.Image = Global.RichTextEditor.My.Resources.Resources.clipboard_cut
        Me.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCut.Name = "btnCut"
        Me.btnCut.Size = New System.Drawing.Size(23, 22)
        Me.btnCut.Text = "In Zwischenablage ausschneiden"
        '
        'btnPaste
        '
        Me.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPaste.Image = Global.RichTextEditor.My.Resources.Resources.clipb_paste
        Me.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(23, 20)
        Me.btnPaste.Text = "Aus Zwischenablage einfügen"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 6)
        '
        'toolStripSeparator7
        '
        Me.toolStripSeparator7.Name = "toolStripSeparator7"
        Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 6)
        '
        'rtb
        '
        Me.rtb.ContextMenuStrip = Me.KontextMenue1
        Me.rtb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtb.Location = New System.Drawing.Point(0, 25)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(571, 151)
        Me.rtb.TabIndex = 1
        Me.rtb.Text = ""
        '
        'KontextMenue1
        '
        Me.KontextMenue1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnCopy, Me.mnCut, Me.mnPaste})
        Me.KontextMenue1.Name = "KontextMenue1"
        Me.KontextMenue1.Size = New System.Drawing.Size(192, 70)
        '
        'mnCopy
        '
        Me.mnCopy.Image = Global.RichTextEditor.My.Resources.Resources.clipboard_copy
        Me.mnCopy.Name = "mnCopy"
        Me.mnCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnCopy.Size = New System.Drawing.Size(191, 22)
        Me.mnCopy.Text = "Kopieren"
        '
        'mnCut
        '
        Me.mnCut.Image = Global.RichTextEditor.My.Resources.Resources.clipboard_cut
        Me.mnCut.Name = "mnCut"
        Me.mnCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnCut.Size = New System.Drawing.Size(191, 22)
        Me.mnCut.Text = "Ausschneiden"
        '
        'mnPaste
        '
        Me.mnPaste.Image = Global.RichTextEditor.My.Resources.Resources.clipb_paste
        Me.mnPaste.Name = "mnPaste"
        Me.mnPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.mnPaste.Size = New System.Drawing.Size(191, 22)
        Me.mnPaste.Text = "Einfügen"
        '
        'RichtextboxEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rtb)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "RichtextboxEditor"
        Me.Size = New System.Drawing.Size(571, 176)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.KontextMenue1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents rtb As RichTextBox
    Friend WithEvents btnBold As ToolStripButton
    Friend WithEvents btnItalic As ToolStripButton
    Friend WithEvents btnUnderline As ToolStripButton
    Friend WithEvents cboFonts As ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cboSize As ToolStripComboBox
    Friend WithEvents btnFontDialog As ToolStripButton
    Friend WithEvents btnColor As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnHighlightColor As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnFontSizePlus As ToolStripButton
    Friend WithEvents btnFontSizeMinus As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnAufzaehlung As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnEinzugPlus As ToolStripButton
    Friend WithEvents btnEinzugMinus As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnCopy As ToolStripButton
    Friend WithEvents btnCut As ToolStripButton
    Friend WithEvents btnPaste As ToolStripButton
    Friend WithEvents KontextMenue1 As ContextMenuStrip
    Friend WithEvents mnCopy As ToolStripMenuItem
    Friend WithEvents mnCut As ToolStripMenuItem
    Friend WithEvents mnPaste As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents toolStripSeparator7 As ToolStripSeparator
End Class
