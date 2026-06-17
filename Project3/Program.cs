using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    //ABSTRAKCJA: Abstrakcyjna klasa bazowa dla wszystkich elementów w bibliotece
    public abstract class LibraryItem
    {
        // ENKAPSULACJA: Właściwości z prywatnymi setterami chronią stan obiektu
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public bool IsBorrowed { get; private set; }

        public LibraryItem(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsBorrowed = false;
        }

        // Metoda do zmiany stanu - enkapsulacja logiki wypożyczania
        public void SetBorrowedState(bool state)
        {
            IsBorrowed = state;
        }

        // POLIMORFIZM: Abstrakcyjna metoda, którą klasy pochodne muszą zaimplementować
        public abstract void DisplayInfo();
    }

    //DZIEDZICZENIE: Klasa Book dziedziczy po LibraryItem
    public class Book : LibraryItem
    {
        public string Author { get; private set; }

        public Book(string title, string author) : base(title)
        {
            Author = author;
        }

        // POLIMORFIZM: Przesłonięcie metody z klasy bazowej
        public override void DisplayInfo()
        {
            string status = IsBorrowed ? "Wypozyczona" : "Dostepna";
            Console.WriteLine($"[Książka] Tytul: '{Title}', Autor: {Author} - Status: {status}");
        }
    }

    //DZIEDZICZENIE: Klasa Magazine dziedziczy po LibraryItem
    public class Magazine : LibraryItem
    {
        public int IsNumber { get; private set; }

        public Magazine(string title, int isNumber) : base(title)
        {
            IsNumber = isNumber;
        }

        public override void DisplayInfo()
        {
            string status = IsBorrowed ? "Wypozyczone" : "Dostepne";
            Console.WriteLine($"[Czasopismo] Tytul: '{Title}', Numer: {IsNumber} - Status: {status}");
        }
    }

    // Klasa reprezentująca czytelnika
    public class User
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }

        // Kompozycja/Agregacja: Użytkownik posiada listę wypożyczonych przedmiotów
        private List<LibraryItem> _borrowedItems;

        public IReadOnlyList<LibraryItem> BorrowedItems => _borrowedItems.AsReadOnly();

        public User(string name)
        {
            UserId = Guid.NewGuid();
            Name = name;
            _borrowedItems = new List<LibraryItem>();
        }

        public void AddItem(LibraryItem item)
        {
            _borrowedItems.Add(item);
        }

        public void RemoveItem(LibraryItem item)
        {
            _borrowedItems.Remove(item);
        }
    }

    // Klasa odpowiedzialna WYŁĄCZNIE za przechowywanie zbiorów (Katalog)
    public class LibraryCatalog
    {
        private List<LibraryItem> _items = new List<LibraryItem>();

        public void AddToCatalog(LibraryItem item)
        {
            _items.Add(item);
        }

        public LibraryItem FindItemByTitle(string title)
        {
            return _items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowAllItems()
        {
            Console.WriteLine("\n--- Katalog Biblioteki ---");
            foreach (var item in _items)
            {
                item.DisplayInfo(); // Wywołanie polimorficzne
            }
            Console.WriteLine("--------------------------\n");
        }
    }

    // Klasa odpowiedzialna WYŁĄCZNIE za logikę wypożyczania i zwrotów (Serwis)
    public class BorrowingService
    {
        public void BorrowItem(User user, LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Nie znaleziono takiego przedmiotu.");
                return;
            }

            if (item.IsBorrowed)
            {
                Console.WriteLine($"Przepraszamy, '{item.Title}' jest już wypozyczone.");
                return;
            }

            item.SetBorrowedState(true);
            user.AddItem(item);
            Console.WriteLine($"Uzytkownik {user.Name} pomyslnie wypozyczyl '{item.Title}'.");
        }

        public void ReturnItem(User user, LibraryItem item)
        {
            if (item != null && user.BorrowedItems.Contains(item))
            {
                item.SetBorrowedState(false);
                user.RemoveItem(item);
                Console.WriteLine($"Uzytkownik {user.Name} zwrocil '{item.Title}'.");
            }
            else
            {
                Console.WriteLine($"Uzytkownik {user.Name} nie posiada wypozyczonego przedmiotu '{item?.Title}'.");
            }
        }
    }

    // Punkt wejścia aplikacji
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}