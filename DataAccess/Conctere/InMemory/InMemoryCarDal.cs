using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Conctere.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()//Projeyi başlatınca bellekte ürün listesi oluşturalım.
        {
            _car = new List<Car>
            {//Veriler Oracle,Sql Server,MongoDB,Potgres' dan geliyormuş gibi
                 new Car{ Id=1 , BrandId=1 , ColorId=1 , ModelYear="2001" , DailyPrice=5 , Description="BMW"},
                 new Car{ Id=2 , BrandId=2 , ColorId=2 , ModelYear="2019" , DailyPrice=7 , Description="Dacia"},
                 new Car{ Id=3 , BrandId=3 , ColorId=3 , ModelYear="2014" , DailyPrice=8 , Description="Mercedes"},
                 new Car{ Id=4 , BrandId=4 , ColorId=4 , ModelYear="2015" , DailyPrice=6 , Description="Fıat"}

            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            // _products.Remove(product);   bu şekilde silemeyiz NEDEN? -- Çünkü arayüzden gönderdiğimiz product bilgilerini aynı olması önemli değil, onun(yukarıdaki listedeki) heap'de 5 adresi var(yukarıdaki ürünler listesinden bahsediyorum).
            // Referans tipler referans no üzerinden gider. 5 adres ile aynı referans no'ya sahip olmadığı için silmez. bool, int, string gibi değer tip gönderseydik silerdi bu referans tip olduğu için silmez.
            //Peki ne yapıcaz? -- Ürünleri silerken o ürünün Primery Key'ini kullanırız çünkü PK o ürünü diğer ürünlerden ayırır. Bu yüzden product'ın Id'sini kullanarak ürünlerin Id'siyle eşleşen Id'yi bulup referansı yakalayacağız.
            //Bunu LINQ(Language Integrated Query) ile yapıcaz
            Car carToDelete = carToDelete = _car.SingleOrDefault(p=>p.Id == car.Id);
            _car.Remove(carToDelete);
            // yukarıdaki: "p=>" tek tek dolaşmaya yarıyor(listemizi) "p.ProductId == product.ProductId" her p için bak bakalım p'nin ProductId'si benim gönderdiğim product'ın Id'sine eşit mi eşit ise producttodelete eşitle
        }

        public List<Car> GetAll()//veri tabanındaki datayı business'a vermem lazım
        {
            return _car;//veri tabanını olduğu gibi döndürüyorum.
        }

        public List<Car> GetById(int Id)
        {// where içindeki şarta uyan bütün elemanları yeni bir liste haline getir ve dördurur. Where'ın içine itediğimiz kadar şart ekleyebiliriz.
            return _car.Where(p=>p.Id==Id).ToList();
        }

        public void Update(Car car)
        {//lınq
            // Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul.
            Car carToUpdate = carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;//carToUpdate'in BrandId'sini gönderdiğim car' ın BrandId'si yap
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
