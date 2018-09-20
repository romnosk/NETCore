using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RNWebStore.Models;


namespace RNWebStore.Infrastructure.Interfaces
{
    // Интерфейс для работы с пользователями
    public interface IEmployeesData
    {
        IEnumerable<EmployeeView> GetAll();

        EmployeeView GetById(int id);

        void Commit(); //Сохранить изменения

        void AddNew(EmployeeView model);

        void Delete(int id);
    }

}
