using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Tmds.DBus.Protocol;

namespace DriversApp;

public partial class Window1 : Window
{


    public Window1()
    {
        InitializeComponent();
        popup = this.FindControl<Popup>("AdressPopup"); //�������� �������� ��� �������������� ����� �����������
        listBox = this.FindControl<ListBox>("AdressListBox");

        var textBox = this.FindControl<TextBox>("Adress");
        textBox.TextChanged += OnTextChanged;

        popup1 = this.FindControl<Popup>("AdressFactPopup"); //�������� �������� ��� �������������� ������ ����������
        listBox1 = this.FindControl<ListBox>("AdressFactListBox");

        var textBox1 = this.FindControl<TextBox>("AdressFact");
        textBox1.TextChanged += OnTextChanged;
    }

    public void ValidEmail(object sender, RoutedEventArgs e) //�������� ����� �� ������������
    {
        string email = Email.Text;

        if (IsValidEmail(email))
        {
            ErrorText.Text = " ";
        }
        else
        {
            ErrorText.Text = "������������ email";
            ErrorText.Foreground = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Colors.Red);
        }
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }
        else
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[^a-zA-Z0-9._]+\.[^a-zA-Z]{2,}$"; //������ �����

            return Regex.IsMatch(email, pattern);
        }
    }


    //������� ��� �������������� ������

    private readonly List<string> suggestions = new List<string>
    {
        "����������", "�����������", "������", "�����-���������", "������", "������", "�������", "�����������", "�������"
    };

    private Popup popup; //����� � �������� ��� ������ ����������� 
    private ListBox listBox;
    private void OnTextChanged(object sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;

        if (textBox != null)
        {
            string input = textBox.Text.ToLower(); // �������� ��������� ����� � ������ ��������

            // ������� �����������, ������� ���������� � ���������� ������
            var matchingSuggestions = suggestions
                .Where(s => s.ToLower().StartsWith(input))
                .ToList();

            if (matchingSuggestions.Any())
            {
                popup.IsOpen = true;
                listBox.ItemsSource = matchingSuggestions;
            }
            else
            {
                popup.IsOpen = false;
            }
        }
    }
    private void OnSuddestionSelected(object sender, SelectionChangedEventArgs e) //���������� ����� �� ������ � ������
    {
        if (listBox.SelectedItem != null)
        {
            var selectedSug = listBox.SelectedItem.ToString();
            var textBox = this.FindControl<TextBox>("Adress");
            textBox.Text = selectedSug;
            popup.IsOpen = false;
        }
    }

    private readonly List<string> suggestions1 = new List<string>
    {
        "����������", "�����������", "������", "�����-���������", "������", "������", "�������", "�����������", "�������"
    };
    private Popup popup1; //����� � �������� ��� ������ ���������� 
    private ListBox listBox1;

    private void OnTextChanged1(object sender, Avalonia.Controls.TextChangedEventArgs e) //�������������� ��� ������ ����������
    {
        var textBox1 = sender as TextBox;

        if (textBox1 != null)
        {
            string input = textBox1.Text.ToLower(); // �������� ��������� ����� � ������ ��������

            // ������� �����������, ������� ���������� � ���������� ������
            var matchingSuggestions1 = suggestions1
                .Where(s => s.ToLower().StartsWith(input))
                .ToList();

            if (matchingSuggestions1.Any())
            {
                popup1.IsOpen = true;
                listBox1.ItemsSource = matchingSuggestions1;
            }
            else
            {
                popup1.IsOpen = false;
            }
        }
    }
    private void OnSuddestionSelected1(object sender, SelectionChangedEventArgs e) //���������� ����� �� ������ � ������
    {
        if (listBox1.SelectedItem != null)
        {
            var selectedSug1 = listBox1.SelectedItem.ToString();
            var textBox1 = this.FindControl<TextBox>("AdressFact");
            textBox1.Text = selectedSug1;
            popup1.IsOpen = false;
        }
    }
} 
//������� ��� ������ (�� ��������)
    //public async void AddImg(object sender, RoutedEventArgs e)
    //{
    //    var openfileDialog = new OpenFileDialog //�������� ��������� ������� ��� ������ �����������
    //    {
    //        AllowMultiple = false, //������ �� ����� ���������� ������
    //        Filters = new List<FileDialogFilter>
    //        {
    //            new FileDialogFilter
    //            {
    //                Name = "Image Files",
    //                Extensions = new List<string> {"jpg", "png"}
    //            }
    //        }
    //    }

    //    var result = await openFileDialog.ShowAsync(this);

    //    if (result != null && result.Length > 0)
    //    {
    //        string filePath = result[0].ToString();

    //        if (!IsValidImageFormat(FilePath))
    //        {
    //            ErrorText.Text = "���� ������ ���� ������� JPG/PNG";
    //            return;
    //        }
    //    }

    //        var bitmap = new Bitmap(filePath);

    //        if (!IsAspectRatioValid(bitmap))
    //        {
    //            ErrorText.Text = "����������� ������ ����� ����������� ������ 3:4";
    //            return;
    //        }

    //        ImageView.Source = bitmap;
    //        ErrorText.Text = "";
    //    }
    //}
    //    private bool IsValidImageFormat(string filePath) //�������� �� ������ ������
    //{
    //    string extension = Path.GetExtension(filePath)?.ToLower();
    //    return extension == ".jpg" || extension == ".png";
    //}

    //private bool IsAspectRatioValid(Bitmap bitmap)
    //{
    //    int width = bitmap.PixelSize.Width;
    //    int height = bitmap.PixelSize.Height;

    //    return Math.Abs((double)width / height - (3.0 / 4.0)) < 0.05; //�������� ����������� ������
    //}  