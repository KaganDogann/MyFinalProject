
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{       // Generic bir interface oluşturduk. T tipinde parametre gönderince T ne ise o gelecek. Bana çalışacağım türü söyle. category product
    //Generic constraint
    //Class referans tip
    //T IEntity olabilir veya onu implenmente eden bir nesne olabilir.
    // new() new'lene olabiir olmalı 
    //Bu kısımı iyi idrak et
    public interface IEntityRepository<T> where T:class,IEntity,new() //Burada bir sınırlama yaptım.T tpinin yalnızca class olabileceğini söyledim. 
    {                                                           //fakat programım içerisinde buraya gidecek başka class'larda olabilir. 
                                                              //bu sebeple dedim ki. T referans tip ve IEntity olabilir veya ondan implemente olan bir şey olabilir.
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //filter=null filtre vermeyebilirsin demek. filtre vermezse tüm detayı getir demek
        T Get(Expression<Func<T, bool>> filter); // Tek bir verinin detayına gitmek için Bize T döndüren bir operasyon oluşturduk. Tek bir detaya girmek için. tek bir elemanın verinni detayına girmek için.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        
    }
}
