using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{// Entities veri tabanındaki nesneleri koyabileceğimiz yardımcı katmandır.
    //Concrete-Somut, gerçek işi yapan nesneleri buraya koyucaz.
    //-    ÇCK   - Çıplak Class Kalmasın- İşaretleme Tekniği (:IEntity ile classımızı işaretledik.)
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }//marka ıd
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }//tanım
    }
}
