using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RNWebStore.Models;
using RNWebStore.Infrastructure.Interfaces;


namespace RNWebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeesData: IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>(3)
            {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Петр",
                SurName = "Петрованцев",
                Patronymic = "Петрович",
                Age = 21,
                Position = "Тестировщик"
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Иван",
                SurName = "Ивановский",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Веб-Разработчик"
            },
            new EmployeeView
            {
                Id = 3,
                FirstName = "Сидор",
                SurName = "Сидоревич",
                Patronymic = "Сидорович",
                Age = 38,
                Position = "Руководитель разработки"
            }
            };

        }//InMemoryEmployeesData

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }

        public void Commit()
        {//Пока ничего не делаем.
        }

        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null) _employees.Remove(employee);
        }
    }
}
