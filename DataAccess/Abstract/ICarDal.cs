using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal
    {
        List<Car> GetAll();//Buradaki car eintities katmandan gelecek.
        List<Car> GetById(int Id);//Ürünleri ıdye göre filtrele
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        
    }
}
