using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class FormsView : ContentPage
{
    // Храним все участки
    private ObservableCollection<string> Sections = new();

    public FormsView()
    {
        InitializeComponent();

        // Привязываем список участков к Picker
        SectionPicker.ItemsSource = Sections;
    }

    // Кнопка "Добавить таблицу"
    private void OnAddTableClicked(object sender, EventArgs e)
    {
        string? form = FormPicker.SelectedItem as string;
        string? construction = ConstructionPicker.SelectedItem as string;

        // Определяем участок: либо введён вручную, либо выбран
        string? section = SectionEntry.Text?.Trim();
        if (string.IsNullOrEmpty(section))
            section = SectionPicker.SelectedItem as string;

        // Проверяем ввод
        if (string.IsNullOrEmpty(form) || form == "None" ||
            string.IsNullOrEmpty(construction) || construction == "None" ||
            string.IsNullOrEmpty(section) || section == "None")
        {
            DisplayAlert("Ошибка", "Заполните все поля перед добавлением таблицы.", "ОК");
            return;
        }

        // Добавляем новый участок в список, если его нет
        if (!Sections.Contains(section))
        {
            Sections.Add(section);
            SectionPicker.ItemsSource = null;
            SectionPicker.ItemsSource = Sections;
        }

        string tableInfo = $"✅ Добавлена таблица:\nФорма: {form}\nУчасток: {section}\nКонструкция: {construction}";
        Console.WriteLine(tableInfo);
        DisplayAlert("Успех", tableInfo, "ОК");
    }

    // Кнопка "Удалить таблицу" (заглушка)
    private void OnRemoveTableClicked(object sender, EventArgs e)
    {
        DisplayAlert("Удаление", "Функция удаления таблиц будет добавлена позже.", "ОК");
    }
}