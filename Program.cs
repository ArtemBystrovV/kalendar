using System;
using System.Collections.Generic;

class Program
{
    static List<Note> notes = new List<Note>();
    static int dateindex = 0;

    static void Main(string[] args)
    {
        notes.Add(new Note("Тренировка", "Сходить на тренировку вечером", new DateTime(2024, 1, 12)));
        notes.Add(new Note("Уборка", "Убраться дома перед приходом друзей", new DateTime(2023, 1, 12)));
        notes.Add(new Note("Врач", "Запсиь к врачу на 8:00", new DateTime(2023, 1, 15)));
        notes.Add(new Note("Работа", "Собеседование в мак", new DateTime(2023, 1, 16)));
        notes.Add(new Note("ДР", "День рождения цветка Виталия", new DateTime(2023, 1, 20)));
        while (true)
        {
            Console.Clear();
            ShowMenu();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    ChangeDate(-1);
                    break;
                case ConsoleKey.DownArrow:
                    ChangeDate(1);
                    break;
                case ConsoleKey.Enter:
                    ViewNoteDetails();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Дата" + notes[dateindex].Date.ToString("dd.MM.yyyy") + ":");
        for (int i = 0; i < notes.Count; i++)
        {
            Console.Write(dateindex == i ? "--> " : "  ");
            Console.WriteLine(notes[i].Title);
        }
    }

    static void ChangeDate(int step)
    {
        dateindex = (dateindex + step + notes.Count) % notes.Count;
    }

    static void ViewNoteDetails()
    {
        Console.Clear();
        Note selectedNote = notes[dateindex];
        Console.WriteLine("Дата: " + selectedNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Название: " + selectedNote.Title);
        Console.WriteLine("Описание: " + selectedNote.Description);
        Console.ReadLine();
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}