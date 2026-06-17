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

    }

    // Klasa reprezentująca czasopismo (kolejny przykład dziedziczenia i polimorfizmu)
    public class Magazine : LibraryItem
    {

    }

    // Klasa reprezentująca czytelnika
    public class User
    {

    }

    // Klasa odpowiedzialna WYŁĄCZNIE za przechowywanie zbiorów (Katalog)
    public class LibraryCatalog
    {

    }

    // Klasa odpowiedzialna WYŁĄCZNIE za logikę wypożyczania i zwrotów (Serwis)
    public class BorrowingService
    {

    }

    // Punkt wejścia aplikacji
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}