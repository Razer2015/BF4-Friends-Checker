using System;
using System.Drawing;
using System.Windows.Forms;

public static class RichTextBoxExtensions
{
    public static void AppendWithTime(this RichTextBox box, string text) {
        box.AppendText($"{DateTime.Now.ToLongTimeString()} | ");
        box.AppendText(text);
    }

    public static void AppendWithTime(this RichTextBox box, string text, Color textColor, bool bold = false) {
        box.AppendText($"{DateTime.Now.ToLongTimeString()} | ");
        box.AppendText(text, textColor, box.BackColor, bold);
    }

    public static void AppendWithTime(this RichTextBox box, string text, Color textColor, Color bgColor, bool bold = false) {
        box.AppendText($"{DateTime.Now.ToLongTimeString()} | ");
        box.AppendText(text, textColor, bgColor, bold);
    }

    public static void AppendWithTime(this RichTextBox box, string text, LogType logType = LogType.NORMAL, bool bold = false) {
        box.AppendText($"{DateTime.Now.ToLongTimeString()} | ");

        string logText = "";
        Color textColor = box.SelectionColor;
        Color backgroundColor = box.SelectionBackColor;

        switch (logType) {
            case LogType.NORMAL:
            default:
                break;
            case LogType.INFORMATION:
                logText = "Info";
                textColor = Color.White;
                backgroundColor = Color.Green;
                break;
            case LogType.WARNING:
                logText = "Warning";
                textColor = Color.Black;
                backgroundColor = Color.Yellow;
                break;
            case LogType.ERROR:
                logText = "Error";
                textColor = Color.White;
                backgroundColor = Color.Red;
                break;
        }
        box.AppendText(logText, textColor, backgroundColor, bold);

        box.AppendText($" | {text}");
    }

    public static void AppendText(this RichTextBox box, string text, Color textColor, Color bgColor, bool bold = false) {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        var oldFG = box.SelectionColor;
        var oldBG = box.SelectionBackColor;
        var oldFont = box.SelectionFont;

        box.SelectionColor = textColor;
        box.SelectionBackColor = bgColor;
        box.SelectionFont = new Font(box.SelectionFont, FontStyle.Bold);
        box.AppendText(text);
        box.SelectionColor = oldFG;
        box.SelectionBackColor = oldBG;
        box.SelectionFont = oldFont;
    }
}
