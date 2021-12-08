using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{   
    //Entity framework kullnarak bir repository oluşturduk.
    //Önceden Sdece T ekliyorduk ya buraya birden fazla T eklenebilir.
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>// bana bir tane Entity tipi ver bir tanede context tipi ver. TEntity= çalışacağım tablonun ne olduğunu söyle, TContext=bir tanee context tipi ver. ben ona göre çalışıcam
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
        
    {
        public void Add(TEntity entity)
        {   //IDisposable pattern implement of C#
            using (TContext context = new TContext())//C# a özel kıymetli bir yapı.bir clası newlediğimde o bellekten garbagecolector bellir bir zaman sonra gelir ve bellekten atar using içine yazdığımda ise nesenelr using bitince garbage coletora a elir beni at diyor. using biraz pahalı. direkt burada newleede bilirim ama böyle daha performanslı
            {
                var addedEntity = context.Entry(entity);//Referansı yakala. VeriKaynağımla ilişkilendirdim
                addedEntity.State = EntityState.Added;//Ekle
                context.SaveChanges();//Değişikilkleri kaydet - gerçekleştir.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//C# a özel kıymetli bir yapı.bir clası newlediğimde o bellekten garbagecolector bellir bir zaman sonra gelir ve bellekten atar using içine yazdığımda ise nesenelr using bitince garbage coletora a elir beni at diyor. using biraz pahalı. direkt burada newleede bilirim ama böyle daha performanslı
            {
                var deletedEntity = context.Entry(entity);//Referansı yakala. VeriKaynağımla ilişkilendirdim
                deletedEntity.State = EntityState.Deleted;//sil
                context.SaveChanges();//Değişikilkleri kaydet - gerçekleştir.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) // tek data getirecek.
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // Db setimle product a bağlanıyorum(set) SingleOrDefault=> tek bir eleman bulmaya yarar
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {   //Veri tabanındaki bütün veriyi listeye çevir ve onu bana getir.(Select * from Products)
                return filter == null
                    ? context.Set<TEntity>().ToList() //Set<>.()=>>>Returns a DbSet<TEntity> instance for access to entities of the given type in the context and the underlying store.
                    : context.Set<TEntity>().Where(filter).ToList(); //Buraya parametre göndereceğim şey lambda. ben oraya neyazarsam yazayım onu getirecektir.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//C# a özel kıymetli bir yapı.bir clası newlediğimde o bellekten garbagecolector bellir bir zaman sonra gelir ve bellekten atar using içine yazdığımda ise nesenelr using bitince garbage coletora a elir beni at diyor. using biraz pahalı. direkt burada newleede bilirim ama böyle daha performanslı
            {
                var updatedEntity = context.Entry(entity);//Referansı yakala. VeriKaynağımla ilişkilendirdim
                updatedEntity.State = EntityState.Modified;//Güncelle
                context.SaveChanges();//Değişikilkleri kaydet - gerçekleştir.
            }
        }
    }
}
