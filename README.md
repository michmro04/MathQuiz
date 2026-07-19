English version 
# MathQuiz 🧮

A modern, modular desktop application built with C# and WPF, designed to help students practice mathematics through interactive quizzes. The application features a gamified target-score system and an integrated SMTP email engine for sending automated progress reports directly to teachers.

## 🚀 Key Features

* **Gamified Learning:** Users set a personal score goal before starting the session, encouraging consistent practice.
* **Multiple Math Modules:** Supports various dynamic quiz engines:
  * Linear Equations
  * Pythagorean Theorem
  * Percentages
  * Missing Angles in Polygons
* **Automated Email Reporting:** Integrated asynchronous SMTP client allows students to send detailed session summaries to their tutors with a single click.
* **Global Session State:** Tracks scores across different modules in real-time using a centralized session manager.
* **Robust Error Handling:** Custom global error-catching mechanism with automated fallback UI and admin reporting.

## 🧠 Architecture & Clean Code Practices

This project was built with a strong emphasis on software engineering best practices:

* **Single Responsibility Principle (SRP) & DRY:** Business logic is strictly separated from the UI. Features like email sending are encapsulated in dedicated static classes (`EmailEngine.cs`).
* **Dependency Injection:** Quiz modules implement the `IQuizEngine` interface, allowing the `UniversalQuizPage` to dynamically load any math topic without code duplication.
* **Asynchronous Programming:** Heavy network operations (SMTP communication) utilize `async/await` to maintain a fully responsive user interface.
* **Security:** Sensitive data (e.g., SMTP App Passwords) is completely decoupled from the source code using ignored configuration files/classes (`.gitignore`).

## 🛠️ Technologies
* C# (.NET 8.0)
* WPF (Windows Presentation Foundation)
* System.Net.Mail (SMTP)

## 👨‍💻 Author
**Michał** - Informatics Student at Gdańsk University of Technology

------
Wersja polska
# MathQuiz 🧮

Nowoczesna, modułowa aplikacja desktopowa (C# / WPF) stworzona z myślą o uczniach ćwiczących matematykę. Program posiada system celów punktowych oraz wbudowany silnik SMTP, który pozwala na automatyczne wysyłanie raportów z wynikami bezpośrednio do korepetytora.

## 🚀 Główne funkcje

* **Grywalizacja:** Uczeń ustala dzienny cel punktowy przed rozpoczęciem nauki, co motywuje do dłuższego treningu.
* **Różnorodne moduły:** Dynamicznie generowane zadania z działów:
  * Równania liniowe
  * Twierdzenie Pitagorasa
  * Procenty
  * Brakujące kąty w wielokątach
* **Raportowanie E-mail:** Wbudowany asynchroniczny klient SMTP pozwala jednym kliknięciem wysłać szczegółowe podsumowanie sesji na wskazany adres e-mail.
* **Globalny Stan Aplikacji:** Punkty z różnych działów są sumowane na bieżąco dzięki scentralizowanemu menedżerowi sesji.
* **Zaawansowana obsługa błędów:** Dedykowany mechanizm wyłapywania wyjątków z automatycznym ekranem awaryjnym (`ErrorPage`) i możliwością zgłoszenia problemu do administratora.

## 🧠 Architektura i Clean Code

Projekt został stworzony z naciskiem na dobre praktyki inżynierii oprogramowania:

* **SRP & DRY:** Logika biznesowa jest oddzielona od widoków. Funkcje takie jak wysyłanie maili zostały wyekstrahowane do osobnych, dedykowanych klas (`EmailEngine.cs`).
* **Dependency Injection (Wstrzykiwanie Zależności):** Moduły z zadaniami implementują interfejs `IQuizEngine`, co pozwala uniwersalnej stronie quizu dynamicznie ładować dowolny dział bez powielania kodu.
* **Programowanie Asynchroniczne:** Operacje sieciowe (komunikacja SMTP) wykorzystują `async/await`, co gwarantuje pełną responsywność interfejsu (UI) podczas ładowania.
* **Bezpieczeństwo:** Wrażliwe dane (np. hasła aplikacji SMTP) są całkowicie odseparowane od repozytorium dzięki regułom `.gitignore`.

## 🛠️ Technologie
* C# (.NET 8.0)
* WPF (Windows Presentation Foundation)
* System.Net.Mail (SMTP)