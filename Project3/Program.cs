using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    // 1. ABSTRAKCJA: Abstrakcyjna klasa bazowa dla wszystkich elementów w bibliotece
    public abstract class LibraryItem
    {

    }

    // 2. DZIEDZICZENIE: Klasa Book dziedziczy po LibraryItem
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