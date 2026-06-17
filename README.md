# PPZO-Project3

1. Temat: Aplikacja to proste przedstawienie systemu zarządzania biblioteką. Można dodać książki i czasopisma do katalogu, wyszukać je oraz zarządzać procesem wypożyczania.
2. Lista klas i ich dane
  1. LibraryItem - Szablon do książek i czasopism w aplikacji biblioteki. Odpowiada za przechowywanie uniwersalnych danych o zbiorze i zarządzanie jego statusem
    1. Id (typ GUID) - Identyfikacja - jest to unikalny numer po którym jednoznacznie można rozpoznać przedmiot w bazie.
    2. Title (typ STRING) - Wyświetlanie/Wyszukiwanie - podstawowa informacja dla użytkownika po której można wyszukać obiekt w bazie.
    3. isBorrowed (typ BOOL) - Stan/Obliczenia - decyduje czy obiekt może być wypożyczony czy nie.

  2. Book - Reprezentuje zbiór obiektów odpowiedzialny za książki w katalogu. Zadaniem tej klasy jest przechowywanie specyficznych dla książki szczegółów i wywołanie ich w razie potrzeby.
    1. Author (typ STRING) - Wyświetlanie - Informacja specyficzna dla książek, potrzebna na karcie informacyjnej przedmiotu.

  3. Magazine -  Reprezentuje zbiór obiektów odpowiedzialny za czasopisam w katalogu. Zadaniem tej klasy jest przechowywanie specyficznych dla czasopisma szczegółów i wywołanie ich w razie potrzeby.
    1. IsNumber (typ INT) - Wyświetlanie/Identyfikacja - Numer pozwalający odróżnić od siebie różne wydania tego samego czasopisma.

  4. User - Reprezentuje zbiór obiektów odpowiedzialnych za dane użytkownika biblioteki (np. jakie książki są wypożyczone).
    1. UserId (typ GUID) – Identyfikacja - Unikalny identyfikator konta czytelnika w systemie.
    2. Name (typ STRING) – Wyświetlanie - Imię i nazwisko do komunikacji (np. przy potwierdzaniu wypożyczenia).
    3. BorrowedItems (typ List<LibraryItem>) – Stan/Zapis -  Kolekcja przechowująca powiązania między czytelnikiem a wypożyczonymi przez niego książkami.

  5. LibraryCatalog - Reprezentuje zbiór wszystkich obiektów (książek i czasopism) które posiada biblioteka. Można je wyszukać lub przeglądać.
    1. _items (typ List<LibraryItem>) – Zapis/Stan - Główna struktura danych przechowująca pełną ofertę biblioteki.

  6. BorrowingService - Jest to klasa odpowiedzialna ze logike taką jak łączenie książki z użytkownikiem, sprawdzenie dostępności zbiory i je analizuje.

3. Zasady OOP
  1. enkapsulacja – W klasie LibraryItem właściwość IsBorrowed ma prywatny setter (public bool IsBorrowed { get; private set; }). Stan ten można zmienić tylko za pomocą dedykowanej metody SetBorrowedState(). W klasie User, lista wypożyczeń _borrowedItems jest prywatna, a na zewnątrz wystawiona jest tylko w formie tylko do odczytu (IReadOnlyList), modyfikacja odbywa się przez metody AddItem i RemoveItem.

  2. dziedziczenie – Klasa Book dziedziczy po LibraryItem (public class Book : LibraryItem). Dzięki temu Book ma z automatu właściwości Id, Title oraz IsBorrowed, ale może też dodać własną właściwość Author

  3. polimorfizm – Metoda DisplayInfo() jest wywoływana w pętli w klasie LibraryCatalog (item.DisplayInfo()). Pętla nie wie, czy aktualny item to książka czy czasopismo. Dzięki polimorfizmowi, dla obiektu Book wywoła się kod wypisujący autora, a dla obiektu Magazine kod wypisujący numer wydania.

  4. abstrakcja – Klasa LibraryItem jest oznaczona słowem kluczowym abstract. Nie możemy stworzyć bezpośrednio obiektu new LibraryItem(), ponieważ "element biblioteczny" sam w sobie jest pojęciem abstrakcyjnym. Metoda abstract void DisplayInfo() wymusza na klasach dziedziczących, aby same określiły, jak chcą prezentować swoje informacje.

4. Do czego użyto AI: Użyłam AI tylko do sprawdzenia czy przykłady, które podałam w punkcie 3 są poprawne.

