using api.csv.DataBase.Models;
using System.Collections.Generic;
using System.IO;

namespace api.csv.DataBase
{
    public class dbContext
    {
        private const string PathName =
            "C:\\Users\\Usuario\\Desktop\\FACUL\\5º SEMESTRE\\PARADIGMAS DE LINGUAGEM DE PROGRAMAÇÃO\\APIs\\api.csv\\api.csv\\animais.txt";

        private readonly List<Animal> _animais = new();
        public dbContext()
        {
            string[] lines = 
                File.ReadAllLines(PathName);

            for (int i = 1; i < lines.Length; i++)
            {
                string [] coluns = 
                    lines[i].Split(';');

                Animal animal = new();
                animal.Id = int.Parse(coluns[0]);
                animal.Name = coluns[1];
                animal.Classification = coluns[2];
                animal.Origin = coluns[3];
                animal.Reproduction = coluns[4];
                animal.Feeding = coluns[5];

                _animais.Add(animal);

            }
        }

        public List<Animal> Animals => _animais;
    }
}
