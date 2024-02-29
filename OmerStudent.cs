using System;
using System.Collections.Generic;

class Student
{
    public int StudentNummer { get; set; }
    public string Naam { get; set; }
    public int Leeftijd { get; set; }

    public Student(int studentNummer, string naam, int leeftijd)
    {
        StudentNummer = studentNummer;
        Naam = naam;
        Leeftijd = leeftijd;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] namen = { "Omer", "Burak", "Mehmet", "Ghor", "Erencan", "Muhammed", "Jones", "Lucas", "Murat", "Uveys" };
        Random random = new Random();

        Dictionary<int, Student> studentenDict = new Dictionary<int, Student>();

        for (int i = 1; i <= 10; i++)
        {
            int randomLeeftijd = random.Next(17, 19); 
            int randomStudentNummer = random.Next(1000, 9999); 
            Student student = new Student(randomStudentNummer, namen[i - 1], randomLeeftijd);
            studentenDict.Add(student.StudentNummer, student);
        }

        int teVindenStudentNummer = 5000;
        if (studentenDict.ContainsKey(teVindenStudentNummer))
        {
            Student gevondenStudent = studentenDict[teVindenStudentNummer];
            Console.WriteLine($"Student gevonden met nummer {teVindenStudentNummer}: {gevondenStudent.Naam}");
        }
        else
        {
            Console.WriteLine($"Student met nummer {teVindenStudentNummer} niet gevonden.");
        }

        Console.WriteLine("\nStudentnummers:");
        foreach (var studentNummer in studentenDict.Keys)
        {
            Console.WriteLine(studentNummer);
        }


        SortedDictionary<int, Student> gesorteerdeStudentenDict = new SortedDictionary<int, Student>(studentenDict);
        Console.WriteLine("\nGesorteerde studentnummers en namen:");
        foreach (var kvp in gesorteerdeStudentenDict)
        {
            Console.WriteLine($"Studentnummer: {kvp.Key}, Naam: {kvp.Value.Naam}");
        }

        List<Student> studentenGesorteerdOpLeeftijd = new List<Student>(studentenDict.Values);
        studentenGesorteerdOpLeeftijd.Sort((s1, s2) => s1.Leeftijd.CompareTo(s2.Leeftijd));
        Console.WriteLine("\nStudenten gesorteerd op leeftijd:");
        foreach (var student in studentenGesorteerdOpLeeftijd)
        {
            Console.WriteLine($"Naam: {student.Naam}, Leeftijd: {student.Leeftijd}");
        }
    }
}
